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

        Private lstrCDWEnabled As String

        Private lblnFlag As Boolean

        Private TagRelatedRels As String

        Dim mobjAddChildCollection As New StructuredObjectCollection

        Dim mobjAllCollection As StructuredObjectCollection

        Dim lobjMasterDataGraphResults As New SPF.Server.Schema.Model.StructuredObjectCollection



        Dim llstTraversedObjects As New Dictionary(Of String, TraversedObjInfo)

        Dim llstRemovedObjectOBIDs As List(Of String)



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

                ' Modified Chandrakanth 12/03/2014 CR-AM-78313 -Inconsistent publishing of SPO authoring and tag to tag rel

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



            Dim mobjDataGraphResults As New StructuredObjectCollection()



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

                    '

                    ' Collection to store Child Tag object when we reach Scope limit

                    '

                    Dim lStructuredobjcollection As StructuredObjectCollection = Nothing

                    '

                    ' Object to Store Parent Tag object when we reach the Scope limit. it is avoid publishing of Parent object again in another chunk.

                    '

                    Dim lobjparent As IObject = Nothing

                    'Dim lobjparent1 As IObject = Nothing

                    Do



                        Dim lobjTagObject As IObject = Nothing



                        If tagsCollection.Any Then

                            lobjTagObject = tagsCollection.Item(0)



                            tagsCollection.Remove(lobjTagObject)



                            If Not lobjTagObject Is Nothing Then

                                '[BS] (RI-AM-65714 Publish from SPX to SPO no longer sets the needs publish and publish date)

                                'check NeedsRepublishing flag is FALSE

                                'Add only Tag that need to republish

                                If lboolSPXUseTagNeedRepublish = False Then



                                    If lobjTagObject.Interfaces.Contains("ISPFAuthPublishableItem") Then

                                        If lobjTagObject.Interfaces("ISPFAuthPublishableItem").Properties.Item("SPFAuthNeedsRepublishing").Value.ToString.ToUpper = "FALSE" Then

                                            Continue Do

                                        End If

                                    End If

                                End If

                                If lobjTagObject.TerminationDate.Date < Date.Parse("12/31/9999") Then

                                    terminatedDict.Add(lobjTagObject)

                                Else



                                    If lintCount = ScopeLimit And ScopeLimit <> 0 Then

                                        ' lcolPublishedGraphDict.Add(lintloop, CType(mobjDataGraphResults, Object))

                                        lintloop = lintloop + 1

                                        lintCount = 0

                                        '

                                        ' To Store new Chunk

                                        '



                                        lobjMasterDataGraphResults = New StructuredObjectCollection



                                        mobjDataGraphResults = New StructuredObjectCollection

                                    End If







                                    Dim lobjDataGraphResults As New SPF.Server.Schema.Model.StructuredObjectCollection

                                    lobjDataGraphResults.Add(lobjTagObject)

                                    SPFRequestContext.Instance.QueryRequest.AddObjectsToExpand(lobjDataGraphResults)

                                    lobjDataGraphResults = SPFRequestContext.Instance.QueryRequest.RunByExpandGraphDef(lobjDataGraphDef)







                                    '

                                    ' Modified  Chandrakanth 12/03/2014 CR-AM-78313 -Inconsistent publishing of SPO authoring and tag to tag rel

                                    ' This argument is specified on  WPTagPublishMethod Argument-10

                                    '



                                    Dim lobjparent1 As IObject



                                    If lblnFlag Then

                                        If lStructuredobjcollection IsNot Nothing Then

                                            lintCount = lintCount + 1

                                            mobjAllCollection = lStructuredobjcollection

                                            lStructuredobjcollection = Nothing

                                            lobjparent1 = lobjparent

                                            mobjAddChildCollection = ProcessTagwithFlag(lobjDataGraphResults, TagRelatedRels, lobjTagObject.UID, tagsCollection, lobjMasterDataGraphResults, lintCount, lStructuredobjcollection, lobjparent, GraphDefUID)



                                            With mobjAllCollection.GetEnumerator

                                                While .MoveNext

                                                    If Not lobjMasterDataGraphResults.Contains(CType(.Current, StructuredObject).OBID) Then

                                                        lobjMasterDataGraphResults.Add(CType(.Current, StructuredObject))



                                                    End If



                                                End While

                                            End With





                                            If lobjparent1 IsNot Nothing Then

                                                lobjMasterDataGraphResults.AllObjects.Remove(lobjparent1)

                                            End If





                                        Else



                                            mobjAddChildCollection = ProcessTagwithFlag(lobjDataGraphResults, TagRelatedRels, lobjTagObject.UID, tagsCollection, lobjMasterDataGraphResults, lintCount, lStructuredobjcollection, lobjparent, GraphDefUID)



                                        End If



                                    Else



                                        mobjAddChildCollection = ProcessTagwithoutFlag(lobjDataGraphResults, TagRelatedRels, lobjTagObject.UID, tagsCollection, lobjMasterDataGraphResults)

                                    End If

                                    '

                                    ' Adding Extra Rels to Master Collection

                                    '

                                    If mobjAddChildCollection IsNot Nothing Then





                                        With mobjAddChildCollection.GetEnumerator

                                            While .MoveNext

                                                Dim lobjItem As StructuredObject = CType(.Current, StructuredObject)

                                                If Not lobjMasterDataGraphResults.Contains(lobjItem.OBID) Then

                                                    lobjMasterDataGraphResults.Add(lobjItem)

                                                End If



                                            End While

                                        End With

                                    End If





                                    If llstRemovedObjectOBIDs IsNot Nothing Then

                                        For Each llst As String In llstRemovedObjectOBIDs

                                            lobjMasterDataGraphResults.AllObjects.Remove(llst)

                                        Next

                                        llstRemovedObjectOBIDs = Nothing

                                    End If



                                    '

                                    ' Check whether Master collection is not empty

                                    '



                                    If lobjMasterDataGraphResults.Count > 0 Then

                                        mobjDataGraphResults = lobjMasterDataGraphResults

                                    End If

                                End If

                            End If



                            'If tagsCollection.Any = False Then

                            '    Exit Do

                            'End If



                            lintCount = lintCount + 1



                        End If

                        '

                        ' Adding the Tag objects to until same scopelimit is reached

                        '



                        If lintCount <= ScopeLimit Or ScopeLimit = 0 Then



                            If lcolPublishedGraphDict(lintloop) IsNot Nothing Then

                                lcolPublishedGraphDict.Remove(lintloop)

                                lcolPublishedGraphDict.Add(lintloop, CType(lobjMasterDataGraphResults, Object))

                            Else

                                lcolPublishedGraphDict.Add(lintloop, CType(lobjMasterDataGraphResults, Object))

                            End If



                        End If



                        '

                        ' Exist the loop when no Tags are found

                        '

                        If tagsCollection.Any = False Then

                            If (lStructuredobjcollection IsNot Nothing) Then

                                lStructuredobjcollection.AllObjects.Remove(lobjparent)

                                lintloop = lintloop + 1

                                lcolPublishedGraphDict.Add(lintloop, CType(lStructuredobjcollection, Object))



                            End If



                            Exit Do



                        End If



                    Loop While (True)



                    'If lintCount <= ScopeLimit OrElse ScopeLimit = 0 Then

                    '    lcolPublishedGraphDict.Add(lintloop, CType(mobjDataGraphResults, Object))

                    'End If



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

        ''' This Method is called when flag is set false.

        ''' Processing of tags is done irrespective whether the related tag exist in the workpackage are not.

        ''' </summary>

        ''' <param name="pstrDataGraphResults">Structuredobject collection of individual tag.</param>

        ''' <param name="pstrtagrelatedrels">List of TagtoTag Rels.</param>

        ''' <param name="pstrtaguid">UID of CurrentTag</param>

        ''' <param name="pcoltagcollections">List of Tags in workpackage.</param>

        ''' <param name="pstrMasterDataGraphResults">Master collection Store list of objects and its relationship depending up on chunk size once the chunk size reaches maximum value it is reset ( again instantiated).</param>

        ''' <returns></returns>

        ''' <remarks> Created Chandrakanth 12/03/2014 CR-AM-78313 -Inconsistent publishing of SPO authoring and tag to tag rel </remarks>

        ''' <compilewhen>Internal</compilewhen>



        Public Function ProcessTagwithoutFlag(ByVal pstrDataGraphResults As StructuredObjectCollection, pstrtagrelatedrels As String, ByVal pstrTagUID As String, ByRef pcoltagcollections As IObjectDictionary, ByRef pstrMasterDataGraphResults As StructuredObjectCollection) As StructuredObjectCollection



            '

            ' Adding tag to MasterDataGraphResults

            '

            pstrMasterDataGraphResults.AddRange(pstrDataGraphResults)



            '

            ' Store list of TAG-TAG after filtering the method Argument

            '

            Dim llstTagRels As List(Of String) = FilterRels(pstrtagrelatedrels)



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



                Dim lobjChildTag As IObject = Nothing



                Dim lobjItem As IObject = CType(obj.Value, IObject)

                Dim lstrTagObjectUID As String = String.Empty





                If lobjItem.ClassDefinitionUID = "Rel" Then



                    Dim lobjRel As IRel = CType(lobjItem.Interfaces("IRel"), IRel)





                    '

                    ' Check for whether TAG has following realtions in object collection

                    ' TagAssembly

                    ' TagConnection

                    ' EquipmentComponentComposition



                    If (llstTagRels.Contains(lobjRel.DefUID)) Then



                        lstrTagObjectUID = lobjRel.UID1



                        If (lstrTagObjectUID.Equals(pstrTagUID)) Then



                            lstrTagObjectUID = lobjRel.UID2



                        Else



                            lstrTagObjectUID = lobjRel.UID1



                        End If

                        ' Dim tagobjectuiddomain As String = lobjRel.DomainUID2

                        '

                        ' Check whether tag  domainuid of related tag is 'SPOPublish'

                        ' note : need to check Oren/steve do we need handle case for the other domain in such way need to find out what domain can publish the tags

                        'If (tagobjectuiddomain = "SPOPublish") Then

                        '    '

                        '    ' Append "_S" to uid of SPOPublish object

                        '    '

                        '    lstrtagcdwobjectuid = tagobjectuid & "_S"

                        '    '

                        '    ' Querying the Db to get CDW object with uid and domain

                        '    '

                        '    lobjchildtag = SPFRequestContext.Instance.QueryRequest.GetObjectByUIDAndDomain(lstrtagcdwobjectuid, "CDW")

                        'Else



                        '

                        'lobjChildTag = SPFRequestContext.Instance.QueryRequest.GetObjectByUIDAndDomain(lstrTagObjectUID, "SPXAuthoring")

                        'End If



                        '

                        ' Querying the DB to get Authoring Tag

                        '

                        lobjChildTag = SPFRequestContext.Instance.QueryRequest.GetObjectByUIDAndDomain(lstrTagObjectUID, "SPXAuthoring")



                        '

                        ' Store the OBID of the ChildTag

                        '



                        lstrTagOBID = lobjChildTag.OBID





                        '

                        ' Check whether the Tag exist in the  Workpackage

                        '

                        If Not tagsCollection.ContainsByObid(lstrTagOBID) Then

                            '

                            ' Add the tag to Structure object collection

                            '

                            lColChildTagRels.Add(lobjChildTag)

                            SPFRequestContext.Instance.QueryRequest.AddObjectsToExpand(lColChildTagRels)

                            '

                            ' Expanding the GraphDef to get ChlidTag

                            '

                            lColChildTagRels = SPFRequestContext.Instance.QueryRequest.RunByExpandGraphDef(lobjDataGraphDef)



                        Else

                            '

                            ' removing childobject from initial graph since the child tag already exist in the workpackage

                            '

                            ' pstrDataGraphResults.AllObjects.Remove(lobjChildTag)





                            'pstrMasterDataGraphResults.AddRange(pstrDataGraphResults)



                            '

                            ' Remove the child object from the collection to avoid processing it again

                            '

                            If (pcoltagcollections.ContainsByObid(lobjChildTag.OBID)) Then



                                pcoltagcollections.Remove(lobjChildTag.OBID)



                            End If



                            pstrMasterDataGraphResults.AllObjects.Remove(lobjChildTag)



                        End If

                    End If

                End If

            Next

            Return lColChildTagRels

        End Function





        ''' <summary>

        ''' Filters the rels.

        ''' </summary>

        ''' <param name="pstrtagrelatedrels">TAGtoTag specified on SPFArgument11 (WPTagPublishMethod)</param>

        ''' <returns></returns>

        ''' <remarks> Created Chandrakanth 12/03/2014 CR-AM-78313 -Inconsistent publishing of SPO authoring and tag to tag rel </remarks>

        ''' <compilewhen>Internal</compilewhen>

        '''

        Private Function FilterRels(ByVal pstrtagrelatedrels As String) As List(Of String)



            Dim lcolrels() As String = pstrtagrelatedrels.Split(CChar(","))



            Return lcolrels.ToList()

        End Function



        ''' <summary>

        ''' This Method is called when flag is set true.

        ''' Processing of tags is done depending whether it exist in the workpackage or not.

        ''' </summary>

        ''' <param name="pstrDataGraphResults">Structuredobject collection of individual tag</param>

        ''' <param name="pstrTagRels">List of TagtoTag Rels.</param>

        ''' <param name="pstrTagUID">UID of CurrentTag</param>

        ''' <param name="pcolTagsCollection">List of Tags in workpackage.</param>

        ''' <param name="pstrMasterDataGraphResults">Master collection Store list of objects and its relationship depending up on chunk size once the chunk size reaches maximum value it is reset ( again instantiated).</param>

        ''' <param name="lintCount">counter variable to keep track of numbers tags in the each chunk.</param>

        ''' <returns></returns>

        ''' <remarks> Created Chandrakanth 12/03/2014 CR-AM-78313 -Inconsistent publishing of SPO authoring and tag to tag rel </remarks>

        ''' <compilewhen>Internal</compilewhen>



        Public Function ProcessTagwithFlag(ByVal pstrDataGraphResults As StructuredObjectCollection, ByVal pstrTagRels As String, ByVal pstrTagUID As String, ByRef pcolTagsCollection As ObjectDictionary, ByRef pstrMasterDataGraphResults As StructuredObjectCollection, ByRef lintCount As Integer, ByRef lStructuredobjcollection As StructuredObjectCollection, ByRef lobjparenttag As IObject, ByVal pstrGraphDef As String) As StructuredObjectCollection

            '

            ' Adding Tag to MasterDataGraphResults

            '

            ' pstrMasterDataGraphResults.AddRange(pstrDataGraphResults)



            '

            ' Store list of TAG-TAG after filtering the method Argument

            '

            Dim llstTagRels As List(Of String) = FilterRels(pstrTagRels)

            '

            ' Querying the DB to get 'TagPublishExpansion'

            '

            Dim lobjDataGraphDef As IDirectedGraphDef = CType(SPFRequestContext.Instance.ProcessCache.Item(QueryTypes.UID, pstrGraphDef).Interfaces("IDirectedGraphDef"), IDirectedGraphDef)

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

            pstrMasterDataGraphResults.AddRange(pstrDataGraphResults)



            '

            ' Inorder to  avoid traversing all the object like spfplant, spfunit,spfarea, spfsystem, spxtagequipment

            ' better to loop only list of rels

            Dim lcolAllRels = pstrDataGraphResults.AllObjects().Where(Function(x) x.ClassDefinitionUID = "Rel")



            With lcolAllRels.GetEnumerator



                Do While .MoveNext



                    ' Dim lobjItem As IObject = CType(.Current.Interfaces("IRel"), IObject)

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





                    Dim lobjRel As IRel = CType(.Current.Interfaces("IRel"), IRel)

                    '

                    ' Checking whether the rel exists in the Publish method argument -11

                    '

                    If (llstTagRels.Contains(lobjRel.DefUID)) Then

                        '

                        ' Store the OBID of the Rel (TagAssembly,TagConnection,EquipmentComponentComposition)

                        '

                        lstrRelOBID = lobjRel.OBID

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



                        Dim lobjCurrentag As IObject = Nothing



                        lobjCurrentag = SPFRequestContext.Instance.QueryRequest.GetObjectByUIDAndDomain(pstrTagUID, "SPXAuthoring")

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

                        If Not pcolTagsCollection.ContainsByObid(lstrOBIDOfChildTag) And lobjCDWChildTag Is Nothing And (Not llstTraversedObjects.ContainsKey(lobjChildTag.OBID)) Then





                            '

                            ' Since ChildTag doesnt exist in the workpackage, remove ChildTag object and Rel related to it

                            '



                            '

                            ' Same tag can be related to other using different relationship

                            '

                            If pstrMasterDataGraphResults.AllObjects.Contains(lobjChildTag) Then



                                pstrMasterDataGraphResults.AllObjects.Remove(lobjChildTag)



                            End If



                            pstrMasterDataGraphResults.AllObjects.Remove(lobjRel)







                        ElseIf pcolTagsCollection.ContainsByObid(lstrOBIDOfChildTag) Then



                            '

                            ' Both Parent Tag and Child Tag are in the same WorkPackage then expanding the graph on related ChildTagobject

                            '



                            lColChildTagRels.Add(lobjChildTag)

                            SPFRequestContext.Instance.QueryRequest.AddObjectsToExpand(lColChildTagRels)

                            lColChildTagRels = SPFRequestContext.Instance.QueryRequest.RunByExpandGraphDef(lobjDataGraphDef)



                            '

                            ' Remove the child object from the collection to avoid processing it again

                            '



                            Dim lobjdict As New ObjectDictionary

                            lobjdict.Add(lobjChildTag)

                            lobjdict.Add(lobjCurrentag)

                            AdditionalCheck(lColChildTagRels, pcolTagsCollection, lobjdict, llstRemovedObjectOBIDs)

                            pcolTagsCollection.Remove(lobjChildTag.OBID)



                            If Not llstTraversedObjects.ContainsKey(lobjChildTag.OBID) Then

                                llstTraversedObjects.Add(lobjChildTag.OBID, New TraversedObjInfo() With {.UID = lobjChildTag.UID, .Name = lobjChildTag.Name, .DomainUID = lobjChildTag.DomainUID})

                                'llstTraversedObjects.Add(lobjCurrentag.OBID, New TraversedObjInfo() With {.UID = lobjCurrentag.UID, .Name = lobjCurrentag.Name, .DomainUID = lobjCurrentag.DomainUID})

                            End If





                            lintCount = lintCount + 1



                            If lintCount = ScopeLimit And ScopeLimit <> 0 Then

                                '

                                ' Remove child tag from container 1 and its rel tagconnection

                                '

                                pstrMasterDataGraphResults.AllObjects.Remove(lobjChildTag)



                                pstrMasterDataGraphResults.AllObjects.Remove(lobjRel)

                                '

                                ' Structured object collection to maintain ChildTag object so that we can send to another Container

                                '

                                lStructuredobjcollection = New StructuredObjectCollection

                                '

                                ' Querying for original Tag

                                '

                                lobjparenttag = SPFRequestContext.Instance.QueryRequest.GetObjectByUIDAndDomain(pstrTagUID, "SPXAuthoring")



                                lStructuredobjcollection.AddRange(lColChildTagRels)



                                lColChildTagRels = Nothing



                                '

                                ' Decrement the count inorder Limit the number objects in the Container

                                '

                                lintCount = lintCount - 1

                            End If



                            '

                            ' Need to check whether Childtag exist in CDW Domain

                            '

                        ElseIf Not lobjCDWChildTag Is Nothing Then





                            pstrMasterDataGraphResults.AllObjects.Remove(lobjChildTag)



                            ' lColChildTagRels = Nothing





                        End If



                    End If







                Loop

            End With



            '

            ' here we have two scenarios, TAG2 not published  and TAG1 published (viceversa)

            ' if  TAG2 is not present in the workpackage then pstrDataGraphResults collection contain TAG1 and relationship related to it(AreaTag,PlantTag,UnitTag,SystemTag) and viceversa

            ' if TAG2 is already published then pstrDataGraphResults only contains TAG1 and all relationship related to it((AreaTag,PlantTag,UnitTag,SystemTag,TagConnection) and viceversa . this is avoiding reconsolidating the same object one more time

            ' if both TAG  are in same workpackage) is present in Authoring Domain the collection contain Authoring tag and its Relationship(Area,Plant,System,Unit)

            Return lColChildTagRels

        End Function



        Public Sub AdditionalCheck(ByRef lColChildTagRels As StructuredObjectCollection, ByRef pcolTagsCollection As ObjectDictionary, ByVal lobjdict As ObjectDictionary, ByRef llstremoveobid As List(Of String))





            '

            ' get list of Rels

            '

            Dim lcolAllRels = lColChildTagRels.AllObjects().Where(Function(x) x.ClassDefinitionUID = "Rel")



            '

            ' get list of classdefs

            '

            ' Dim lcolClassdef = lColChildTagRels.AllObjects().Where(Function(x) x.ClassDefinitionUID = "SPXTagEquipment")

            Dim lcolClassdef = lColChildTagRels.AllObjects().Where(Function(x) x.Interfaces.Contains("ITaggedItem"))



            '

            ' Dictionary to Store list of object to be removed

            '

            Dim ldictRemovedObjectUIDs As Dictionary(Of String, Boolean) = New Dictionary(Of String, Boolean)

            llstRemovedObjectOBIDs = New List(Of String)





            Dim lblncdwflag As Boolean = False

            With lcolClassdef.GetEnumerator

                Do While .MoveNext

                    Dim lobjClassdefObject As IObject = CType(.Current, IObject)

                    If (Not lobjdict.ContainsByObid(lobjClassdefObject.OBID)) Then



                        Dim lstrCDWUIDOfChildTag As String = lobjClassdefObject.UID & "_Mapped_S"





                        '

                        ' Check  Whether CDW Object exist for Grandchild

                        '

                        Dim lobjGrandChildCDW As IObject = SPFRequestContext.Instance.QueryRequest.GetObjectByUIDAndDomain(lstrCDWUIDOfChildTag, "CDW")





                        If (lobjGrandChildCDW IsNot Nothing) Then

                            '

                            ' Remove Grandchild Object from Child Collection

                            '

                            ldictRemovedObjectUIDs.Add(lobjClassdefObject.UID, True)

                            llstRemovedObjectOBIDs.Add(lobjClassdefObject.OBID)



                            '

                            ' check whether child exist in workpackage

                            '

                        ElseIf (Not pcolTagsCollection.ContainsByObid(lobjClassdefObject.OBID)) Then



                            llstRemovedObjectOBIDs.Add(lobjClassdefObject.OBID)

                            ldictRemovedObjectUIDs.Add(lobjClassdefObject.UID, False)





                        End If





                    End If



                Loop

            End With







            With lcolAllRels.GetEnumerator



                Do While .MoveNext



                    Dim lobjRelObject As IRel = CType(.Current, IRel)

                    '

                    ' Grandhild can be on anyend i.e UID1 or UID2. to know whether Grandchild exist in the CDW, here we are using two boolean flags

                    '

                    Dim lblncdw1 As Boolean = False

                    Dim lblncdw2 As Boolean = False

                    '

                    ' Removing all the rels which are UID1 or UID2 of the  TAG (GrandChild) which doesnt exist in the workpack  and at same time we need to ensure whether object in cdw then we shouldnt remove the Rel

                    '

                    If ldictRemovedObjectUIDs.ContainsKey(lobjRelObject.UID1) Then

                        lblncdw1 = ldictRemovedObjectUIDs.Item(lobjRelObject.UID1)

                        If Not lblncdw1 Then

                            llstRemovedObjectOBIDs.Add(lobjRelObject.OBID)

                        End If



                    ElseIf ldictRemovedObjectUIDs.ContainsKey(lobjRelObject.UID2) Then



                        lblncdw2 = ldictRemovedObjectUIDs.ContainsKey(lobjRelObject.UID2)

                        If Not lblncdw2 Then

                            llstRemovedObjectOBIDs.Add(lobjRelObject.OBID)

                        End If



                    End If



                    'If Not lblncdw1 And Not lblncdw2 Then

                    '    llstRemovedObjectOBIDs.Add(lobjRelObject.OBID)

                    'End If



                Loop



            End With









        End Sub



    End Class







    Class TraversedObjInfo



        Public Property OBID As String

        Public Property UID As String

        Public Property Name As String

        Public Property DomainUID As String



    End Class



End Namespace




