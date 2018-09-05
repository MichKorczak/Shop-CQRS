﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop_CQRS.Core.Response.Models;
using Shop_CQRS.Infrastructure.QueryHandler.Interface;

namespace Shop_CQRS.Controllers
{
    public class ProductController : Controller
    {
        private readonly IQueryProduct product;

        public ProductController(IQueryProduct product)
        {
            this.product = product;
        }

        public async Task<ViewResult> List(int PageSize = 4, int productPage = 1)
        {
            var response = await product.GetProductListAsync();
            var modelResponse = new ProductListViewModel
            {
                Products = response.Skip((productPage - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    TotalItems = response.Count,
                    ItemsPerPage = PageSize,
                    CurrentPage = productPage
                }
            };
            return View(modelResponse);
        }
    }
}
