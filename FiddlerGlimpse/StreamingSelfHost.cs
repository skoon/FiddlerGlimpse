using System;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Owin;

namespace FiddlerGlimpse
{
    public class StreamingSelfHost : IDisposable
    {

        private string Url = "http://localhost:8080";
        public StreamingSelfHost()
        {

        }

        public void Start()
        {


            using (WebApplication.Start<Startup>(Url))
            {
                Console.WriteLine("Server running on {0}", Url);
                Console.ReadLine();
            }

        }

        public void Stop()
        {

        }

        public void Dispose()
        {

        }
    }

    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // This will map out to http://localhost:8080/signalr by default
            app.MapHubs();
        }
    }
}
