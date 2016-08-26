using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Web.Configuration;
using CORS.net_HttpModule.Congifuration;

namespace CORS.net_HttpModule
{
    public class CorsModule : IHttpModule
    {
        public void Init(HttpApplication application)
        {
            application.BeginRequest += ApplicationOnBeginRequest;
        }

        private void ApplicationOnBeginRequest(object sender, EventArgs eventArgs)
        {
            var application = (HttpApplication)sender;
            var response = application.Context.Response;
            var origin = application.Context.Request.Headers["Origin"];

            Site site = CheckCors(origin);

            if (site != null)
            {
                response.AddHeader("Access-Control-Allow-Origin", site.Url);
                response.AddHeader("Access-Control-Allow-Methods", site.Verbs);
                if (!String.IsNullOrWhiteSpace(site.AllowCredentials))
                {
                    response.AddHeader("Access-Control-Allow-Credentials", "true");
                }
            }

        }

        private static Site CheckCors(string origin)
        {
            try
            {
                var config = CorsConfig.GetConfig();

                foreach (Site site in config.Sites)
                {
                    if (site.Url == origin)
                    {
                        return site;
                    }
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        public void Dispose()
        {
        }
    }
}
