using System;
using Fiddler;
using Microsoft.AspNet.SignalR;

namespace FiddlerGlimpse
{
    public class FiddlerPlugin : IAutoTamper, IDisposable
    {
        private StreamingSelfHost _server;
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
            var chat = new GlimpseChatter
            {
                URL = oSession.fullUrl,
                IP = oSession.clientIP,
                IsRequest = false,
                Body = oSession.GetResponseBodyAsString()
            };
            TellGlimpse(chat);
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
            _server.Stop();
            _server.Dispose();
        }

        public void OnLoad()
        {
            _server = new StreamingSelfHost();
            _server.Start();
            ConnectToHub();
        }

        private void ConnectToHub()
        {
            var connection = new HubConnection(StreamingSelfHost.Url);
        }

        private void TellGlimpse(GlimpseChatter chatter)
        {
            //need to filter out our own packets based on the x-header
            //we send down the pipe
            
        }
        public void Dispose()
        {
            if (_server != null)
            {
                _server.Dispose();
                _server = null;
            }
        }
    }
}