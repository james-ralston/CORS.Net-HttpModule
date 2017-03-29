using System.Configuration;

namespace CORS.net_HttpModule.Configuration
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

        [ConfigurationProperty("allowOptions", IsRequired = false)]
        public string AllowOptions
        {
            get
            {
                return this["allowOptions"] as string;
            }
        }

        [ConfigurationProperty("allowHeaders", IsRequired = false)]
        public string AllowHeaders
        {
            get
            {
                return this["allowHeaders"] as string;
            }
        }


    }
}
