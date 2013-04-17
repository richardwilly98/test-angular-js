using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy;
using Nancy.Hosting.Self;

namespace Test.Nancy.Rest
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:999";
            url = "http://SKIPPER-WIN7-2.luckyluke.local:999";
            var nancyHost = new NancyHost(new Uri(url));
            nancyHost.Start();
            Console.WriteLine(String.Format("Server listening on url: {0}", url));
            Console.WriteLine("Hit <ENTER> to end the process.");
            Console.ReadLine();
            nancyHost.Stop();
        }
    }
}
