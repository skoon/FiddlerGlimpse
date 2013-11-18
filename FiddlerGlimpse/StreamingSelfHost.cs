using System;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Owin;

namespace FiddlerGlimpse
{
    public class StreamingSelfHost : IDisposable
    {

        private string Url = "http://localhost:8090";
        private IDisposable _server;
        public StreamingSelfHost()
        {

        }

        public void Start()
        {
            _server = WebApplication.Start<Startup>(Url);
        }

        public void Stop()
        {
            _server.Dispose();
        }

        public void Dispose()
        {
            _server.Dispose();
        }
    }

    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapConnection<GlimpseConnection>("glimpse");
        }
    }
}