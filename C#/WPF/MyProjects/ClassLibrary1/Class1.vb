Option Strict Off
Option Explicit On

Imports System.IO
Imports SPF.Server
Imports SPF.Server.Components.Core.APIs
Imports SPF.Server.Components.Core.Serialization
Imports SPF.Server.DataAccess
Imports SPF.Server.Schema.Collections
Imports System.Reflection
Imports System.Xml
Imports SPF.Server.Schema.Interface.Generated
Imports SPF.Server.Context
Imports SPF.Server.Utilities

Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Logging
Imports SPF.Server.Schema.Model
Imports SPXCommon.Logging


Namespace Intergraph.SPX.SPO.TagPublish
    Public Class SPXTagEffectivity
        Inherits ServerAPI

#Region " Constructor "

        Public Sub New()
            MyBase.New()
            Try
                Logging("Server API Instantiated.")
            Catch ex As Exception
                Throw New SPFException(1, "Application Block Logging is not set up for the application running on this tread.  Application name = " + Assembly.GetExecutingAssembly().FullName)
                'Throw New SPFException("Application Block Logging is not set up for the application running on this tread.  Application name = " + Assembly.GetExecutingAssembly().FullName)
            End Try


        End Sub

#End Region

#Region " Methods "
        Private WpUID As String = ""
        Private tagsCollection As SPF.Server.Schema.Collections.ObjectDictionary = New SPF.Server.Schema.Collections.ObjectDictionary()
        Private tagRelsDict As SPF.Server.Schema.Collections.IRelDictionary = New SPF.Server.Schema.Collections.RelDictionary(RelDictionaryTypes.Unknown)
        Private returnedDict As SPF.Server.Schema.Collections.IRelDictionary = New SPF.Server.Schema.Collections.RelDictionary(RelDictionaryTypes.Unknown)
        Private terminatedDict As SPF.Server.Schema.Collections.IObjectDictionary = New SPF.Server.Schema.Collections.ObjectDictionary()
        Private publishedDict As SPF.Server.Schema.Collections.IObjectDictionary = New SPF.Server.Schema.Collections.ObjectDictionary()

        Private lcolPublishedDict As New Hashtable
        Private ScopeLimit As Integer
        Private GraphDefUID As String
        Private EdgeDefUID As String
        Private RelDeftoExpand As String
        Private lcolPublishedGraphDict As New Hashtable
        Private mobjDataGraphResults As New SPF.Server.Schema.Model.StructuredObjectCollection
        Private lstrCDWEnabled As String

        Private TagRelatedRels As String

        Protected Overrides Sub OnDeSerialize()
            Dim lobjXMLRequestHelper As New XMLRequestHelper()
            DeSerializeObjects(lobjXMLRequestHelper.XMLSelectSingleNode("Objects"))

            Try
                WpUID = lobjXMLRequestHelper.XMLSelectSingleNode("WpUID").InnerText
                '    reportDefUID = CoreModule.Server.Request.SelectSingleNode("/Query/ReportDef").InnerText
                '    reportFilePath = CoreModule.Server.Request.SelectSingleNode("/Query/FilePath").InnerText
                '    objClass = CoreModule.Server.Request.SelectSingleNode("/Query/objClass").InnerText
                '    relUID = CoreModule.Server.Request.SelectSingleNode("/Query/relUID").InnerText

                'Logging("reportDefUID = " + reportDefUID + ":::FilePath = " + reportFilePath)

                ScopeLimit = CInt(lobjXMLRequestHelper.XMLSelectSingleNode("ScopeLimit").InnerText)
                GraphDefUID = lobjXMLRequestHelper.XMLSelectSingleNode("GraphDef").InnerText
                EdgeDefUID = lobjXMLRequestHelper.XMLSelectSingleNode("EdgeDef").InnerText
                RelDeftoExpand = lobjXMLRequestHelper.XMLSelectSingleNode("RelDef").InnerText
                '
                ' Chandra modified 
                '
                TagRelatedRels = lobjXMLRequestHelper.XMLSelectSingleNode("TagRelatedRels").InnerText

                lstrCDWEnabled = System.Configuration.ConfigurationManager.AppSettings.Item("CDWEnabled").ToString()

            Catch ex As Exception
                Throw New Exception("Could not extract Definition UID from ExportDef", ex)
            End Try

        End Sub

        Protected Overrides Sub OnHandlerBody()
            Logging("OnHandlerBody()")
            Try
                Logging("Cache only")
                ' Me.CoreModule.QueryRequest.DataContext.IgnoreEffectivity = True

                Dim wpObj As IObject = SPFRequestContext.Instance.QueryRequest.GetObject(GetObjType.ByUID, WpUID, False)


                Dim lobjDataGraphDef As IDirectedGraphDef = Nothing
                If GraphDefUID <> "" Then
                    lobjDataGraphDef = CType(SPFRequestContext.Instance.ProcessCache.Item(QueryTypes.UID, GraphDefUID).Interfaces("IDirectedGraphDef"), IDirectedGraphDef)
                End If

                Dim lintCount As Integer = 0
                Dim lintloop As Integer = 1

                If lobjDataGraphDef Is Nothing Then

                    Logging("WPObj name to publish:" & wpObj.Name)
                    Logging("WPObj UID to publish:" & wpObj.UID)

                    If EdgeDefUID <> "" Then
                        Dim EdgeDefObj As IObject = SPFRequestContext.Instance.QueryRequest.GetObject(GetObjType.ByUID, EdgeDefUID, False)
                        returnedDict = wpObj.ExpandEdgeDef(CType(EdgeDefObj.Interfaces("IEdgeDef"), IEdgeDef))
                    ElseIf RelDeftoExpand <> "" Then
                        If RelDeftoExpand.StartsWith("+") Then
                            RelDeftoExpand = RelDeftoExpand.Substring(1, RelDeftoExpand.Length - 1)
                            returnedDict = wpObj.GetEnd1Relationships.GetRels(RelDeftoExpand)
                        ElseIf RelDeftoExpand.StartsWith("-") Then
                            RelDeftoExpand = RelDeftoExpand.Substring(1, RelDeftoExpand.Length - 1)
                            returnedDict = wpObj.GetEnd2Relationships.GetRels(RelDeftoExpand)
                        End If
                    End If
                    '[bs]
                    Logging("TAG Count found linked to the Workpackage:" & returnedDict.GetEnd2s.Count)
                    'Logging("TAG name from WP:" & returnedDict.GetEnd2s.Item(0).Name)
                    'Logging("TAG name from WP:" & returnedDict.GetEnd2s.Item(0).UID)
                    'Logging("TAG Description from WP:" & returnedDict.GetEnd2s.Item(0).Description)

                    returnedDict.Sort()
                    Dim lobjSystemoptions As IObject = SPFRequestContext.Instance.QueryRequest.RunByUID("SystemOptions")
                    Dim lboolSPXUseTagNeedRepublish As Boolean = False
                    If (lobjSystemoptions IsNot Nothing) Then
                        If (lobjSystemoptions.Interfaces("ISPXOptions") IsNot Nothing) Then
                            If (lobjSystemoptions.Interfaces("ISPXOptions").Properties("SPXUseTagNeedRepublish") IsNot Nothing) Then
                                lboolSPXUseTagNeedRepublish = lobjSystemoptions.Interfaces("ISPXOptions").Properties("SPXUseTagNeedRepublish").Value
                            End If

                        End If

                    End If
                    With returnedDict.GetEnumerator
                        While .MoveNext

                            Dim aRel As IRel = CType(.Value, IRel)
                            Dim theTag As IObject = aRel.GetEnd2()

                            If Not theTag Is Nothing Then
                                '[BS] (RI-AM-65714 Publish from SPX to SPO no longer sets the needs publish and publish date)
                                'check NeedsRepublishing flag is FALSE
                                'Add only Tag that need to republish
                                If lboolSPXUseTagNeedRepublish = False Then
                                    If theTag.Interfaces.Contains("ISPFAuthPublishableItem") Then
                                        If theTag.Interfaces("ISPFAuthPublishableItem").Properties.Item("SPFAuthNeedsRepublishing").Value.ToString.ToUpper = "FALSE" Then

                                            Continue While

                                        End If
                                    End If
                                End If
                                '
                                '
                                '
                                If theTag.TerminationDate.Date < Date.Parse("12/31/9999") Then
                                    terminatedDict.Add(theTag)
                                Else

                                    If lintCount = ScopeLimit And ScopeLimit <> 0 Then
                                        lcolPublishedDict.Add(lintloop, CType(publishedDict, Object))
                                        lintloop = lintloop + 1
                                        lintCount = 0
                                        publishedDict = New SPF.Server.Schema.Collections.ObjectDictionary()
                                    End If

                                    publishedDict.Add(theTag)
                                    Logging("TAG name add to Container:" & theTag.Name)
                                    Logging("TAG Description add to Container:" & theTag.Description)
                                    'ElseIf Not aRel.TerminationDate.Date < Date.Parse("12/31/9999") Then
                                    '    ' Dim lobjDicEnd1 As IRelDictionary = theTag.GetEnd1Relationships()
                                    '    ' Dim lobjDicEnd2 As IRelDictionary = theTag.GetEnd2Relationships()
                                    '    publishedDict.Add(theTag)

                                    'sbala added
                                    Dim AllRelsColl As SPF.Server.Schema.Collections.ObjectDictionary = New SPF.Server.Schema.Collections.ObjectDictionary()
                                    AllRelsColl.Add(theTag)
                                    Dim query As QueryEngine.QueryRequest = New QueryEngine.QueryRequest()
                                    tagRelsDict = query.RunByGetAllRelsForObjects(AllRelsColl)
                                    For Each aRelIObject As IObject In tagRelsDict.Values
                                        publishedDict.Add(aRelIObject)
                                    Next

                                End If

                            End If

                            lintCount = lintCount + 1
                        End While
                    End With

                    If lintCount <= ScopeLimit Or ScopeLimit = 0 Then
                        lcolPublishedDict.Add(lintloop, CType(publishedDict, Object))
                    End If
                    '[BS] 
                    Logging("TAG Count found Needs Republishing:" & lcolPublishedDict.Count)
                Else
                    If RelDeftoExpand.StartsWith("+") Then
                        RelDeftoExpand = RelDeftoExpand.Substring(1, RelDeftoExpand.Length - 1)
                        tagsCollection = wpObj.GetEnd1Relationships.GetRels(RelDeftoExpand, False).GetEnd2s
                    ElseIf RelDeftoExpand.StartsWith("-") Then
                        RelDeftoExpand = RelDeftoExpand.Substring(1, RelDeftoExpand.Length - 1)
                        tagsCollection = wpObj.GetEnd2Relationships.GetRels(RelDeftoExpand, False).GetEnd1s
                    End If
                    '[bs]
                    Logging("TAG Count found linked to the Workpackage:" & tagsCollection.Count)
                    tagsCollection.Sort()
                    Dim lobjSystemoptions As IObject = SPFRequestContext.Instance.QueryRequest.RunByUID("SystemOptions")(0)
                    Dim lboolSPXUseTagNeedRepublish As Boolean = False
                    If (lobjSystemoptions IsNot Nothing) Then
                        If (lobjSystemoptions.Interfaces("ISPXOptions") IsNot Nothing) Then
                            If (lobjSystemoptions.Interfaces("ISPXOptions").Properties("SPXUseTagNeedRepublish") IsNot Nothing) Then
                                lboolSPXUseTagNeedRepublish = lobjSystemoptions.Interfaces("ISPXOptions").Properties("SPXUseTagNeedRepublish").Value
                            End If

                        End If

                    End If
                    Dim lintTagCount As Integer = 0
                    With tagsCollection.GetEnumerator
                        While .MoveNext

                            Dim lobjTagObject As IObject
                            lobjTagObject = DirectCast(.Value, IObject)

                            If Not lobjTagObject Is Nothing Then
                                '[BS] (RI-AM-65714 Publish from SPX to SPO no longer sets the needs publish and publish date)
                                'check NeedsRepublishing flag is FALSE
                                'Add only Tag that need to republish
                                If lboolSPXUseTagNeedRepublish = False Then


                                    If lobjTagObject.Interfaces.Contains("ISPFAuthPublishableItem") Then
                                        If lobjTagObject.Interfaces("ISPFAuthPublishableItem").Properties.Item("SPFAuthNeedsRepublishing").Value.ToString.ToUpper = "FALSE" Then
                                            Continue While
                                        End If
                                    End If
                                End If
                                If lobjTagObject.TerminationDate.Date < Date.Parse("12/31/9999") Then
                                    terminatedDict.Add(lobjTagObject)
                                Else

                                    If lintCount = ScopeLimit And ScopeLimit <> 0 Then
                                        lcolPublishedGraphDict.Add(lintloop, CType(mobjDataGraphResults, Object))
                                        lintloop = lintloop + 1
                                        lintCount = 0
                                        mobjDataGraphResults = New StructuredObjectCollection
                                    End If

                                    Dim lobjDataGraphResults As New SPF.Server.Schema.Model.StructuredObjectCollection
                                    lobjDataGraphResults.Add(lobjTagObject)
                                    SPFRequestContext.Instance.QueryRequest.AddObjectsToExpand(lobjDataGraphResults)
                                    lobjDataGraphResults = SPFRequestContext.Instance.QueryRequest.RunByExpandGraphDef(lobjDataGraphDef)



                                    Dim lobjMastercollection As StructuredObjectCollection = Add(lobjDataGraphResults, TagRelatedRels, lobjTagObject.UID)


                                    With lobjMastercollection.GetEnumerator
                                        While .MoveNext
                                            If Not lobjDataGraphResults.Contains(CType(.Current, StructuredObject).OBID) Then
                                                lobjDataGraphResults.Add(CType(.Current, StructuredObject))
                                            End If

                                        End While
                                    End With

                                    If lobjDataGraphResults.Count > 0 Then
                                        mobjDataGraphResults = lobjDataGraphResults
                                    End If
                                End If
                            End If
                            lintCount = lintCount + 1
                        End While
                    End With

                    If lintCount <= ScopeLimit Or ScopeLimit = 0 Then
                        lcolPublishedGraphDict.Add(lintloop, CType(mobjDataGraphResults, Object))
                    End If
                End If
                '[BS] 
                Logging("TAG Count found Needs Republishing:" & lcolPublishedGraphDict.Count)
                Logging("Successful getting list of all objects from " + WpUID)

            Catch ex As Exception
                Logging("Error getting list of all objects from " + WpUID)
            Finally
                SPFRequestContext.Instance.IgnoreEffectivity = False
            End Try


        End Sub

        Protected Overrides Sub OnSerialize()
            Logging("RunReport OnSerialize()")
            Dim lnodReply As XmlNode = SPFRequestContext.Instance.Response.AppendChild(SPFRequestContext.Instance.Response.CreateElement("Reply"))
            Dim lnodTerminate As XmlNode = lnodReply.AppendChild(SPFRequestContext.Instance.Response.CreateElement("Terminate"))
            lnodTerminate.AppendChild(SPFRequestContext.Instance.Response.ImportNode(SPFRequestContext.Instance.Serializer.Serialize(terminatedDict, New EFXmlSerializationWriter()), True))

            '
            If lcolPublishedDict.Count > 0 Then
                With lcolPublishedDict.GetEnumerator()
                    While .MoveNext

                        Dim publishedInChunckDict As SPF.Server.Schema.Collections.IObjectDictionary = New SPF.Server.Schema.Collections.ObjectDictionary()

                        publishedInChunckDict = CType(.Value, IObjectDictionary)

                        Dim lnodPublish As XmlNode = lnodReply.AppendChild(SPFRequestContext.Instance.Response.CreateElement("Publish"))
                        lnodPublish.AppendChild(SPFRequestContext.Instance.Response.ImportNode(SPFRequestContext.Instance.Serializer.Serialize(publishedInChunckDict, New EFXmlSerializationWriter()), True))

                    End While
                End With
            ElseIf lcolPublishedGraphDict.Count > 0 Then
                With lcolPublishedGraphDict.GetEnumerator()
                    While .MoveNext

                        Dim publishedInChunckDict As SPF.Server.Schema.Model.StructuredObjectCollection

                        publishedInChunckDict = CType(.Value, StructuredObjectCollection)

                        Dim lnodPublish As XmlNode = lnodReply.AppendChild(SPFRequestContext.Instance.Response.CreateElement("Publish"))
                        lnodPublish.AppendChild(SPFRequestContext.Instance.Response.ImportNode(SPFRequestContext.Instance.Serializer.Serialize(publishedInChunckDict, New Components.Core.Serialization.EFXmlSerializationWriter(True, "Container", "")), True))
                    End While
                End With
            End If
            Dim lnodCDW As XmlNode = lnodReply.AppendChild(SPFRequestContext.Instance.Response.CreateElement("CDWEnabled"))
            lnodCDW.InnerText = lstrCDWEnabled

        End Sub

        Private Sub Logging(ByVal strText As String)
            Try
                SPXLog.Verbose("[AttachReportResults]" + strText)
            Catch
            End Try
        End Sub

#End Region

        Private Function Add(ByVal pstrGraphDef As StructuredObjectCollection, pstrtagrelatedrels As String, ByVal pstrtaguid As String) As StructuredObjectCollection


            Dim lcolTagRelatedlist As List(Of String) = Nothing

            Dim lcoltagrelatedrels As List(Of String) = filterRels(pstrtagrelatedrels)
            Dim lobjDataGraphDef As IDirectedGraphDef = CType(SPFRequestContext.Instance.ProcessCache.Item(QueryTypes.UID, GraphDefUID).Interfaces("IDirectedGraphDef"), IDirectedGraphDef)





            Dim lColRelatedTagobject As New StructuredObjectCollection



            Dim lstrobid As String = String.Empty

            Dim lstrtagcdwobjectuid As String = String.Empty
            For Each obj As DictionaryEntry In pstrGraphDef.AllObjects()

                Dim lobjchildtag As IObject = Nothing

                Dim lobject As IObject = CType(obj.Value, IObject)
                Dim tagobjectuid As String = String.Empty

                If lobject.ClassDefinitionUID = "Rel" Then

                    Dim irelobject As IRel = CType(lobject.Interfaces("IRel"), IRel)

                    If (lcoltagrelatedrels.Contains(irelobject.DefUID)) Then




                        tagobjectuid = irelobject.UID2

                        If (tagobjectuid.Equals(pstrtaguid)) Then
                            tagobjectuid = irelobject.UID1
                        End If
                        Dim tagobjectuiddomain As String = irelobject.DomainUID2

                        'check whether the child tagobject exit's in the  collection of tags and doesnt exist
                        ' condition on workpackage is true

                        ' if child object doesnt exit in the collection of tag objects then remove tagobject(child and rel tagconnection from the structured collection)
                        ' return the sturcutred collection

                        ' if child object exist in the collection and wp is true or false 
                        ' just return the collection asusual by expanding the graph
                        '

                        '' check whether the child is in spopublish domain also. if it exist in the  query the database for cdw domain add to collection
                        ' if it is Authoring domain dont add it to structured collection.

                        If (tagobjectuiddomain = "SPOPublish") Then
                            lstrtagcdwobjectuid = tagobjectuid & "_S"
                            lobjchildtag = SPFRequestContext.Instance.QueryRequest.GetObjectByUIDAndDomain(lstrtagcdwobjectuid, "CDW")
                        Else
                            lobjchildtag = SPFRequestContext.Instance.QueryRequest.GetObjectByUIDAndDomain(tagobjectuid, tagobjectuiddomain)
                        End If




                        lstrobid = lobjchildtag.OBID



                        If Not tagsCollection.ContainsByObid(lstrobid) Then
                            lColRelatedTagobject.Add(lobjchildtag)
                            SPFRequestContext.Instance.QueryRequest.AddObjectsToExpand(lColRelatedTagobject)

                            lColRelatedTagobject = SPFRequestContext.Instance.QueryRequest.RunByExpandGraphDef(lobjDataGraphDef)



                        End If


                    End If
                End If




            Next


            Return lColRelatedTagobject
        End Function


        Private Function filterRels(ByVal pstrtagrelatedrels As String) As List(Of String)

            Dim lcolrels() As String = pstrtagrelatedrels.Split(CChar(","))

            Return lcolrels.ToList()
        End Function
    End Class

End Namespace

