namespace IMM.Web.Controllers
{
    using IMM.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            Product tshirt1 = new Product()
            {
                Name = "Black T-Shirt",
                Description = "A black thirt for you",
                Quantity = 15,
                Price = 10.99M,
                Category = new Category()
                {
                    Name = "T-Shirt"
                }
            };

            Product tshirt2 = new Product()
            {
                Name = "Red T-Shirt",
                Description = "A red thirt for you",
                Quantity = 12,
                Price = 9.99M,
                Category = new Category()
                {
                    Name = "T-Shirt"
                }
            };

            Product tshirt3 = new Product()
            {
                Name = "White T-Shirt",
                Description = "A white thirt for you",
                Quantity = 34,
                Price = 7.99M,
                Category = new Category()
                {
                    Name = "T-Shirt"
                }
            };

            Product cap1 = new Product()
            {
                Name = "A white motivation hat for you and your friends",
                Description = "A white motivation hat for you and your friends",
                Quantity = 15,
                Price = 3.99M,
                Category = new Category()
                {
                    Name = "Cap"
                }
            };

            Product cap2 = new Product()
            {
                Name = "A red motivation hat for you and your friends",
                Description = "A red motivation hat for you and your friends",
                Quantity = 12,
                Price = 3.99M,
                Category = new Category()
                {
                    Name = "Cap"
                }
            };

            Product cap3 = new Product()
            {
                Name = "A black motivation hat for you and your friends",
                Description = "A black motivation hat for you and your friends",
                Quantity = 34,
                Price = 3.99M,
                Category = new Category()
                {
                    Name = "Cap"
                }
            };

            List<Product> products = new List<Product>();

            products.Add(tshirt1);
            products.Add(tshirt2);
            products.Add(tshirt3);
            products.Add(cap1);
            products.Add(cap2);
            products.Add(cap3);

            return View(products);
        }
    }
}