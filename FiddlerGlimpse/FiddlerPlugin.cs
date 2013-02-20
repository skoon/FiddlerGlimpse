using System;
using Fiddler;



namespace FiddlerGlimpse
{
    public class FiddlerPlugin : IAutoTamper
    {
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
            //noop
        }

        public void OnLoad()
        {
            // Tell Glimpse we are ready.
        }

        private void TellGlimpse()
        {
            
        }
    }
}
