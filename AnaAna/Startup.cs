using AnaAna.Data;
using AnaAna.Data.Interfaces;
using AnaAna.Data.Models;
using AnaAna.Data.Repositories;
using AnaAna.RazorHtmlEmails.Interfaces;
using AnaAna.RazorHtmlEmails.Services;
using AnaAna.Services;
using AnaAna.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AnaAna
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();


            services.AddControllersWithViews();
            services.AddScoped<IProfilesService, ProfilesService>();
            services.AddScoped<IResultsService, ResultsService>(); 
            services.AddScoped<IChoicesService, ChoicesService>();
            services.AddScoped<ICategoriesService, CategoriesService>();
            services.AddScoped<IPollsService, PollsService>();
            services.AddScoped<IRazorViewToStringRender, RazorViewToStringRenderer>();
            services.AddScoped<IEmailsService, EmailsService>();
            services.AddScoped<IRepositoryGeneric<Poll>, RepositoryGeneric<Poll>>();
            services.AddScoped<IRepositoryGeneric<Choice>, RepositoryGeneric<Choice>>();
            services.AddScoped<IResultRepository, ResultRepository>();
            services.AddScoped<IRepositoryGeneric<Category>, RepositoryGeneric<Category>>();
            services.AddScoped<IRepositoryGeneric<ApplicationUser>, RepositoryGeneric<ApplicationUser>>();
            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
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
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
