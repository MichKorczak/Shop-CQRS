using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Shop_CQRS.Core.Domain;

namespace Shop_CQRS.Infrastructure.Context
{
    public static class SeedDataCategory
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetRequiredService<DomainContext>();
            context.Database.Migrate();
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category
                    {
                        Name = "Motoryzacja"
                    },
                    new Category
                    {
                        Name = "Elektronika"
                    },
                    new Category
                    {
                        Name = "Moda"
                    },
                    new Category
                    {
                        Name = "Sport"
                    },
                    new Category
                    {
                        Name = "Dom i ogród"
                    });
                context.SaveChanges();
            }
        }
    }
}
