using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop_CQRS.Infrastructure.Bus;
using Shop_CQRS.Infrastructure.Context;
using Shop_CQRS.Infrastructure.QueryHandler.Implementation;
using Shop_CQRS.Infrastructure.QueryHandler.Interface;

namespace Shop_CQRS
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
            services.AddDbContext<DomainContext>(opt => opt.UseSqlServer(
                Configuration["Data:ShopCQRS:ConnectionStrings"]));
            
            services.AddMvc();

            services.AddTransient<IBus, Bus>();
            services.AddTransient<IQueryProduct, QueryProduct>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: null,
                    template: "PageSize{pageSize:int}/Strona{productPage:int}",
                    defaults: new {controller = "Product", action = "List" }
                );
                routes.MapRoute(
                    name: null,
                    template: "Strona{productPage:int}",
                    defaults: new {controller = "Product", action = "List", productPage = 1 }
                );
                routes.MapRoute(
                    name: null,
                    template: "PageSize{pageSize:int}",
                    defaults: new { controller = "Product", action = "List", productPage = 1 }
                );
                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new { controller = "Product", action = "List",pageSize = 4, productPage = 1 }
                );
            });
            SeedDataCategory.EnsurePopulated(app);
            SeedDataProduct.EnsurePopulated(app);
        }
    }
}
