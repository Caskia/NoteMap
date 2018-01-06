using Jane.AspNetCore.Cors;
using Jane.AutoMapper;
using Jane.Configurations;
using Jane.Timing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace NoteMap.WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseJane();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Status}/{action=Index}/{id?}");
            });

            app.UseFileServer();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            Configuration.Create();

            //Configure CORS for sparxo application
            services.AddCorsPolicy(Configuration.Instance.Root);

            services.AddMvc();

            //Configure Mvc Json
            services.ConfigureMvcJsonOptions();

            return InitializeJaneServiceProvider(services);
        }

        private IServiceProvider InitializeJaneServiceProvider(IServiceCollection services)
        {
            var assemblies = new[]
            {
                Assembly.Load("NoteMap.Core"),
                Assembly.Load("NoteMap.Application"),
                Assembly.GetExecutingAssembly()
            };

            var autoMapperConfigurationAssemblies = new[]
            {
                Assembly.Load("NoteMap.Core"),
                Assembly.Load("NoteMap.Application"),
            };

            Configuration.Instance
                .UseAutofac()
                .RegisterCommonComponents()
                .RegisterAssemblies(assemblies)
                .UseMongoDb()
                .UseLog4Net()
                .UseAutoMapper(new AutoMapperConfiguration(), autoMapperConfigurationAssemblies)
                .UseAspNetCore(services, out var provider)
                .CreateAutoMapperMappings()
                .UseClockProvider(ClockProviders.Utc)
                .RegisterEventHandler(assemblies)
                .RegisterUnhandledExceptionHandler();

            return provider;
        }
    }
}