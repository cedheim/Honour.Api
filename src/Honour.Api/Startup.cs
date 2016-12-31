using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Honour.Common.Rest;
using Honour.Twitch.Contract;
using Honour.Twitch.Contract.Channel;
using Honour.Twitch.Contract.Hosting;
using Honour.Twitch.Logic.Channel;
using Honour.Twitch.Logic.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Honour.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);
            services.Configure<TwitchSettings>(Configuration.GetSection("Twitch"));
            services.AddScoped<IRestClient, RestClient>();
            services.AddScoped<IChannelService, ChannelService>();
            services.AddScoped<IHostingService, HostingService>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            if (env.IsDevelopment())
            {
                app.UseCors(builder => builder.AllowAnyOrigin());
            }
            else
            {
                app.UseCors(builder => builder.WithOrigins("http://www.honourforever.com").AllowAnyHeader());
            }
            

            app.UseMvc();
        }
    }
}
