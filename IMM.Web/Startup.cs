namespace IMM.Web
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using AutoMapper;
    using IMM.Data;
    using IMM.Models;
    using IMM.Web.Common.Infrastructure.Extensions;
    using IMM.Data.Common.Repository;
    using IMM.Web.Common.Mapping;
    using IMM.Data.Services.Interfaces;
    using IMM.Data.Services.Implementations;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IMMDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<IMMDbContext>()
            .AddDefaultTokenProviders();

            services.AddTransient<IEmailSender, EmailSender>();

            services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperProfile>());

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<DbContext, IMMDbContext>();

            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<IProductsService, ProductsService>();

            services.AddMvc();
            services.AddSession();
            services.AddDirectoryBrowser();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseDatabaseMigration();
            app.SeedDatabase();
        }
    }
}
