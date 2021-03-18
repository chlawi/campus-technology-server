using AppleAppRequest.Services;
using campus_technology_server.AppleAppRequest;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace campus_technology_server
{
    public class Startup
    {
        //private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            //this.configuration = configuration;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("AppleApp");
            services.AddDbContext<AppleAppRequestContext>(opt =>
              opt.UseSqlServer(Configuration.GetConnectionString("AppleApp"))
                 .EnableSensitiveDataLogging()
                 .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddSingleton<IAppleAppRequestService, AppleAppRequestService>();

            services.AddControllers();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
