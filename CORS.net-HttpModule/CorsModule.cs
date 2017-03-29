using System;
using System.Web;
using CORS.net_HttpModule.Configuration;

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
            response.Headers.Remove("Access-Control-Allow-Origin");
            response.Headers.Remove("Access-Control-Allow-Methods");
            response.Headers.Remove("Access-Control-Allow-Credentials");
            response.Headers.Remove("Access-Control-Allow-Headers");

            Site site = CheckCors(origin);

            if (site != null)
            {
                
                response.AddHeader("Access-Control-Allow-Origin", site.Url);
                response.AddHeader("Access-Control-Allow-Methods", site.Verbs);
                
                if (!String.IsNullOrWhiteSpace(site.AllowCredentials))
                {
                    response.AddHeader("Access-Control-Allow-Credentials", site.AllowCredentials);
                   
                }
                if (!String.IsNullOrWhiteSpace(site.AllowHeaders))
                {
                    response.AddHeader("Access-Control-Allow-Headers", site.AllowHeaders);

                }
                if (application.Context.Request.HttpMethod == "OPTIONS" && !String.IsNullOrWhiteSpace(site.AllowOptions))
                {
                    bool allowOptions;
                
                    if (bool.TryParse(site.AllowOptions, out allowOptions) && allowOptions)
                    {
                        response.AddHeader("Allow", site.Verbs);
                    }
                    response.End();
                   
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
