using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCHOT2.Models;

namespace MVCHOT2.Controllers
{
    public class ProductController : Controller
    {
        private SalesOrderContext Context { get; set; }

        public ProductController(SalesOrderContext ctx)
        {
            Context = ctx;
        }

		[HttpGet]

		public IActionResult List()
		{
			var products = Context.Products.OrderBy(p => p.ProductName).ToList();
			return View(products);
		}
		[HttpPost]
		public IActionResult List(Product product)
		{
			if (ModelState.IsValid)
			{
				Context.Products.Add(product);
				Context.SaveChanges();
				return RedirectToAction("List");
			}
			else
			{
				return View(product);
			}
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var product = Context.Products.Find(id);
			return View(product);
		}
		[HttpPost]
		public IActionResult Delete(Product product)
		{
			Context.Products.Remove(product);
			Context.SaveChanges();
			return RedirectToAction("List");
		}

		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.Action = "Add Product";
			ViewBag.Categories = Context.Categories.OrderBy(c => c.CategoryName).ToList();
			return View("Edit", new Product());
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			ViewBag.Action = "Edit Product";
			ViewBag.Categories = Context.Categories.OrderBy(c => c.CategoryName).ToList();
			var product = Context.Products.Find(id);
			return View(product);
		}

		[HttpPost]
		public IActionResult Edit(Product product)
		{
			if (ModelState.IsValid)
			{
				if (product.ProductID == 0)
				{
					Context.Products.Add(product);
				}
				else
				{
					Context.Products.Update(product);
				}
				Context.SaveChanges();
				return RedirectToAction("List");
			}
			else
			{
				ViewBag.Action = (product.ProductID == 0) ? "Add Product" : "Edit Product";
				ViewBag.Categories = Context.Categories.OrderBy(c => c.CategoryName).ToList();
				return View(product);
			}
		}

		public IActionResult Details(int id)
		{
			var product = Context.Products.Include(c => c.Category).FirstOrDefault(p => p.ProductID == id);
			return View(product);
		}

		[HttpGet]
		public IActionResult Cancel(int id)
		{
			if (id == 0)
			{
				return RedirectToAction("List");
			}
			else
			{
				return RedirectToAction("Details", new { id });
			}
		}

		public IActionResult Index()
		{
			return View();
		}


	}
}
