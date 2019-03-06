using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrevithickP3.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrevithickP3.Models;

namespace TrevithickP3
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            //only needed to run code once to population my datebase
            //  SeedDatabase(serviceProvider).Wait();
            CreateUsersAndRoles(serviceProvider).Wait();

        }

        private async Task SeedDatabase(IServiceProvider serviceProvider)
        {

            //Get reference to DBContext from serviceProvider through dependency injection
            var context2 = serviceProvider.GetRequiredService<ApplicationDbContext>();

            if (context2 != null)
            {
                var SkillsToAdd = new List<Skill> {
                    new Skill{Title="SkillTest1",Description="SkillTest1"}
                };
                foreach (var skill in SkillsToAdd)
                {
                    //If skill not in database add it
                    if (!await context2.Skills.AnyAsync(s => s.Title == skill.Title))
                    {
                        await context2.Skills.AddAsync(skill);
                    }
                }
                
            }

            //var c = serviceProvider.GetRequiredService<ApplicationDbContext>();
            if (context2 != null)
            {
                DateTime date = DateTime.Parse("Jan 4, 2017");
                DateTime date2 = DateTime.Parse("Dec 6, 2018");
                var EdToAdd = new List<Education> {
                    new Education{Degree="Degree",School="CNM",Start=date,End=date2}
                };
                foreach (var ed in EdToAdd)
                {
                    await context2.Educations.AddAsync(ed);
                    //for some reason the program does not check the if statment and had to force to populate
                    //if (!await context2.Educations.AllAsync(e => e.Degree == ed.Degree))
                    //{
                    //    await context2.Educations.AddAsync(ed);
                    //}
                }

                //await context2.SaveChangesAsync();
            }
            //var Con = serviceProvider.GetRequiredService<ApplicationDbContext>();
            if (context2 != null) {
                DateTime date = DateTime.Parse("Jan 4, 2017");
                DateTime date2 = DateTime.Parse("Dec 6, 2018");
                var ExToAdd = new List<Experience> {
                new Experience{Title="Experience1",Description="Experience1",Start=date,End=date2}
            };

            foreach (var ex in ExToAdd)
            {
                    await context2.Experiences.AddAsync(ex);
                    //for some reason the program does not check the if statment and had to force to populate
               // if (!await context2.Experiences.AllAsync(exe => exe.Title == ex.Title))
               //{
               //     await context2.Experiences.AddAsync(ex);
               // }
            }
                
            }
            await context2.SaveChangesAsync();


        }
        private async Task CreateUsersAndRoles(IServiceProvider serviceProvider)
        {
            //Get reference to RoleManager and UserManager from serviceProvider through dependency injection
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            //Check if admin role exists and if not add it.
            var roleExist = await RoleManager.RoleExistsAsync("Admin");
            if (!roleExist)
            {
                //create the roles and seed them to the database: Question 1  
                await RoleManager.CreateAsync(new IdentityRole("Admin"));
            }

            //Check if admin user exists and if not add it
            IdentityUser user = await UserManager.FindByEmailAsync("admin@aserver.net");

            if (user == null)
            {
                user = new IdentityUser()
                {
                    UserName = "admin@aserver.net",
                    Email = "jttjtrevithick@gmail.com",
                };
                await UserManager.CreateAsync(user, "G@mesforlife78");

                //Add user to admin role
                await UserManager.AddToRoleAsync(user, "Admin");
            }
        }

    }

}
