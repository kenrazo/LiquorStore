using System;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using LiquorStore.ActionFilters;
using LiquorStore.Business.LogicCollection;
using LiquorStore.Business.LogicCollections;
using LiquorStore.Common.Helpers;
using LiquourStore.DAL.Context;
using LiquourStore.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace LiquorStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment currentEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(currentEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{currentEnvironment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
            CurrentEnvironment = currentEnvironment;
        }

        public IConfiguration Configuration { get; }
        private IHostingEnvironment CurrentEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureSerilogLogging();
            services.AddControllersWithViews();

            services.Scan(scan => scan
                .FromApplicationDependencies(a => a.FullName.StartsWith("LiquorStore"))
                .AddClasses(publicOnly: true)
                .AsMatchingInterface((service, filter) =>
                    filter.Where(implementation => implementation.Name.Equals($"I{service.Name}", StringComparison.OrdinalIgnoreCase)))
                .WithTransientLifetime());

            var connectionString = Configuration.GetValue<string>("ConnectionString");
            services.AddDbContext<LiquorStoreContext>(m =>
            {
                m.UseSqlServer(connectionString);
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SecurePolicy = CurrentEnvironment.IsDevelopment()
                        ? CookieSecurePolicy.None : CookieSecurePolicy.Always;
                    options.Cookie.SameSite = CurrentEnvironment.IsDevelopment() ? SameSiteMode.None : SameSiteMode.Lax;

                    options.Events = new CookieAuthenticationEvents
                    {
                        OnRedirectToLogin = ctx => {
                            ctx.Response.StatusCode = 401;
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IRequestInfo, RequestInfo>();
            services.AddAutoMapper(typeof(Business.MapperProfiles.MainProfile).GetTypeInfo().Assembly);
            services.AddTransient(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));

            services.AddMvc(config => { config.Filters.Add(typeof(SetupRequestInfo)); })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Business.MapperProfiles.MainProfile>());
            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                loggerFactory.AddFile(Configuration.GetValue<string>("SystemLogs:File:Path"), LogLevel.Error);
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });


            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }

        private void ConfigureSerilogLogging()
        {

            if (!CurrentEnvironment.IsProduction())
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                    .Enrich.FromLogContext()
                    .WriteTo.File(Configuration.GetValue<string>("SystemLogs:File:Path"), rollingInterval: RollingInterval.Day)
                    .CreateLogger();
            }
            else
            {
                var connectionString = Configuration.GetValue<string>("SystemLogs:Blob:ConnectionString");
                var containerName = Configuration.GetValue<string>("SystemLogs:Blob:ContainerName");
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                    .Enrich.FromLogContext()
                //    .WriteTo.AzureBlobStorage(connectionString, storageContainerName: containerName, storageFileName: "{yyyy}/{MM}/{dd}/log.txt")
                    .CreateLogger();
            }


        }
    }
}
