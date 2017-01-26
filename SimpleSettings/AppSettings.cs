using System.Configuration;

namespace SimpleSettings
{
    public static class AppSettings
    {
        public static AppSetting Get(string key) => new AppSetting(key, ConfigurationManager.AppSettings[key]);
    }
}