using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using PEAKBackend.Models;
using PEAKBackend.ViewModels;

namespace PEAKBackend.Controllers
{
    public class HintsController : Controller
    {
        private ApplicationDbContext _context;

        public HintsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /hints/new
        public ActionResult New(int moduleId)
        {
            var module = _context.Modules.SingleOrDefault(m => m.Id == moduleId);
            if (module == null) return HttpNotFound();
            var hint = new Hint { ModuleId = module.Id };
            var viewModel = new HintFormViewModel
            {
                Hint = hint,
                Categories = _context.HintCategories.ToList()
            };
            return View("HintForm", viewModel);
        }

        // GET /hints/edit/{id}
        public ActionResult Edit(int id)
        {
            var hint = _context.Hints.SingleOrDefault(h => h.Id == id);
            if (hint == null) return HttpNotFound();
            var viewModel = new HintFormViewModel
            {
                Hint = hint,
                Categories = _context.HintCategories.ToList()
            };
            return View("HintForm", viewModel);
        }

        // POST /hints/save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Hint hint, string referrer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new HintFormViewModel
                {
                    Hint = hint,
                    Categories = _context.HintCategories.ToList()
                };
                return View("HintForm", viewModel);
            }
            if (hint.Id == 0)
            {
                _context.Hints.Add(hint);
            }
            else
            {
                var existingHint = _context.Hints.Single(h => h.Id == hint.Id);
                existingHint.Content = hint.Content;
                existingHint.CategoryId = hint.CategoryId;
            }
            _context.SaveChanges();
            if (string.IsNullOrWhiteSpace(referrer)) return RedirectToAction("Index", "Modules");
            return Redirect(referrer);
        }
    }
}