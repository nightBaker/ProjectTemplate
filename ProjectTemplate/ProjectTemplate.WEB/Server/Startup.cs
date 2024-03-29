using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using ProjectTemplate.AppUser;
using ProjectTemplate.PERSISTENCE;
using ProjectTemplate.APPLICATION;
using Hangfire;
using Hangfire.PostgreSql;
using System;
using FluentValidation.AspNetCore;

namespace ProjectTemplate.WEB.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {            
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
           

            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UsePostgreSqlStorage(Configuration.GetConnectionString("ProjectTemplateHangfireDbConnection")));


            services.AddApplication(Configuration);
            services.AddPersistence(Configuration);

            services.AddDbContext<UserDbContext>(options =>
                options.UseNpgsql(
                    Configuration.GetConnectionString("ProjectTemplateUserDbConnection")));

            services.AddDefaultIdentity<ProjectTemplate.AppUser.AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<UserDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ProjectTemplate.AppUser.AppUser, UserDbContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddControllersWithViews()
                .AddFluentValidation();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                              IBackgroundJobClient backgroundJobs,
                              IWebHostEnvironment env,
                              ProjectTemplateDbContext projectTemplateDbContext,
                              UserDbContext userDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();                
                app.UseMigrationsEndPoint();
                app.UseWebAssemblyDebugging();

                //auto db migrations
                projectTemplateDbContext.Database.Migrate();
                userDbContext.Database.Migrate();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseHangfireDashboard();
            backgroundJobs.Enqueue(() => Console.WriteLine("Hello world from Hangfire!"));

            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
                endpoints.MapHangfireDashboard();
            });

            
        }
    }
}
