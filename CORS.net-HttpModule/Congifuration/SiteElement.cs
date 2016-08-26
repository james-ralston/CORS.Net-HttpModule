using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORS.net_HttpModule.Congifuration
{
    public class Site : ConfigurationElement
    {

        [ConfigurationProperty("url", IsRequired = true)]
        public string Url
        {
            get
            {
                return this["url"] as string;
            }
        }

        [ConfigurationProperty("verbs", IsRequired = true)]
        public string Verbs
        {
            get
            {
                return this["verbs"] as string;
            }
        }

        [ConfigurationProperty("allowCredentials", IsRequired = false)]
        public string AllowCredentials
        {
            get
            {
                return this["allowCredentials"] as string;
            }
        }
    }
}
