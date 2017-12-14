using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PEAKBackend.Models;
using PEAKBackend.ViewModels;

namespace PEAKBackend.Controllers
{
    public class ImagesController : Controller
    {
        private ApplicationDbContext _context;

        public ImagesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // TODO Impliment a more elegant image management mechanism.
        // GET /images
        public ActionResult Index()
        {
            //var files = Directory.GetFiles(Server.MapPath("~/App_Data/Uploads"));
            return HttpNotFound();
        }

        // GET /images/view/{id}
        public ActionResult View(int id)
        {
            var image = _context.Images.SingleOrDefault(i => i.Id == id);
            if (image == null) return HttpNotFound();
            var file = Path.Combine(Server.MapPath("~/App_Data/Uploads"), image.ToString());
            return File(file, image.ContentType);
        }

        // GET /images/new?moduleId={moduleId}
        public ActionResult New(int moduleId)
        {
            var module = _context.Modules.SingleOrDefault(m => m.Id == moduleId);
            if (module == null) return HttpNotFound();
            var viewModel = new NewImageViewModel
            {
                Image = new Image(),
                ModuleId = moduleId
            };
            return View(viewModel);
        }

        // TODO Add some sort of server-side image cropping.
        // POST /images/upload
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file, int? moduleId)
        {
            var module = _context.Modules.SingleOrDefault(m => m.Id == moduleId);
            if (module == null) return HttpNotFound();
            if (file.ContentLength > 0)
            {
                if (Image.IsContentTypeValid(file.ContentType))
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var image = _context.Images.Add(new Image
                    {
                        ContentType = file.ContentType
                    });
                    _context.SaveChanges();
                    var path = Path.Combine(Server.MapPath("~/App_Data/Uploads"), image.ToString());
                    file.SaveAs(path);
                    module.ImageId = image.Id;
                    _context.SaveChanges();

                }
                else
                {
                    var viewModel = new NewImageViewModel
                    {
                        Image = new Image(),
                        ErrorMessage = "This image is not a valid format.  Please choose a jpeg or png image."
                    };
                    View("New", viewModel);
                }
            }
            return RedirectToAction("Index", "Modules");
        }
    }
}