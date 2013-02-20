using Glimpse.Core.Extensibility;
using System;
using System.Web;


namespace GlimpsePlugin
{

    public class GlimpsePlugin : ITab
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

        public RuntimeEvent ExecuteOn
        {
            get { throw new NotImplementedException(); }
        }

        public object GetData(ITabContext context)
        {
            throw new NotImplementedException();
        }

        public Type RequestContextType
        {
            get { throw new NotImplementedException(); }
        }
    }
}
