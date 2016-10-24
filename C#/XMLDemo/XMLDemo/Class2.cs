 private void CreateFormBasedOnDisplayItemCollection(ref ArrayList diCtrlCollection)
        {
            IEnumerator enumerator = null;
            IEnumerator enumerator1 = null;
            IEnumerator enumerator2 = diCtrlCollection.GetEnumerator();
            while (enumerator2.MoveNext())
            {
                DisplayItemControl current = (DisplayItemControl)enumerator2.Current;
                current.DisplayAs = current.di.get_Interfaces().get_Item("ISPFGUIDisplay").get_Properties().get_Item("SPFGUIDisplayAs").get_Value().ToString();
                current.DisplayItemType = current.di.get_SPFDisplayItemType();
                current.SPFPropertyPicture = current.di.get_SPFPropertyPicture();
                current.SPFSizeOfField = current.di.get_SPFSizeOfField().ToString();
                if (!string.IsNullOrEmpty(current.di.get_SPFDefaultValue()))
                {
                    current.SPFDefaultValue = this._SetRelatedObjectDefaultValues(current.di.get_SPFDefaultValue());
                    current.SPFDefaultValue = GeneralUtilities.ReplaceConstantValues(current.SPFDefaultValue);
                }
                if (Operators.CompareString(current.DisplayItemType, "e1PropertyDef", false) == 0)
                {
                    IPropertyDef item = (IPropertyDef)current.di.GetEnd1Relationships().GetRel("SPFDisplayItemPropertyDef").GetEnd2().get_Interfaces().get_Item("IPropertyDef");
                    IPropertyType propertyType = (IPropertyType)item.GetEnd1Relationships().GetRel("ScopedBy").GetEnd2().get_Interfaces().get_Item("IPropertyType");
                    if (propertyType.get_Interfaces().Contains("IEnumListType"))
                    {
                        current.propertyScopedBy = "EnumListType";
                        current.isDependentItem = "True";
                        if (propertyType.GetEnd1Relationships().GetRels("BaseEnumListForEnumLevel") != null)
                        {
                            try
                            {
                                enumerator = propertyType.GetEnd1Relationships().GetRels("BaseEnumListForEnumLevel").GetEnd2s().Values.GetEnumerator();
                                while (enumerator.MoveNext())
                                {
                                    IObject obj = (IObject)enumerator.Current;
                                    IObject item1 = obj.GetEnd2Relationships().GetRels("ScopedBy").GetEnd1s().get_Item(0);
                                    IObject obj1 = item1.GetEnd2Relationships().GetRels("SPFDisplayItemPropertyDef").GetEnd1s().get_Item(0);
                                    if (Operators.CompareString(current.relDependentItemTo, "", false) != 0)
                                    {
                                        current.relDependentItemTo = string.Concat(current.relDependentItemTo, ",", obj1.get_OBID());
                                    }
                                    else
                                    {
                                        current.relDependentItemTo = obj1.get_OBID();
                                    }
                                }
                            }
                            finally
                            {
                                if (enumerator is IDisposable)
                                {
                                    (enumerator as IDisposable).Dispose();
                                }
                            }
                        }
                    }
                    else if (propertyType.get_Interfaces().Contains("IEnumListLevelType"))
                    {
                        current.propertyScopedBy = "EnumListLevelType";
                        if (propertyType.GetEnd2Relationships().GetRels("BaseEnumListForEnumLevel") != null)
                        {
                            current.isDependsOn = "True";
                            IObject item2 = propertyType.GetEnd2Relationships().GetRels("BaseEnumListForEnumLevel").GetEnd1s().get_Item(0).GetEnd2Relationships().GetRels("ScopedBy").GetEnd1s().get_Item(0);
                            IObject obj2 = item2.GetEnd2Relationships().GetRels("SPFDisplayItemPropertyDef").GetEnd1s().get_Item(0);
                            current.relDependsOn = obj2.get_UID();
                        }
                    }
                    else if (!propertyType.get_Interfaces().Contains("IYMDType"))
                    {
                        current.propertyScopedBy = "string";
                    }
                    else
                    {
                        current.propertyScopedBy = "YMD";
                    }
                    current.propertyName = item.get_Name();
                    current.relatedObjectUID = item.get_Name();
                }
                if (Operators.CompareString(current.DisplayItemType, "e1RelDef", false) == 0)
                {
                    IRelDictionary rels = current.di.GetEnd1Relationships().GetRels("SPFDisplayItemDependentItem");
                    IRelDictionary relDictionary = current.di.GetEnd2Relationships().GetRels("SPFDisplayItemDependentItem");
                    if (rels.Count > 0)
                    {
                        current.isDependentItem = "True";
                        try
                        {
                            enumerator1 = rels.GetEnd2s().Values.GetEnumerator();
                            while (enumerator1.MoveNext())
                            {
                                IObject current1 = (IObject)enumerator1.Current;
                                if (Operators.CompareString(current.relDependentItemTo, "", false) != 0)
                                {
                                    current.relDependentItemTo = string.Concat(current.relDependentItemTo, ",", current1.get_OBID());
                                }
                                else
                                {
                                    current.relDependentItemTo = current1.get_OBID();
                                }
                            }
                        }
                        finally
                        {
                            if (enumerator1 is IDisposable)
                            {
                                (enumerator1 as IDisposable).Dispose();
                            }
                        }
                    }
                    if (relDictionary.Count > 0)
                    {
                        current.isDependsOn = "True";
                        current.relDependsOn = relDictionary.GetEnd1s().get_Item(0).get_UID();
                    }
                    current.relatedObjectUID = current.di.GetEnd1Relationships().GetRels("SPFDisplayItemRelDef").get_Item(0).get_UID2();
                }
                if (Operators.CompareString(current.DisplayItemType, "e1EdgeDef", false) == 0)
                {
                    current.relatedObjectUID = current.di.GetEnd1Relationships().GetRels("SPFDisplayItemEdgeDef").get_Item(0).get_UID2();
                }
            }
            enumerator2 = null;
        }
