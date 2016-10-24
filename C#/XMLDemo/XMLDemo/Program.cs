
using Microsoft.VisualBasic.CompilerServices;
using SPF.Server;
using SPF.Server.Caching;
using SPF.Server.Components.Core.APIs;
using SPF.Server.Context;
using SPF.Server.QueryEngine;
using SPF.Server.Schema.Collections;
using SPF.Server.Schema.Interface.Generated;
using SPF.Server.Schema.Model;
using SPF.Server.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace SPF.Server.Components.ChangeItems.APIs
{
    public class GetAllDisplayItemsForFormServerAPI : ServerAPI
    {
        private string strFormOBID;

        private string lstrDirection;

        private string lstrAction;

        private string aNodeOBID;

        private IObject lobjItem;

        private int cnt;

        private IObjectDictionary dicDocs;

        private string classofDocUID;

        private SortedList<double, ISPFSection> sectionlist;

        private ArrayList diCtrlCollection;

        private string lstrClassOfDocOBID;

        private IObject aFormIObject;

        private IObject classOfDoc;

        public GetAllDisplayItemsForFormServerAPI()
        {
            this.strFormOBID = "";
            this.lstrDirection = "";
            this.lstrAction = "";
            this.aNodeOBID = "";
            this.lobjItem = null;
            this.cnt = 0;
            this.dicDocs = null;
            this.classofDocUID = "";
            this.diCtrlCollection = null;
            this.lstrClassOfDocOBID = "";
            this.aFormIObject = null;
            this.classOfDoc = null;
        }

        private string _SetRelatedObjectDefaultValues(string pstrDefaultValue)
        {
            string str;
            IObject end1;
            IRelDictionary rels;
            string str1 = pstrDefaultValue;
            IObject obj = null;
            string str2 = "";
            string str3 = "";
            string str4 = "";
            bool flag = true;
            int num = pstrDefaultValue.IndexOf("->");
            if (num > 0)
            {
                str3 = pstrDefaultValue.Substring(checked(num + 2), checked(pstrDefaultValue.IndexOf(".") - (checked(num + 2))));
                if (str3.IndexOf("_12") > 0)
                {
                    flag = true;
                    str3 = str3.Substring(0, str3.IndexOf("_12"));
                }
                else if (str3.IndexOf("_21") > 0)
                {
                    flag = false;
                    str3 = str3.Substring(0, str3.IndexOf("_21"));
                }
            }
            str4 = pstrDefaultValue.Substring(checked(pstrDefaultValue.IndexOf(".") + 1));
            if (num > 0)
            {
                str2 = pstrDefaultValue.Substring(0, num);
            }
            else if (pstrDefaultValue.IndexOf(".") > 0)
            {
                str2 = pstrDefaultValue.Substring(0, pstrDefaultValue.IndexOf("."));
            }
            IClassDef item = null;
            IObject obj1 = null;
            IObject obj2 = null;
            if (Operators.CompareString(this.classOfDoc.get_OBID(), "", false) != 0)
            {
                obj1 = SPFRequestContext.get_Instance().get_ProcessCache().get_QueryRequest().GetObject(0, this.classOfDoc.get_OBID());
                if (obj1 != null)
                {
                    item = (IClassDef)obj1.get_Interfaces().get_Item("IClassDef");
                    item != null;
                }
            }
            if (Operators.CompareString(this.classOfDoc.get_OBID(), "", false) != 0)
            {
                IObject obj3 = SPFRequestContext.get_Instance().get_ProcessCache().get_QueryRequest().GetObject(0, this.classOfDoc.get_OBID());
                if (obj3 != null)
                {
                    obj2 = obj3;
                }
            }
            if (str2.StartsWith("CLASS"))
            {
                obj = obj1;
            }
            else if (str2.StartsWith("CLASSDEF"))
            {
                obj = item;
            }
            else if (str2.StartsWith("PARENT"))
            {
                obj = obj2;
            }
            else if (str2.StartsWith("RELATEDOBJ"))
            {
                obj = obj2;
            }
            if (Operators.CompareString(str3, "", false) != 0 & obj != null)
            {
                if (!flag)
                {
                    rels = obj.GetEnd2Relationships().GetRels(str3);
                    if (rels.Count == 0)
                    {
                        str = "";
                        return str;
                    }
                    end1 = rels.get_Item(0).GetEnd1();
                }
                else
                {
                    rels = obj.GetEnd1Relationships().GetRels(str3);
                    if (rels.Count == 0)
                    {
                        str = "";
                        return str;
                    }
                    end1 = rels.get_Item(0).GetEnd2();
                }
                end1 != null;
                obj = end1;
            }
            if (obj != null)
            {
                IEnumerator<IInterface> enumerator = obj.get_Interfaces().GetEnumerator();
                while (enumerator.MoveNext())
                {
                    IInterface current = enumerator.Current;
                    if (current.get_Properties().Contains(str4))
                    {
                        str1 = current.get_Properties().get_Item(str4).get_Value().ToString();
                        break;
                    }
                }
                enumerator = null;
            }
            str = str1;
            return str;
        }

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

        private ArrayList GetAllDisplayItemsForForm(SortedList<double, ISPFSection> formSectionDictionary)
        {
            ArrayList arrayLists = new ArrayList();
            IEnumerator<ISPFSection> enumerator = formSectionDictionary.Values.GetEnumerator();
            while (enumerator.MoveNext())
            {
                ISPFSection current = enumerator.Current;
                current.GetDisplayItems();
                IEnumerator<ISPFDisplayItem> enumerator1 = this.GetSortedDisplayItems(current).Values.GetEnumerator();
                while (enumerator1.MoveNext())
                {
                    ISPFDisplayItem sPFDisplayItem = enumerator1.Current;
                    DisplayItemControl displayItemControl = new DisplayItemControl()
                    {
                        di = sPFDisplayItem
                    };
                    if (current.get_SPFLocateInTab() != null)
                    {
                        displayItemControl.SPFLocateInTab = current.get_SPFLocateInTab();
                    }
                    displayItemControl.relToSection = current.GetEnd1Relationships().GetRel("SPFSectionDisplayItem", sPFDisplayItem.get_UID());
                    if (displayItemControl.relToSection.get_Interfaces().get_Item("ISPFSectionDisplayItem").get_Properties().get_Item("SPFMandatoryInd") != null)
                    {
                        displayItemControl.isRequired = displayItemControl.relToSection.get_Interfaces().get_Item("ISPFSectionDisplayItem").get_Properties().get_Item("SPFMandatoryInd").get_Value().ToString();
                    }
                    if (displayItemControl.relToSection.get_Interfaces().get_Item("ISPFSectionDisplayItem").get_Properties().get_Item("SPFReadOnlyInd") != null)
                    {
                        displayItemControl.SPFReadOnlyInd = displayItemControl.relToSection.get_Interfaces().get_Item("ISPFSectionDisplayItem").get_Properties().get_Item("SPFReadOnlyInd").get_Value().ToString();
                    }
                    if (sPFDisplayItem.GetEnd1Relationships().GetRel("SPFDisplayItemPropertyDef") != null)
                    {
                        IPropertyDef item = (IPropertyDef)sPFDisplayItem.GetEnd1Relationships().GetRel("SPFDisplayItemPropertyDef").GetEnd2().get_Interfaces().get_Item("IPropertyDef");
                        IPropertyType propertyType = (IPropertyType)item.GetEnd1Relationships().GetRel("ScopedBy").GetEnd2().get_Interfaces().get_Item("IPropertyType");
                    }
                    arrayLists.Add(displayItemControl);
                }
                enumerator1 = null;
            }
            enumerator = null;
            return arrayLists;
        }

        private SortedList<double, ISPFSection> GetCreateSections(IObject aFormIObject)
        {
            SortedList<double, ISPFSection> nums = new SortedList<double, ISPFSection>();
            string str = "";
            ISPFSection item = null;
            ISPFForm sPFForm = null;
            IRelDictionary rels = null;
            try
            {
                sPFForm = (ISPFForm)aFormIObject.get_Interfaces().get_Item("ISPFForm");
                rels = sPFForm.GetEnd1Relationships().GetRels("SPFFormSection");
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                ProjectData.ClearProjectError();
            }
            IObjectEnumerator enumerator = rels.GetEnumerator();
            while (enumerator.MoveNext())
            {
                IObject value = enumerator.get_Value();
                IRel rel = (IRel)value.get_Interfaces().get_Item("IRel");
                item = (ISPFSection)rel.GetEnd2().get_Interfaces().get_Item("ISPFSection");
                double orderValue = (double)rel.get_OrderValue();
                if (item.GetFormPurposes().Contains("FP_Create"))
                {
                    while (nums.ContainsKey(orderValue))
                    {
                        orderValue = orderValue + 0.1;
                    }
                    nums.Add(orderValue, item);
                }
            }
            enumerator = null;
            string.IsNullOrEmpty(str);
            return nums;
        }

        private SortedList<int, ISPFDisplayItem> GetSortedDisplayItems(ISPFSection section)
        {
            ISPFDisplayItem item = null;
            int orderValue = 0;
            SortedList<int, ISPFDisplayItem> nums = new SortedList<int, ISPFDisplayItem>();
            string str = "";
            try
            {
                IEnumerator enumerator = section.GetEnd1Relationships().GetRels("SPFSectionDisplayItem").Values.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    IObject current = (IObject)enumerator.Current;
                    IRel rel = (IRel)current.get_Interfaces().get_Item("IRel");
                    orderValue = rel.get_OrderValue();
                    item = (ISPFDisplayItem)rel.GetEnd2().get_Interfaces().get_Item("ISPFDisplayItem");
                    nums.Add(orderValue, item);
                }
                enumerator = null;
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                nums.Add(checked(orderValue + 1), item);
                ProjectData.ClearProjectError();
            }
            string.IsNullOrEmpty(str);
            return nums;
        }

        protected override void OnDeSerialize()
        {
            XMLRequestHelper xMLRequestHelper = new XMLRequestHelper();
            try
            {
                this.strFormOBID = xMLRequestHelper.XMLSelectSingleNode("strFormOBID").InnerText;
                this.lstrClassOfDocOBID = xMLRequestHelper.XMLSelectSingleNode("classOfDocOBID").InnerText;
                this.classofDocUID = xMLRequestHelper.XMLSelectSingleNode("classofDocUID").InnerText;
                this.aFormIObject = SPFRequestContext.get_Instance().get_ProcessCache().get_QueryRequest().GetObject(0, this.strFormOBID);
                this.classOfDoc = SPFRequestContext.get_Instance().get_ProcessCache().get_QueryRequest().GetObject(0, this.lstrClassOfDocOBID);
                if (this.aFormIObject == null | this.classOfDoc == null)
                {
                    throw new Exception("Could not query the server.");
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                throw new SPFException((long)1329, "There was an error in ServerAPI", exception);
            }
        }

        protected override void OnHandlerBody()
        {
            try
            {
                this.sectionlist = this.GetCreateSections(this.aFormIObject);
                this.diCtrlCollection = this.GetAllDisplayItemsForForm(this.sectionlist);
                this.CreateFormBasedOnDisplayItemCollection(ref this.diCtrlCollection);
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                throw new SPFException((long)1329, "There was an error ServerAPI", exception);
            }
        }

        protected override void OnSerialize()
        {
            IEnumerator enumerator = null;
            try
            {
                XmlElement xmlElement = (XmlElement)SPFRequestContext.get_Instance().get_Response().AppendChild(SPFRequestContext.get_Instance().get_Response().CreateElement("Reply"));
                XmlElement xmlElement1 = (XmlElement)xmlElement.AppendChild(SPFRequestContext.get_Instance().get_Response().CreateElement("Form"));
                xmlElement1.SetAttribute("Name", this.aFormIObject.get_Name());
                xmlElement1.SetAttribute("Classification", string.Concat(this.classOfDoc.get_Name(), ", ", this.classOfDoc.get_Description()));
                xmlElement1.SetAttribute("Desciption", "");
                xmlElement1.SetAttribute("UserPreference", "");
                try
                {
                    enumerator = this.diCtrlCollection.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DisplayItemControl current = (DisplayItemControl)enumerator.Current;
                        XmlElement xmlElement2 = (XmlElement)xmlElement1.AppendChild(SPFRequestContext.get_Instance().get_Response().CreateElement("DisplayItem"));
                        DisplayItemControl displayItemControl = current;
                        xmlElement2.SetAttribute("UID", displayItemControl.di.get_UID());
                        xmlElement2.SetAttribute("OBID", displayItemControl.di.get_OBID());
                        xmlElement2.SetAttribute("DisplayAs", displayItemControl.DisplayAs);
                        xmlElement2.SetAttribute("isRequired", displayItemControl.isRequired);
                        xmlElement2.SetAttribute("DisplayItemType", displayItemControl.DisplayItemType);
                        xmlElement2.SetAttribute("propertyScopedBy", displayItemControl.propertyScopedBy);
                        xmlElement2.SetAttribute("isDependsOn", displayItemControl.isDependsOn);
                        xmlElement2.SetAttribute("relDependsOn", displayItemControl.relDependsOn);
                        xmlElement2.SetAttribute("isDependentItem", displayItemControl.isDependentItem);
                        xmlElement2.SetAttribute("relDependentItemTo", displayItemControl.relDependentItemTo);
                        xmlElement2.SetAttribute("relatedObjectUID", displayItemControl.relatedObjectUID);
                        xmlElement2.SetAttribute("SPFDefaultValue", displayItemControl.SPFDefaultValue);
                        xmlElement2.SetAttribute("SPFPropertyPicture", displayItemControl.SPFPropertyPicture);
                        xmlElement2.SetAttribute("SPFSizeOfField", displayItemControl.SPFSizeOfField);
                        xmlElement2.SetAttribute("propertyName", displayItemControl.propertyName);
                        xmlElement2.SetAttribute("SPFReadOnlyInd", displayItemControl.SPFReadOnlyInd);
                        xmlElement2.SetAttribute("SPFOverrideDisplayType", displayItemControl.di.get_SPFOverrideDisplayType());
                        xmlElement2.SetAttribute("SPFLocateInTab", displayItemControl.SPFLocateInTab);
                        displayItemControl = null;
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
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                throw new SPFException((long)1441, "Unable to OnSerialize", exception);
            }
        }
    }
}