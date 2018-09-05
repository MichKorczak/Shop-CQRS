using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop_CQRS.Core.Domain;

namespace Shop_CQRS.Infrastructure.Context
{
    public static class SeedDataProduct
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetRequiredService<DomainContext>();
            context.Database.Migrate();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Opony",
                        CategoryId = 1,
                        Description = "Potrzebne do poruszania się bezpiecznie do drogach",
                        NumberOfIrems = 100,
                        Price = 249.99m
                    },
                    new Product
                    {
                        Name = "Odświerzacz powietrza",
                        CategoryId = 1,
                        Description = "Kiedy auto śmierdzi ale nie chce Ci się go prać",
                        NumberOfIrems = 1000,
                        Price = 5.99m
                    },
                    new Product
                    {
                        Name = "Smartphone",
                        CategoryId = 2,
                        Description = "Najlepszy najnowszy model na rynku",
                        NumberOfIrems = 50,
                        Price = 999.99m
                    },
                    new Product
                    {
                        Name = "Spodnie",
                        CategoryId = 3,
                        Description = "Wygodne i szykowne",
                        NumberOfIrems = 75,
                        Price = 99.99m
                    },
                    new Product
                    {
                        Name = "Koszulka",
                        CategoryId = 3,
                        Description = "Na codzień, barwnie i kolorowo",
                        NumberOfIrems = 125,
                        Price = 29.99m
                    },
                    new Product
                    {
                        Name = "Piłka",
                        CategoryId = 4,
                        Description = "Okrągła a bramki są dwie",
                        NumberOfIrems = 20,
                        Price = 79.99m
                    },
                    new Product
                    {
                        Name = "Okulary do pływania",
                        CategoryId = 4,
                        Description = "Gdy chcesz pod wodą widzieć bez przeszkód",
                        NumberOfIrems = 20,
                        Price = 79.99m
                    },
                    new Product
                    {
                        Name = "Kwiatek",
                        CategoryId = 5,
                        Description = "Ładny i pachnący, póki go podlewasz",
                        NumberOfIrems = 10,
                        Price = 9.99m
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
