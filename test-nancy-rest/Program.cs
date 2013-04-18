using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy;
using Nancy.Hosting.Self;
using System.Configuration;

namespace Test.Nancy.Rest
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:999";
            if (ConfigurationManager.AppSettings["Url"] != null)
            {
                url = ConfigurationManager.AppSettings["Url"];
            }
            try
            {
                Console.WriteLine(String.Format("Server listening on url: {0}", url));
                var nancyHost = new NancyHost(new Uri(url));
                nancyHost.Start();
                Console.WriteLine("Hit <ENTER> to end the process.");
                Console.ReadLine();
                nancyHost.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.ReadLine();
            }
        }
    }
}
