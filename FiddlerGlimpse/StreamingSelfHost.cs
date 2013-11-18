using System;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Owin;

namespace FiddlerGlimpse
{
    public class StreamingSelfHost : IDisposable
    {

        // Should probably move this to configuration,
        // but really since it's running in a system proxy
        // who cares?
        public const string Url = "http://localhost:8080"; 

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
            app.MapSignalR();
        }
    }

    public class FiddlerHub : Hub
    {

        public void Send(GlimpseChatter message)
        {
            Clients.All.addMessage("packet", message);
        }
    }
}
