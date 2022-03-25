using Business.DependencyResolvers.Autofac;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanel
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddAuthentication("AdminSecurityScheme")
                  .AddCookie("AdminSecurityScheme", options =>
                  {
                      options.Cookie = new CookieBuilder
                      {
                          //Domain = "",
                          HttpOnly = false,
                          Name = "Admin.Security.Cookie",
                          Path = "/",
                          SameSite = SameSiteMode.Lax,
                          SecurePolicy = CookieSecurePolicy.Always,

                      };
                      options.LoginPath = new PathString("/Auth/Login");
                      options.LogoutPath = new PathString("/Auth/Logout");
                      options.ReturnUrlParameter = "RequestPath";
                      options.SlidingExpiration = true;
                      options.ExpireTimeSpan = TimeSpan.FromDays(7);

                  });
            services.AddMvc();
            services.AddDependencyResolvers(new ICoreModule[] { new CoreModule(), new BusinessModule() });

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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}");
            });
        }
    }
}