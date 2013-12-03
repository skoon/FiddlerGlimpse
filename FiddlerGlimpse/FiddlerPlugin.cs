using System;
using System.Reflection;
using Fiddler;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Infrastructure;


namespace FiddlerGlimpse
{
    public class FiddlerPlugin : IAutoTamper, IDisposable
    {
        private StreamingSelfHost _server;

        public FiddlerPlugin()
        {
            LoadRequiredAssemblies();
        }

        public StreamingSelfHost _Server
        {
            get
            {
                if (_server == null)
                {
                    _server = StreamingSelfHost.Instance;
                    _Server.Start();
                }
                return _server;
            }
        }
        public void AutoTamperRequestAfter(Session oSession)
        {
            var chat = new GlimpseChatter
            {
                URL = oSession.fullUrl,
                IP = oSession.clientIP,
                IsRequest = true,
                Body = oSession.GetRequestBodyAsString()
            };
            TellGlimpse(chat);
        }

        public void AutoTamperRequestBefore(Session oSession)
        {
            //noop
        }

        public void AutoTamperResponseAfter(Session oSession)
        {
            //need to filter out our own packets based on the x-header
            //we send down the pipe
            var chat = new GlimpseChatter
            {
                URL = oSession.fullUrl,
                IP = oSession.clientIP,
                IsRequest = false,
                Body = oSession.GetResponseBodyAsString()
            };
            //TellGlimpse(chat);
        }

        public void AutoTamperResponseBefore(Session oSession)
        {
            //noop
        }

        public void OnBeforeReturningError(Session oSession)
        {
            //Tell Glimpse
        }

        public void OnBeforeUnload()
        {
            _Server.Stop();
        }

        public void OnLoad()
        {
            _server = StreamingSelfHost.Instance;
            _Server.Start();
        }

        private void TellGlimpse(GlimpseChatter chatter)
        {
            _Server.TalkToGlimpse(chatter);
        }

        public void Dispose()
        {
            if (_Server != null)
            {
                _server = null;
            }
        }
        public void LoadRequiredAssemblies()
        {
            var farts = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
            foreach (var asm in farts)
            {
                AppDomain.CurrentDomain.Load(asm);
            }
        }
    }
}