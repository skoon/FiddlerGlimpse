using System;
using System.Web.Http;
using Fiddler;

namespace FiddlerGlimpse
{
    public class FiddlerController : ApiController
    {

        public void Index()
        {

            //need to add an x-header here to filter in the Fiddler plugin
        }
    }
}