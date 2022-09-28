﻿namespace ASP.NETCoreIntroduction.Controllers
{
    using System.Text.Json;

    using Microsoft.AspNetCore.Mvc;

    using Models;

    public class ProductsController : Controller
    {
        private IEnumerable<ProductViewModel> products
            = new List<ProductViewModel>()
            { 
                new  ProductViewModel()
                {
                    Id = 1,
                    Name = "Cheto",
                    Price = 2.25
                },
                new ProductViewModel()
                {
                    Id = 2,
                    Name = "Kubeti",
                    Price = 0.50
                },
                new ProductViewModel()
                {
                    Id = 3,
                    Name = "Sedem Dni Sol",
                    Price = 0.99
                }
            };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult All()
        {
            return View(this.products);
        }

        public IActionResult ById(int id)
        {
            var product = this.products
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return BadRequest();
            }

            return View(product);
        }

        [HttpGet]
        public IActionResult AllAsJson()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            return Json(products, options);
        }

        [HttpGet]
        public IActionResult AllAsText()
        {
            var text = string.Empty;

            foreach(var product in products)
            {
                text += $"Product {product.Id}: {product.Name} - {product.Price} lv.";
                text += "\r\n";
            }

            return Content(text);
        }
    }
}
