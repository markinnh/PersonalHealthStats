using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PersonalHealthStats.Models
{
    public class StoredSetting
    {
        public int StoredSettingID { get; set; }
        [MaxLength(Constants.MaxSettingLength)]
        public string SettingName { get; set; }
        [MaxLength(Constants.MaxSettingLength)]
        public string SettingValue { get; set; }

        public static implicit operator bool(StoredSetting setting)
        {
            if (bool.TryParse(setting.SettingValue, out bool result))
            {
                return result;
            }
            else
                return default(bool);
        }
        public static implicit operator int(StoredSetting setting)
        {
            if (int.TryParse(setting.SettingValue, out int result))
            {
                return result;
            }
            else
                return default(int);
        }
        public static implicit operator string(StoredSetting setting)
        {
            return setting.SettingValue;
        }

        public static implicit operator DateTime(StoredSetting setting)
        {
            if (DateTime.TryParse(setting.SettingValue, out DateTime result))
            {
                return result;
            }
            else
                return Constants.MinimumDate;
        }

        public static implicit operator double(StoredSetting setting)
        {
            if (double.TryParse(setting.SettingValue, out double result))
            {
                return result;
            }
            else
                return default(double);
        }

        internal void SetValue(object value)
        {
            SettingValue = value.ToString();
        }

        internal static StoredSetting[] GetStoredSettings()
        {
            var settings = new StoredSetting[]
            {
                new StoredSetting(){SettingName=Constants.TestDataStored,SettingValue = "false"},
                new StoredSetting(){SettingName=Constants.ActiveOwnerName,SettingValue = string.Empty}

            };
            return settings;
            //throw new NotImplementedException();
        }
    }
}
