using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PEAKBackend.Models
{
    public class Hint
    {
        public int Id { get; set; }

        [Required]
        public int ModuleId { get; set; }
        public Module Module { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public HintCategory Category { get; set; }

        [Required]
        public string Content { get; set; }
    }
}