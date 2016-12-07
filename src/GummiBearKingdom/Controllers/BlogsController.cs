using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GummiBearKingdom.Models;

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
    }
}
