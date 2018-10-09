using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace AwesomeServer
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseAwesomeServer(o => o.FolderPath = @"c:\sandbox\in")
                .UseStartup<Startup>()
                .Build();
    }
}
