namespace IMM.Web.Controllers
{
    using IMM.Data.Services.Interfaces;
    using IMM.Web.ViewModels.ShopViewModels;
    using Microsoft.AspNetCore.Mvc;
    using AutoMapper.QueryableExtensions;
    using System.Linq;
    using System;

    public class ShopController : Controller
    {
        private readonly IProductsService productsService;

        public ShopController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public IActionResult Product(Guid id, string name)
        {
            var product = productsService.GetProductById(id).FirstOrDefault();

            if(product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Index()
        {
            var products = productsService.GetAllProducts().ProjectTo<ShopIndexViewModel>().ToList();

            return View(products);
        }
    }
}