using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PEAKBackend.Dtos
{
    public class LocationDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ApplicationUserDto User { get; set; }

        public virtual ModuleDto Module { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double Radius { get; set; }
    }
}