﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace NoteMap.WebApi
{
    public class Program
    {
        public static IWebHost BuildWebHost(string[] args) =>
                    WebHost.CreateDefaultBuilder(args)
                        .UseKestrel(options =>
                        {
                            options.AddServerHeader = false;
                        })
                        //.UseUrls("http://0.0.0.0:5000")
                        .UseStartup<Startup>()
                        .Build();

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }
    }
}