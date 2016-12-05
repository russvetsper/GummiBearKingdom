using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GummiBearKingdom.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GummiBearKingdom.Controllers
{
    public class ProductsController : Controller
    {
        private GummiBearKingdomContext db = new GummiBearKingdomContext();

        public Product Product { get; private set; }

        public IActionResult Index()
        {
            return View(db.Products.ToList());
        }
        // GET: /<controller>/
        public IActionResult Details(int id)
        {
            var thisProduct = db.Products.FirstOrDefault(ProductsController => ProductsController.ProductId == id);
            return View(thisProduct);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult Edit(int id)
        {
            var thisItem = db.Products.FirstOrDefault(products => products.ProductId == id);
            return View(thisItem);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var thisItem = db.Products.FirstOrDefault(products => products.ProductId == id);
            return View(thisItem);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisItem = db.Products.FirstOrDefault(products => products.ProductId == id);
            db.Products.Remove(thisItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    



    }
}
