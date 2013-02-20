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
            //need to pull from config or Fiddler settings
            var config = new HttpSelfHostConfiguration("http://localhost:8080");

            config.Routes.MapHttpRoute(
                "FiddlerGlimpse", "fiddlerGlimpse/fiddler/");

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
