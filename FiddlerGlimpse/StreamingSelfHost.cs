using System;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin.Hosting;
using Owin;


namespace FiddlerGlimpse
{
    public class StreamingSelfHost : IDisposable
    {
        private readonly static Lazy<StreamingSelfHost> _instance = new Lazy<StreamingSelfHost>(() => new StreamingSelfHost(GlobalHost.ConnectionManager.GetHubContext<FiddlerHub>().Clients));

        private StreamingSelfHost(IHubConnectionContext clients)
        {
            Clients = clients;
        }

        private readonly IHubConnectionContext Clients;

        private IDisposable Server;
        // Should probably move this to configuration,
        // but really since it's running in a system proxy
        // who cares?
        public const string Url = "http://localhost:8080";

        public void Start()
        {
            Server = WebApp.Start<Startup>(Url);
        }

        public void Stop()
        {
            //Server.Dispose();

        }

        public static StreamingSelfHost Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public void Dispose()
        {
            Server.Dispose();
        }

        public void TalkToGlimpse(GlimpseChatter message)
        {
            Clients.All.addMessage("packet", message);
        }

    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }

    public class FiddlerHub : Hub
    {

        public void TalkToGlimpse(GlimpseChatter message)
        {
            Clients.All.addMessage("packet", message);
        }
    }
}
