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

        public static string Token
        {
            get { return AppSettings.GetValueOrDefault<string>(TokenKey, TokenDefault); }
            set { AppSettings.AddOrUpdateValue<string>(TokenKey, value); }
        }
    }
}
