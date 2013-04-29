using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiddler;

namespace FiddlerGlimpse
{
    public class GlimpseChatter
    {
        public string IP { get; set; }
        public string URL { get; set; }
        public string Body { get; set; }
        public bool IsRequest { get; set; }
    }
}
