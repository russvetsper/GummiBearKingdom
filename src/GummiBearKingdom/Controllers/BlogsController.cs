using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GummiBearKingdom.Models;
using Microsoft.EntityFrameworkCore;

namespace GummiBearKingdom.Controllers
{
    public class BlogsController : Controller
    {
        private GummiBearKingdomContext db = new GummiBearKingdomContext();
        public IActionResult Index()
        {
            return View(db.Blogs.ToList());
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            db.Blogs.Add(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            var thisItem = db.Blogs.FirstOrDefault(blogs => blogs.BlogId == id);
            return View(thisItem);
        }

        [HttpPost]
        public IActionResult Edit(Blog blog)
        {
            db.Entry(blog).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var thisItem = db.Blogs.FirstOrDefault(blogs => blogs.BlogId == id);
            return View(thisItem);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisItem = db.Blogs.FirstOrDefault(blogs => blogs.BlogId == id);
            db.Blogs.Remove(thisItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
