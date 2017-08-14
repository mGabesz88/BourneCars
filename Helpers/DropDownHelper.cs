using System;
using System.Collections.Generic;
using System.Xml.XPath;
using System.Web.Mvc;
using System.Web.Configuration;
using BourneCars.Helpers;

namespace BourneCars.Helpers
{
    public class DropDownHelper
    {
        public static List<SelectListItem> GetPreValuesFromDataTypeId(int dataTypeId)
        {
            List<SelectListItem> preValueSelectorList = new List<SelectListItem>();

            XPathNodeIterator iterator = umbraco.library.GetPreValues(dataTypeId);
            iterator.MoveNext();
            XPathNodeIterator preValues = iterator.Current.SelectChildren("preValue", "");

            while (preValues.MoveNext())
            {
                string preValueIdAsString = preValues.Current.GetAttribute("id", "");
                int preValueId = 0;
                int.TryParse(preValueIdAsString, out preValueId);
                string preValue = preValues.Current.Value;
                preValueSelectorList.Add(new SelectListItem { Value = preValue, Text = preValue });
            }

            return preValueSelectorList;
        }

        public  List<SelectListItem> GetPreValuesFromAppSettingName(string appSettingName)
        {
            int dataTypeId = AppSettingsHelper.GetIntFromAppSetting(appSettingName);
            List<SelectListItem> preValues = GetPreValuesFromDataTypeId(dataTypeId);
            return preValues;
        }
    }
}



