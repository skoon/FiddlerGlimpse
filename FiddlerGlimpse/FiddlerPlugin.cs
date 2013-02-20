using System;
using Fiddler;

namespace FiddlerGlimpse
{
    public class FiddlerPlugin : IAutoTamper
    {
        private StreamingSelfHost _server;
        public void AutoTamperRequestAfter(Session oSession)
        {

        }

        public void AutoTamperRequestBefore(Session oSession)
        {
            //noop
        }

        public void AutoTamperResponseAfter(Session oSession)
        {

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
        }

        private void TellGlimpse()
        {
            //need to filter out our own packets based on the x-header the 
            //WebAPi controller sends down the pipe
        }
    }
}