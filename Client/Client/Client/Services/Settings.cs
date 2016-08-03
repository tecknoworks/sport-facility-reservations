using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        const string TokenKey = "Token";
        private static readonly string TokenDefault = string.Empty;
        const string StatusKey = "Status";
        private static readonly bool StatusDefault = false;
        const string FirstNameKey = "FirstName";
        private static readonly string FirstNameDefault = string.Empty;

        public static string Token
        {
            get { return AppSettings.GetValueOrDefault<string>(TokenKey, TokenDefault); }
            set { AppSettings.AddOrUpdateValue<string>(TokenKey, value); }
        }

        public static bool Status
        {
            get { return AppSettings.GetValueOrDefault<bool>(StatusKey, StatusDefault); }
            set { AppSettings.AddOrUpdateValue<bool>(StatusKey, value); }
        }
        public static string FirstName
        {
            get { return AppSettings.GetValueOrDefault<string>(FirstNameKey, FirstNameDefault); }
            set { AppSettings.AddOrUpdateValue<string>(FirstNameKey, value); }
        }
    }
}
