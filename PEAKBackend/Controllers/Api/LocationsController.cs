using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNet.Identity;
using PEAKBackend.Dtos;
using PEAKBackend.Models;

namespace PEAKBackend.Controllers.Api
{
    public class LocationsController : ApiController
    {
        private ApplicationDbContext _context;

        public LocationsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // TODO Replace UserID with User.Identity.GetUserId()
        // [Authorize]
        public IHttpActionResult GetUserLocations(string UserId)
        {
            var locations = _context.Locations
                .Where(l => l.UserId == UserId) //User.Identity.GetUserId()
                .Include(l => l.User)
                .Include(l => l.Module)
                .Select(Mapper.Map<Location, LocationDto>).ToList();
            return Ok(locations);
        }
    }
}
