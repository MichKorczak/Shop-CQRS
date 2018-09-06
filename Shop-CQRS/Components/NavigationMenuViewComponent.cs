using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop_CQRS.Infrastructure.QueryHandler.Interface;

namespace Shop_CQRS.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly IQueryCategory category;

        public NavigationMenuViewComponent(IQueryCategory category)
        {
            this.category = category;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(category.GetCategoryList());
        }
    }
}
