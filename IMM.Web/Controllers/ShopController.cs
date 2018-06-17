namespace IMM.Web.Controllers
{
    using IMM.Data.Services.Interfaces;
    using IMM.Web.ViewModels.ShopViewModels;
    using Microsoft.AspNetCore.Mvc;
    using AutoMapper.QueryableExtensions;
    using System.Linq;

    public class ShopController : Controller
    {
        private readonly IProductsService productsService;

        public ShopController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public IActionResult Index()
        {
            var products = productsService.GetAllProducts().ProjectTo<ShopIndexViewModel>().ToList();

            return View(products);
        }
    }
}