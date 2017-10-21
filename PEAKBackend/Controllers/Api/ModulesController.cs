using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using PEAKBackend.Dtos;
using PEAKBackend.Models;

namespace PEAKBackend.Controllers.Api
{
    public class ModulesController : ApiController
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

        // GET /api/modules
        public IEnumerable<ModuleDto> GetModules()
        {
            var modules = _context.Modules
                .Select(Mapper.Map<Module, ModuleDto>).ToList();
            return modules;
        }

        // GET /api/modules/{id}
        public IHttpActionResult GetModule(int id)
        {
            var module = _context.Modules
                .SingleOrDefault(m => m.Id == id);
            if (module == null) return NotFound();
            return Ok(Mapper.Map<ModuleDto>(module));
        }

        // DELETE /api/modules/{id}
        public void DeleteModule(int id)
        {
            var module = _context.Modules.SingleOrDefault(m => m.Id == id);
            if (module == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Modules.Remove(module);
            _context.SaveChanges();
        }
    }
}
