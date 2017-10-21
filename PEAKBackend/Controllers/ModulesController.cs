using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        // GET /modules/view/{id}
        public ActionResult View(int id)
        {
            var module = _context.Modules.Include(m => m.Hints).SingleOrDefault(m => m.Id == id);
            return View(module);
        }

        // GET /modules/new
        public ViewResult New()
        {
            return View("ModuleForm", new Module());
        }

        // GET /modules/edit/{id}
        public ActionResult Edit(int id)
        {
            var module = _context.Modules.SingleOrDefault(m => m.Id == id);
            if (module == null) return HttpNotFound();
            return View("ModuleForm", module);
        }

        // POST /modules/save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Module module)
        {
            if (!ModelState.IsValid) return View("ModuleForm", module);
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