using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORS.net_HttpModule.Congifuration
{
    public class CorsConfig : ConfigurationSection
    {
        public static CorsConfig GetConfig()
        {
            return (CorsConfig)System.Configuration.ConfigurationManager.GetSection("cors") ?? new CorsConfig();
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
