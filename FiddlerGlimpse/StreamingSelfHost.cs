using System;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace FiddlerGlimpse
{
    public class StreamingSelfHost
    {

        public StreamingSelfHost()
        {
            var config = new HttpSelfHostConfiguration("http://localhost:8080");

            config.Routes.MapHttpRoute(
                "FiddlerGlimpse", "fiddlerGlimpse/fiddler/",
                new { id = RouteParameter.Optional });

            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();

            }
        }
    }
}
