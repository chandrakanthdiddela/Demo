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
        Private lblnFlag As Boolean

        Private TagRelatedRels As String
        Dim lobjMastercollection As StructuredObjectCollection
        Dim lobjDataGraphResults As New SPF.Server.Schema.Model.StructuredObjectCollection
        Dim counter As Integer = 0

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
                lblnFlag = lobjXMLRequestHelper.XMLSelectSingleNode("Flag").InnerText

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

                                    '  Dim lobjDataGraphResults As New SPF.Server.Schema.Model.StructuredObjectCollection
                                    lobjDataGraphResults.Add(lobjTagObject)
                                    SPFRequestContext.Instance.QueryRequest.AddObjectsToExpand(lobjDataGraphResults)
                                    lobjDataGraphResults = SPFRequestContext.Instance.QueryRequest.RunByExpandGraphDef(lobjDataGraphDef)


                                    '  Dim lobjMastercollection As StructuredObjectCollection

                                    ' Dim flag As Boolean = False
                                    If lblnFlag Then
                                        lobjMastercollection = ProcessTagwithFlag(lobjDataGraphResults, TagRelatedRels, lobjTagObject.UID, tagsCollection, )
                                    Else
                                        ' Dim lcolTagEndls As IRelDictionary = lobjTagObject.GetEnd2Relationships().GetRels("TagConnection")
                                        ' lobjDataGraphResults.AllObjects.Add(lcolTagEndls)

                                        lobjMastercollection = ProcessTagwithoutFlag(lobjDataGraphResults, TagRelatedRels, lobjTagObject.UID, tagsCollection)

                                    End If




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

        ''' <summary>
        ''' On ProcessTagwithoutFlag
        ''' </summary>
        ''' <compilewhen>Internal</compilewhen>
        ''' <remarks>
        '''Created  Chandra 28/02/2014 - 
        ''' 1. pstrGraph def 
        ''' 2. list of tagtotag relationship
        ''' 3. uid of current tag
        ''' 4. collection of Tags in the WorkPackage
        ''' </remarks>

        Private Function ProcessTagwithoutFlag(ByVal pstrDataGraphResults As StructuredObjectCollection, pstrtagrelatedrels As String, ByVal pstrtaguid As String, ByVal pcoltagcollections As IObjectDictionary) As StructuredObjectCollection


            ' List to store list of TAG-TAG Rels
            '
            '
            Dim lcolTagRelatedlist As List(Of String) = Nothing

            '
            ' Store list of TAG-TAG after filtering the method Argument
            '


            Dim lcoltagrelatedrels As List(Of String) = filterRels(pstrtagrelatedrels)

            '
            ' Querying the DB to get 'TagPublishExpansion'
            '


            Dim lobjDataGraphDef As IDirectedGraphDef = CType(SPFRequestContext.Instance.ProcessCache.Item(QueryTypes.UID, GraphDefUID).Interfaces("IDirectedGraphDef"), IDirectedGraphDef)



            '
            '  Instantiate StructuredObjectCollection
            '



            Dim lColAdditionalRelsChildTag As New StructuredObjectCollection



            Dim lstrobid As String = String.Empty

            '
            ' String to store uid of CDW object
            '


            Dim lstrtagcdwobjectuid As String = String.Empty

            '
            '  Loop around the collection we get after expanding  'TagPublishExpansion' for each tag
            ' 1.TagAssembly
            ' 2.TagConnection
            ' 3.EquipmentComponentComposition
            '
            '
            For Each obj As DictionaryEntry In pstrDataGraphResults.AllObjects()

                Dim lobjchildtag As IObject = Nothing

                Dim lobject As IObject = CType(obj.Value, IObject)
                Dim tagobjectuid As String = String.Empty


                If lobject.ClassDefinitionUID = "Rel" Then

                    Dim irelobject As IRel = CType(lobject.Interfaces("IRel"), IRel)


                    '
                    ' Check for whether TAG has following realtions in object collection
                    ' TagAssembly
                    ' TagConnection
                    ' EquipmentComponentComposition

                    If (lcoltagrelatedrels.Contains(irelobject.DefUID)) Then




                        tagobjectuid = irelobject.UID2

                        If (tagobjectuid.Equals(pstrtaguid)) Then
                            tagobjectuid = irelobject.UID1
                        End If
                        Dim tagobjectuiddomain As String = irelobject.DomainUID2
                        '
                        ' Check whether tag  domainuid of related tag is 'SPOPublish' 
                        ' note : need to check Oren/steve do we need handle case for the other domain in such way need to find out what domain can publish the tags
                        If (tagobjectuiddomain = "SPOPublish") Then
                            '
                            ' Append "_S" to uid of SPOPublish object
                            '
                            lstrtagcdwobjectuid = tagobjectuid & "_S"
                            '
                            ' Querying the Db to get CDW object with uid and domain
                            '
                            lobjchildtag = SPFRequestContext.Instance.QueryRequest.GetObjectByUIDAndDomain(lstrtagcdwobjectuid, "CDW")
                        Else
                            '
                            ' Querying the DB to get Authoring Tag
                            '
                            lobjchildtag = SPFRequestContext.Instance.QueryRequest.GetObjectByUIDAndDomain(tagobjectuid, tagobjectuiddomain)
                        End If


                        '
                        ' store the obid of the child tag 
                        '

                        lstrobid = lobjchildtag.OBID


                        '
                        ' check whether the tag exist in the  workpackage 
                        '
                        If Not tagsCollection.ContainsByObid(lstrobid) Then
                            '
                            ' Add the tag 
                            '
                            lColAdditionalRelsChildTag.Add(lobjchildtag)
                            SPFRequestContext.Instance.QueryRequest.AddObjectsToExpand(lColAdditionalRelsChildTag)
                            '
                            ' Expading the graph for ChlidTag
                            '
                            lColAdditionalRelsChildTag = SPFRequestContext.Instance.QueryRequest.RunByExpandGraphDef(lobjDataGraphDef)



                        End If


                    End If
                End If




            Next


            Return lColAdditionalRelsChildTag
        End Function


        Private Function filterRels(ByVal pstrtagrelatedrels As String) As List(Of String)

            Dim lcolrels() As String = pstrtagrelatedrels.Split(CChar(","))

            Return lcolrels.ToList()
        End Function

        ''' <summary>
        ''' On ProcessTagwithFlag
        ''' </summary>
        ''' <compilewhen>Internal</compilewhen>
        ''' <remarks>
        '''Created  Chandra 28/02/2014 - 
        ''' 1. pstrGraph def 
        ''' 2. list of tagtotag relationship
        ''' 3. uid of current tag
        ''' 4. collection of Tags in the WorkPackage
        ''' </remarks>

        'Private Function ProcessTagwithFlag(ByRef pstrDataGraphResults As StructuredObjectCollection, pstrtagrelatedrels As String, ByVal pstrtaguid As String, ByVal pcoltagsCollection As ObjectDictionary, ByRef counter As Integer) As StructuredObjectCollection

        '    '
        '    ' List to store list of TAG-TAG Rels
        '    '
        '    Dim lcolTagRelatedlist As List(Of String) = Nothing
        '    '
        '    ' Store list of TAG-TAG after filtering the method Argument
        '    '

        '    Dim lcoltagrelatedrels As List(Of String) = filterRels(pstrtagrelatedrels)
        '    '
        '    ' Querying the DB to get 'TagPublishExpansion'
        '    '
        '    Dim lobjDataGraphDef As IDirectedGraphDef = CType(SPFRequestContext.Instance.ProcessCache.Item(QueryTypes.UID, GraphDefUID).Interfaces("IDirectedGraphDef"), IDirectedGraphDef)

        '    '
        '    '  Instantiate StructuredObjectCollection
        '    '


        '    Dim lColRelatedTagobject As New StructuredObjectCollection


        '    Dim lstrobid As String = String.Empty
        '    '
        '    ' String to store uid of CDW object
        '    '

        '    Dim lstrChildTagCDWObjectUID As String = String.Empty

        '    '
        '    '  Loop around the collection we get after expanding  'TagPublishExpansion' for each tag
        '    ' 1.TagAssembly
        '    ' 2.TagConnection
        '    ' 3.EquipmentComponentComposition
        '    '
        '    '
        '    '
        '    If pcoltagsCollection.Count > counter Then

        '        counter = counter + 1

        '        For Each obj As DictionaryEntry In pstrDataGraphResults.AllObjects()

        '            '      Dim lobjChildTag As IObject = Nothing

        '            Dim lobjCDWChildTag As IObject = Nothing

        '            Dim lobjRel As IObject = CType(obj.Value, IObject)
        '            Dim lstrtagobjectuid As String = String.Empty

        '            Dim lstrOBIDofrel As String = String.Empty

        '            Dim lstrUIDofChildTag As String = String.Empty

        '            Dim lstrCDWUIDofChildTag As String = String.Empty

        '            Dim lstrOBIDOfChildTag As String = String.Empty
        '            '
        '            ' Check for whether TAG has following realtions in object collection
        '            ' TagAssembly
        '            ' TagConnection
        '            ' EquipmentComponentComposition



        '            If lobjRel.ClassDefinitionUID = "Rel" Then



        '                Dim lobjectRel As IRel = CType(lobjRel.Interfaces("IRel"), IRel)
        '                '
        '                ' Checking whether the rel 
        '                '

        '                If (lcoltagrelatedrels.Contains(lobjectRel.DefUID)) Then
        '                    '
        '                    ' Store the OBID of the Rel
        '                    '


        '                    lstrOBIDofrel = lobjRel.OBID

        '                    lstrtagobjectuid = lobjectRel.UID1
        '                    '
        '                    ' Checking whether it is uid1 or uid2 
        '                    '

        '                    If (lstrtagobjectuid.Equals(pstrtaguid)) Then
        '                        '
        '                        ' Store the uid of Child object
        '                        '
        '                        lstrtagobjectuid = lobjectRel.UID2
        '                        '
        '                        ' Store the OBID of the ChildTagobject
        '                        '
        '                        ' lstrOBIDofChildTag = lobjectRel.OBID

        '                    Else

        '                        '
        '                        ' Store the uid of Child object
        '                        '
        '                        lstrtagobjectuid = lobjectRel.UID1

        '                        '
        '                        ' Store the OBID of the ChildTagobject
        '                        '
        '                        ' lstrOBIDofChildTag = lobjectRel.OBID

        '                    End If
        '                    '
        '                    ' Querying the database from the SPX Authoring Domain
        '                    '
        '                    Dim lobjChildTag As IObject = Nothing

        '                    If lstrtagobjectuid.Contains("_Mapped") Then
        '                        lobjChildTag = SPFRequestContext.Instance.QueryRequest.GetObjectByUIDAndDomain(lstrtagobjectuid, "SPOPublish")
        '                        lstrUIDofChildTag = lobjChildTag.UID
        '                        lstrOBIDOfChildTag = lobjChildTag.OBID
        '                        '
        '                        ' Appended the "_S" string to Authoring tag uid to get CDW object
        '                        '
        '                        lstrCDWUIDofChildTag = lstrUIDofChildTag & "_S"
        '                    Else
        '                        lobjChildTag = SPFRequestContext.Instance.QueryRequest.GetObjectByUIDAndDomain(lstrtagobjectuid, "SPXAuthoring")
        '                        lstrUIDofChildTag = lobjChildTag.UID
        '                        lstrOBIDOfChildTag = lobjChildTag.OBID
        '                        '
        '                        ' Appended the "_Mapped_S" string to Authoring tag uid to get CDW object
        '                        '
        '                        lstrCDWUIDofChildTag = lstrUIDofChildTag & "_Mapped_S"
        '                    End If
        '                    '
        '                    ' Querying the database to get CDW  ChildTag object
        '                    '
        '                    lobjCDWChildTag = SPFRequestContext.Instance.QueryRequest.GetObjectByUIDAndDomain(lstrCDWUIDofChildTag, "CDW")
        '                    '
        '                    ' Check  whether ChildTag object already exist in the workpackage 
        '                    '
        '                    If Not pcoltagsCollection.ContainsByObid(lstrOBIDOfChildTag) And lobjCDWChildTag Is Nothing Then

        '                        '
        '                        ' since ChildTag doesnt exist in the workpackage, remove ChildTag object and Rel related to it
        '                        '
        '                        '
        '                        ' Same tag can be related other other using different relationship
        '                        '
        '                        If pstrDataGraphResults.AllObjects.Contains(lobjChildTag) Then

        '                            pstrDataGraphResults.AllObjects.Remove(lobjChildTag)

        '                        End If


        '                        pstrDataGraphResults.AllObjects.Remove(lobjRel)
        '                        '
        '                        ' Need to check whether it exist in CDW Domain
        '                        '
        '                    ElseIf Not lobjCDWChildTag Is Nothing Then

        '                        ' pstrDataGraphResults.AllObjects.Remove(lobjCDWChildTag)

        '                        pstrDataGraphResults.AllObjects.Remove(lobjChildTag)
        '                        '
        '                        ' Removing spo published object from collection to avoid smartplant foundation error 
        '                        '
        '                        ' If (lobjChildTag.DomainUID = "SPOPublish") Then
        '                        ' pstrDataGraphResults.AllObjects.Remove(lobjChildTag)
        '                        'End If


        '                        '
        '                        ' Adding it collection by expanding the graph on cdw object 
        '                        '
        '                        'lColRelatedTagobject.Add(lobjCDWChildTag)
        '                        'SPFRequestContext.Instance.QueryRequest.AddObjectsToExpand(lColRelatedTagobject)

        '                        'lColRelatedTagobject = SPFRequestContext.Instance.QueryRequest.RunByExpandGraphDef(lobjDataGraphDef)

        '                        ' lColRelatedTagobject.AllObjects.Add(lobjectRel)
        '                        lColRelatedTagobject = Nothing

        '                    Else
        '                        '
        '                        ' Both Parent Tag and Child Tag are in the same workpackage then expanding the graph on related object
        '                        '

        '                        lColRelatedTagobject.Add(lobjChildTag)
        '                        SPFRequestContext.Instance.QueryRequest.AddObjectsToExpand(lColRelatedTagobject)

        '                        lColRelatedTagobject = SPFRequestContext.Instance.QueryRequest.RunByExpandGraphDef(lobjDataGraphDef)


        '                    End If


        '                    ' Dim tagobjectuiddomain As String = lobjectRel.DomainUID2


        '                End If

        '            End If
        '        Next

        '    End If
        '    '
        '    ' Removing Child Tag object and rel corresponding it from objectcollection if it is not present in the WorkPackage
        '    '
        '    If (lColRelatedTagobject Is Nothing) Then

        '        '
        '        ' Removing Child Tag object and rel corresponding it from objectcollection if it is not present in the WorkPackage
        '        '
        '        Return pstrDataGraphResults

        '    Else

        '        '
        '        '  IF TAG is present in CDW domain then Collection Contain CDW object 
        '        '   IF TAG is present in Authoring Domain the collection contain Authoring tag and its Relationship(Area,Plant,System,Unit)
        '        Return lColRelatedTagobject
        '    End If



        'End Function


        Private Function ProcessTagwithFlag(ByRef pstrDataGraphResults As StructuredObjectCollection, ByVal pstrTagRels As String, ByVal pstrTagUID As String, ByVal pcolTagsCollection As ObjectDictionary, ByRef counter As Integer) As StructuredObjectCollection

            '
            ' List to store list of TAG-TAG Rels
            '
            '   Dim llstTagRels As List(Of String) = Nothing
            '
            ' Store list of TAG-TAG after filtering the method Argument
            '
            Dim llstTagRels As List(Of String) = filterRels(pstrTagRels)
            '
            ' Querying the DB to get 'TagPublishExpansion'
            '
            Dim lobjDataGraphDef As IDirectedGraphDef = CType(SPFRequestContext.Instance.ProcessCache.Item(QueryTypes.UID, GraphDefUID).Interfaces("IDirectedGraphDef"), IDirectedGraphDef)
            '
            '  Instantiate StructuredObjectCollection
            '
            Dim lColChildTagRels As New StructuredObjectCollection

            Dim lstrTagOBID As String = String.Empty
            '
            ' String to store uid of CDW object
            '
            Dim lstrChildTagCDWObjectUID As String = String.Empty
            '
            '  Loop through the collection which we get after expanding the 'TagPublishExpansion' GraphDef for each tag related to the workpackage
            ' 


            For Each obj As DictionaryEntry In pstrDataGraphResults.AllObjects()

                Dim lobjItem As IObject = CType(obj.Value, IObject)
                Dim lstrTagObjectUID As String = String.Empty
                Dim lstrRelOBID As String = String.Empty
                Dim lobjCDWChildTag As IObject = Nothing
                Dim lstrUIDOfChildTag As String = String.Empty
                Dim lstrCDWUIDOfChildTag As String = String.Empty
                Dim lstrOBIDOfChildTag As String = String.Empty
                '
                ' Check whether TAG has the following realtions in the Collection
                ' TagAssembly
                ' TagConnection
                ' EquipmentComponentComposition
                '
                If lobjItem.ClassDefinitionUID = "Rel" Then

                    Dim lobjRel As IRel = CType(lobjItem.Interfaces("IRel"), IRel)
                    '
                    ' Checking whether the rel exists in the Publish method argument -11
                    '

                    If pcolTagsCollection.Count > counter Then

                        counter = counter + 1




                        If (llstTagRels.Contains(lobjRel.DefUID)) Then
                            '
                            ' Store the OBID of the Rel (TagAssembly,TagConnection,EquipmentComponentComposition)
                            '
                            lstrRelOBID = lobjItem.OBID
                            '
                            ' store the UID1 of the Rel
                            '
                            lstrTagObjectUID = lobjRel.UID1
                            '
                            ' Checking whether it is UID1 or UID12
                            '
                            If (lstrTagObjectUID.Equals(pstrTagUID)) Then

                                lstrTagObjectUID = lobjRel.UID2

                            Else

                                lstrTagObjectUID = lobjRel.UID1

                            End If
                            '
                            ' Querying the database from the SPX Authoring Domain
                            '
                            Dim lobjChildTag As IObject = Nothing
                            '
                            ' this code can be  useful if there may be requirement to relate AuthoringTag object to Published Object (SPOPublish) but we can comment it out
                            '
                            'If lstrtagobjectuid.Contains("_Mapped") Then
                            '    lobjChildTag = SPFRequestContext.Instance.QueryRequest.GetObjectByUIDAndDomain(lstrtagobjectuid, "SPOPublish")
                            '    lstrUIDofChildTag = lobjChildTag.UID
                            '    lstrOBIDOfChildTag = lobjChildTag.OBID
                            '    '
                            '    ' Appended the "_S" string to Authoring tag uid to get CDW object
                            '    '
                            '    lstrCDWUIDofChildTag = lstrUIDofChildTag & "_S"

                            lobjChildTag = SPFRequestContext.Instance.QueryRequest.GetObjectByUIDAndDomain(lstrTagObjectUID, "SPXAuthoring")
                            lstrUIDOfChildTag = lobjChildTag.UID
                            lstrOBIDOfChildTag = lobjChildTag.OBID
                            '
                            ' Appended the "_Mapped_S" string to Authoring tag uid to get CDW object
                            '
                            lstrCDWUIDOfChildTag = lstrUIDOfChildTag & "_Mapped_S"
                            '
                            ' Querying the database to get CDW  ChildTag object
                            '
                            lobjCDWChildTag = SPFRequestContext.Instance.QueryRequest.GetObjectByUIDAndDomain(lstrCDWUIDOfChildTag, "CDW")
                            '
                            ' Check  whether ChildTag object already exist in the workpackage 
                            '
                            If Not pcolTagsCollection.ContainsByObid(lstrOBIDOfChildTag) And lobjCDWChildTag Is Nothing Then
                                '
                                ' Since ChildTag doesnt exist in the workpackage, remove ChildTag object and Rel related to it
                                '
                                '
                                ' Same tag can be related to other using different relationship
                                '
                                If pstrDataGraphResults.AllObjects.Contains(lobjChildTag) Then

                                    pstrDataGraphResults.AllObjects.Remove(lobjChildTag)

                                End If

                                pstrDataGraphResults.AllObjects.Remove(lobjItem)
                                '
                                ' Need to check whether Childtag exist in CDW Domain
                                '
                            ElseIf Not lobjCDWChildTag Is Nothing Then

                                pstrDataGraphResults.AllObjects.Remove(lobjChildTag)

                                lColChildTagRels = Nothing

                                ' pstrDataGraphResults.AllObjects.Remove(lobjCDWChildTag)
                                ' this is code is useful when we relate Authoring Tag to SPOPublish Tag
                                ' Removing spo published object from collection to avoid smartplant foundation error 
                                '
                                ' If (lobjChildTag.DomainUID = "SPOPublish") Then
                                ' pstrDataGraphResults.AllObjects.Remove(lobjChildTag)
                                'End If
                            Else

                                '
                                ' Both Parent Tag and Child Tag are in the same WorkPackage then expanding the graph on related ChildTagobject
                                '

                                lColChildTagRels.Add(lobjChildTag)
                                SPFRequestContext.Instance.QueryRequest.AddObjectsToExpand(lColChildTagRels)
                                lColChildTagRels = SPFRequestContext.Instance.QueryRequest.RunByExpandGraphDef(lobjDataGraphDef)


                            End If

                        End If
                    End If
                End If
            Next


            If (lColChildTagRels Is Nothing) Then
                ' here we have two scenarios, TAG2 not published  and TAG2 published (viceversa)
                ' if  TAG2 is not present in the workpackage then pstrDataGraphResults collection contain TAG1 and relationship related to it(AreaTag,PlantTag,UnitTag,SystemTag) and viceversa
                ' 
                ' if TAG2 is already published then pstrDataGraphResults only contains TAG1 and all relationship related to it((AreaTag,PlantTag,UnitTag,SystemTag,TagConnection) and viceversa . this is avoiding reconsolidating the same object one more time
                Return pstrDataGraphResults

            Else

                '
                '   IF TAG is present in Authoring Domain the collection contain Authoring tag and its Relationship(Area,Plant,System,Unit)
                '
                Return lColChildTagRels
            End If



        End Function

    End Class

End Namespace

