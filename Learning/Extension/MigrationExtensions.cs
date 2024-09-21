using Learning.AppContext;
using Microsoft.EntityFrameworkCore;

namespace Learning.Extension
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using ApplicationContext dbContext =
                scope.ServiceProvider.GetRequiredService<ApplicationContext>();

            dbContext.Database.Migrate();
        }
    }
}
