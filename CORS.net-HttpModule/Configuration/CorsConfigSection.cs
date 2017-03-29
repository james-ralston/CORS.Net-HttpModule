using System;
using System.Configuration;

namespace CORS.net_HttpModule.Configuration
{
    public class CorsConfig : ConfigurationSection
    {
        public static CorsConfig GetConfig()
        {
            return (CorsConfig)ConfigurationManager.GetSection("cors") ?? new CorsConfig();
        }

        [System.Configuration.ConfigurationProperty("sites")]
        [ConfigurationCollection(typeof(Sites), AddItemName = "site")]
        public Sites Sites
        {
            get
            {
                object o = this["sites"];
                return o as Sites;
            }
        }
    }
}
