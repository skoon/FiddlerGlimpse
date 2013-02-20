using System;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace FiddlerGlimpse
{
    public class StreamingSelfHost : IDisposable
    {
        private HttpSelfHostServer _server;

        public StreamingSelfHost()
        {
            var config = new HttpSelfHostConfiguration("http://localhost:8080");

            config.Routes.MapHttpRoute(
                "FiddlerGlimpse", "fiddlerGlimpse/fiddler/",
                new { id = RouteParameter.Optional });

            _server = new HttpSelfHostServer(config);

        }

        public void Start()
        {
            _server.OpenAsync().Wait();
        }

        public void Stop()
        {
            _server.CloseAsync().Wait();
        }

        public void Dispose()
        {
            _server.Dispose();
        }
    }
}
