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
    public class HintsController : ApiController
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

        // GET /api/hints?moduleId={moduleId}
        public IHttpActionResult GetModuleHints(int moduleId)
        {
            var module = _context.Modules
                .SingleOrDefault(m => m.Id == moduleId);
            if (module == null) return NotFound();
            var hints = _context.Hints
                .Include(h => h.Category)
                .Where(h => h.ModuleId == moduleId)
                .Select(Mapper.Map<Hint, HintDto>);
            return Ok(hints);
        }
    }
}
