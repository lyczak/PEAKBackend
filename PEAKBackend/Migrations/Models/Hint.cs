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
        public virtual Module Module { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public virtual HintCategory Category { get; set; }

        [Required]
        public string Content { get; set; }
    }
}