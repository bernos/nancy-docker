using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Nancy;
using Nancy.Owin;
using Owin;

namespace DockerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri = "http://+:8880";

            using (WebApp.Start<Startup>(uri))
            {
                Console.WriteLine("Your application is running on " + uri);
                Console.WriteLine("Press any key to close the host.");

                Thread.Sleep(Timeout.Infinite);


                //Under mono if you deamonize a process a Console.ReadLine with cause an EOF 
                //so we need to block another way
                if (args.Any(s => s.Equals("-d", StringComparison.CurrentCultureIgnoreCase)))
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                else
                {
                    Console.ReadKey();
                }
            }
        }
    }

    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();
        }
    }

    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => "Hello world!";
        }
    }
}
