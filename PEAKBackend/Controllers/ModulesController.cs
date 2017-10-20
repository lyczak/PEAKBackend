using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PEAKBackend.Models;

namespace PEAKBackend.Controllers
{
    public class ModulesController : Controller
    {
        private ApplicationDbContext _context;

        public ModulesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /modules
        public ActionResult Index()
        {
            return View();
        }

        // GET /modules/new
        public ViewResult New()
        {
            return View("ModulesForm", new Module());
        }

        // GET /modules/edit/{id}
        public ActionResult Edit(int id)
        {
            var module = _context.Modules.SingleOrDefault(m => m.Id == id);
            if (module == null) return HttpNotFound();
            return View("ModulesForm", module);
        }

        // POST /modules/save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Module module)
        {
            if (!ModelState.IsValid) return View("ModulesForm", module);
            if (module.Id == 0)
            {
                _context.Modules.Add(module);
            }
            else
            {
                var existingModule = _context.Modules.Single(m => m.Id == module.Id);
                existingModule.Name = module.Name;
                existingModule.Description = module.Description;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}