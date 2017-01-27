using System.Configuration;

namespace SimplerSettings
{
    public static class AppSettings
    {
        public static AppSetting Get(string key) =>
            new AppSetting(key, ConfigurationManager.AppSettings[key]);
    }
}