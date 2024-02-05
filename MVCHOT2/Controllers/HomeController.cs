using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCHOT2.Models;
using System.Diagnostics;

namespace MVCHOT2.Controllers
{
    public class HomeController : Controller
    {
        private SalesOrderContext Context { get; set; }

        public HomeController(SalesOrderContext ctx) 
        {
            Context = ctx;
        }

        public IActionResult Index()
        {
            var products = Context.Products.OrderBy(p => p.ProductName).ToList();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}