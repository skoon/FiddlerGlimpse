using System;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hosting;

namespace FiddlerGlimpse
{
    public class GlimpseConnection : PersistentConnection
    {

        protected override Task OnConnected(IRequest request, string connectionId)
        {
            return Connection.Broadcast("Connection " + connectionId + " connected");
        }

        protected override Task OnDisconnected(IRequest request, string connectionId)
        {
            return base.OnDisconnected(request, connectionId);
        }

        public override Task ProcessRequest(HostContext context)
        {
            return base.ProcessRequest(context);
        }
    }
}
