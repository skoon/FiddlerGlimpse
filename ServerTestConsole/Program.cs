using System;
using FiddlerGlimpse;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Owin;


namespace ServerTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var plugin = new FiddlerPlugin())
            {
                Console.WriteLine("hit any key to stop");
                Console.ReadLine();
            }
            //using (var _server = StreamingSelfHost.Instance)
            //{
            //    _server.Start();
            //    Console.WriteLine("hit any key to stop");
            //    Console.ReadLine();
            //    _server.Stop();
            //}

        }
    }
}
