Public Class Class2


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

End Class
