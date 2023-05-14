using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RevopointScanAutomation.Properties;

namespace RevopointScanAutomation
{
    internal static class SettingsManager
    {
        private const string SettingPrefix = "SavedValue_";

        public static string GetTextValue(string controlName)
        {
            string settingName = GetSettingName(controlName);
            return Properties.Settings.Default[settingName]?.ToString();
        }

        public static int GetIntValue(string controlName)
        {
            int defaultValue = 0; // Set a default value in case the property doesn't exist

            string settingName = GetSettingName(controlName);

            // Check if the property name exists in the settings
            if (Properties.Settings.Default.Properties[settingName] != null)
            {
                // Retrieve the integer value of the property
                int integerValue = (int)Properties.Settings.Default[settingName];
                return integerValue;
            }

            // Return the default value if the property doesn't exist
            return defaultValue;

        }

        public static void SaveTextValue(string controlName, string value)
        {
            string settingName = GetSettingName(controlName);
            Properties.Settings.Default[settingName] = value;
            Properties.Settings.Default.Save();
        }

        public static void SaveIntValue(string controlName, int value)
        {
            string settingName = GetSettingName(controlName);
            Properties.Settings.Default[settingName] = value;
            Properties.Settings.Default.Save();
        }

        private static string GetSettingName(string controlName)
        {
            return SettingPrefix + controlName;
        }

    }
}
