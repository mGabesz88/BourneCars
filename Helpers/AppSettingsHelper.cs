using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace BourneCars.Helpers
{
    public class AppSettingsHelper
    {
        private const string APP_SETTING_ERROR_MESSAGE = "Invalid or missing appSetting, ";


        public static int GetIntFromAppSetting(string appSettingName)
        {
            int intValue = 0;
            string setting = GetStringFromAppSetting(appSettingName);
            if (!Int32.TryParse(setting, out intValue))
            {
                throw new Exception(APP_SETTING_ERROR_MESSAGE + appSettingName);
            }
            return intValue;
        }

        public static string GetStringFromAppSetting(string appSettingName)
        {
            string setting = WebConfigurationManager.AppSettings[appSettingName] as string;
            if (String.IsNullOrEmpty(setting))
            {
                throw new Exception(APP_SETTING_ERROR_MESSAGE + appSettingName);
            }
            return setting;
        }
    }
}