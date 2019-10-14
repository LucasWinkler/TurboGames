using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConestogaVirtualGameStore.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConestogaVirtualGameStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// Adds services to the container
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // In-memory backing store for sessions
            services.AddDistributedMemoryCache();

            // Adds the database context using a connection string from appsettings.json
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("LocalDbConnection")));

            // Adds the identity services
            services.AddDefaultIdentity<ApplicationUser>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            /* Adds the MVC service to the application,
             * removes Identity from account pages (/Identity/Account/Manage -> /Account/Manage),
             * sets MVC to version 2.2
             */
            services.AddMvc()
                .AddRazorPagesOptions(o => o.Conventions.AddAreaFolderRouteModelConvention("Identity", "/Account/", model =>
                {
                    foreach (var selector in model.Selectors)
                    {
                        var attributeRouteModel = selector.AttributeRouteModel;
                        attributeRouteModel.Order = -1;
                        attributeRouteModel.Template = attributeRouteModel.Template.Remove(0, "Identity".Length);
                    }
                })
                ).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Configure session
            services.AddSession(options =>
            {
                options.Cookie.Name = ".CVGS.Session";
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }

        /// <summary>
        /// Configures the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Provides mechanisms to configure the pipeline.</param>
        /// <param name="env">Provides environment information</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Changes the way exceptions are handled depending if the build is production/development
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Standard configuration
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            // Enable sessions
            app.UseSession();

            // Force the application to use authentication
            app.UseAuthentication();

            // Add MVC and prepare the routing
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
