#region USING STATEMENTS
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NETD3202_F2022_InstrumentShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#endregion

namespace NETD3202_F2022_InstrumentShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Configuration property
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        #region CONFIFGURESERVICES METHOD
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Entity Framework Core's SQL Server database provider and configure
            // the connection string using the configuration object.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            // Add the default identity system for ASP.NET Core with default options,
            // including the requirement for a confirmed email address for user accounts.
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            // Add support for controllers with views.
            services.AddControllersWithViews();
            // Add support for Razor Pages.
            services.AddRazorPages();
        }
        #endregion
        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        #region CONFIGURE METHOD
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Show detailed error information when in development mode.
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                // Use a custom error page for exceptions in other environments.
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // Use HTTPS redirection middleware to redirect HTTP requests to HTTPS.
            app.UseHttpsRedirection();
            // Use static file middleware to serve static files, such as HTML, CSS, JavaScript and images.
            app.UseStaticFiles();
            // Use routing middleware to process requests based on the defined routes.
            app.UseRouting();
            // Use authentication and authorization
            app.UseAuthentication();
            app.UseAuthorization();
            // FOR ICON BELOW
            app.UseStaticFiles(); // Add this line if it doesn't already exist
            app.UseStaticFiles(new StaticFileOptions
            {
                RequestPath = "/wwwroot/favicon.ico"
            });
            // FOR ICON ABOVE
            // Use endpoints
            app.UseEndpoints(endpoints =>
            {
                // Map default
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
        #endregion
    }
}
