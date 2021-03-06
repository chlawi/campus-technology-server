using AppleAppRequest.Services;
using campus_technology_server.AppleAppRequest;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;

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

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("AppleApp");
            services.AddDbContext<AppleAppRequestContext>(opt =>
              opt.UseSqlServer(Configuration.GetConnectionString("AppleApp"))
                 .EnableSensitiveDataLogging()
                 .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll));

            services.AddSingleton<IAppleAppRequestService, AppleAppRequestService>();

            //services.AddCors(options => { options.AddPolicy("AllowAllWithCredentials", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials()); });
            services.AddCors(options => { options.AddPolicy("AllowAllWithCredentials", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()); });

            var tenantId = $"{Configuration["AzureAD:TenantId"]}";
            var authority = $"{Configuration["AzureAD:Instance"]}/{tenantId}";

            var audience = new List<string>
            {
                $"{Configuration["AzureAD:ClientId"]}",
                $"{Configuration["AzureAD:Scope"]}"
            };

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options => 
                    {
                        options.Authority = authority;
                        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                        {
                            ValidAudiences = audience,
                            ValidIssuers = new List<string>
                            {
                                $"https://sts.windows.net/{tenantId}",
                                $"https://sts.windows.net/{tenantId}/v2.0"
                            }
                        };
                    });

            services
                .AddControllers()
                .AddNewtonsoftJson
                (
                    options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

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

            app.UseCors("AllowAllWithCredentials");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
