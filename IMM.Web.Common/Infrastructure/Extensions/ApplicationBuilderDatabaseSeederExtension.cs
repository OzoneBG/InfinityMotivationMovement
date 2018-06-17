namespace IMM.Web.Common.Infrastructure.Extensions
{
    using IMM.Data;
    using IMM.Data.Services.DbSeeder;
    using IMM.Data.Services.Interfaces;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    public static class ApplicationBuilderDatabaseSeederExtension
    {
        public static IApplicationBuilder SeedDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var context = services.GetRequiredService<IMMDbContext>();
                var categoriesService = services.GetRequiredService<ICategoriesService>();
                var productsService = services.GetRequiredService<IProductsService>();
                var loggerService = services.GetRequiredService<ILogger<IApplicationBuilder>>();

                IMMDBSeeder.Seed(context, categoriesService, productsService, loggerService);
            }

            return app;
        }
    }
}
