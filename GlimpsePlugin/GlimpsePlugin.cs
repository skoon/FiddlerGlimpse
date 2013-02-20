using Glimpse.Core;
using Glimpse.Core.Extensibility;
using System;
using System.Web;


namespace GlimpsePlugin
{

    public class GlimpsePlugin : IGlimpsePlugin
    {
        public object GetData(HttpContextBase context)
        {
            throw new NotImplementedException();
        }

        public string Name
        {
            get { return "Fiddler"; }
        }

        public void SetupInit()
        {
            throw new NotImplementedException();
        }
    }
}
