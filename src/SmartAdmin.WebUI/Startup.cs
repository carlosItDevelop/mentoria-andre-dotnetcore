using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SmartAdmin.WebUI.Data;
using SmartAdmin.WebUI.Extensions;
using SmartAdmin.WebUI.Models;
using SmartAdmin.WebUI.Services.Abstractions;
using SmartAdmin.WebUI.Services.Implementations;

namespace SmartAdmin.WebUI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<SmartSettings>(Configuration.GetSection(SmartSettings.SectionName));

            services.AddSingleton(s => s.GetRequiredService<IOptions<SmartSettings>>().Value);

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("SQLiteConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddErrorDescriber<IdentityMensagensPortugues>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //        .AddEntityFrameworkStores<ApplicationDbContext>()
            //        .AddDefaultUI()
            //.AddDefaultTokenProviders();


            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 3;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;

            });

            // Attibuto Global de Autorização
            //services.AddControllersWithViews(config =>
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //           .RequireAuthenticatedUser()
            //           .Build();
            //    config.Filters.Add(new AuthorizeFilter(policy));
            //});




            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped<IUserPermissionsService, UserPermissionsService>();


            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
                options.LogoutPath = "/Identity/Account/Logout";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            });

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();  // Obsoleto 3.1
                app.UseMigrationsEndPoint();

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
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
                    "intel",
                    "{controller=intel}/{action=analyticsdashboard}");
                // intel/analyticsdashboard

                //endpoints.MapControllerRoute(
                //    "default",
                //    "{controller=AspNetCore}/{action=Welcome}");

                endpoints.MapRazorPages();
            });
        }
    }
}
