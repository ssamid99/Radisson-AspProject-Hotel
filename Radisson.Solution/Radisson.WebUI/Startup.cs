using Coravel;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Radisson.Domain.AppCode.Extensions;
using Radisson.Domain.AppCode.Providers;
using Radisson.Domain.AppCode.Services;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities.Membership;
using System;
using System.Linq;
using System.Reflection;

namespace Radisson.WebUI
{
    public class Startup
    {
        private IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(cfg =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                        .RequireAuthenticatedUser()
                                        .Build();
                cfg.Filters.Add(new AuthorizeFilter(policy));
                cfg.ModelBinderProviders.Insert(0, new BooleanBinderProvider());
            });
            services.AddDbContext<RadissonDbContext>(cfg =>
            {
                cfg.UseSqlServer(configuration["ConnectionStrings:cString"]);
            })
                .AddIdentity<RadissonUser, RadissonRole>()
                .AddEntityFrameworkStores<RadissonDbContext>()
                .AddDefaultTokenProviders();
            services.AddScoped<ScheduledTasks>();
            services.Configure<IdentityOptions>(cfg =>
            {
                cfg.Password.RequireDigit = false;
                cfg.Password.RequireUppercase = false;
                cfg.Password.RequireLowercase = false;
                cfg.Password.RequireNonAlphanumeric = false;
                cfg.Password.RequiredLength = 3;

                cfg.User.RequireUniqueEmail = true;

                cfg.Lockout.MaxFailedAccessAttempts = 3;
                cfg.Lockout.DefaultLockoutTimeSpan = new TimeSpan(0, 3, 0);
            });

            services.ConfigureApplicationCookie(cfg => {

                cfg.LoginPath = "/signin.html";
                cfg.AccessDeniedPath = "/accessdenied.html";
                cfg.ExpireTimeSpan = new TimeSpan(0, 15, 0);
                cfg.Cookie.Name = "Radisson";
            });

            services.AddAuthentication();
            services.AddAuthorization(cfg =>
            {
                foreach (var policyName in Extension.policies)
                {
                    cfg.AddPolicy(policyName, p =>
                    {
                        p.RequireAssertion(handler =>
                        {
                            return handler.User.IsInRole("sa")
                            || handler.User.HasClaim(policyName, "1");
                        });
                    });
                }
            });

            services.AddScoped<UserManager<RadissonUser>>();
            services.AddScoped<SignInManager<RadissonUser>>();
            services.AddScoped<RoleManager<RadissonRole>>();



            services.AddRouting(cfg =>
            {
                cfg.LowercaseUrls = true;
            });
            services.Configure<EmailServiceOptions>(cfg =>
            {
                configuration.GetSection("emailAccount").Bind(cfg);
            });
            services.AddSingleton<EmailService>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IClaimsTransformation, AppClaimProvider>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith("Radisson."));
            services.AddMediatR(assemblies.ToArray());
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddScheduler();
            services.AddFluentValidation(r => r.RegisterValidatorsFromAssemblyContaining<Startup>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RoleManager<RadissonRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.SeedData();
            app.UseHttpsRedirection();
            app.SeedMembership();
            app.UseStaticFiles();
            RadissonDbSeed.SeedUserRole(roleManager);
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var scheduledTasks = scope.ServiceProvider.GetService<ScheduledTasks>();
                //scheduledTasks.ScheduleFuncAsync();
            }


            app.UseEndpoints(cfg =>
            {
                cfg.MapControllerRoute(
                    name: "default-signin",
                    pattern: "signin.html",
                    defaults: new
                    {
                        area = "",
                        controller = "account",
                        action = "signin"
                    });
                cfg.MapControllerRoute(
                    name: "default-accessdenied",
                    pattern: "accessdenied.html",
                    defaults: new
                    {
                        area = "",
                        controller = "account",
                        action = "accessdenied"
                    });
                cfg.MapControllerRoute(
                    name: "default-register",
                    pattern: "register.html",
                    defaults: new
                    {
                        area = "",
                        controller = "account",
                        action = "register"
                    });

                cfg.MapAreaControllerRoute("defaultAdmin", "admin", "admin/{controller=dashboard}/{action=index}/{id?}");
                cfg.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");
            });
        }
    }
}
