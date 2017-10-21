using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PEAKBackend.Dtos
{
    public class HintDto
    {
        public int Id { get; set; }

        public virtual ModuleDto Module { get; set; }

        public virtual HintCategoryDto Category { get; set; }

        [Required]
        public string Content { get; set; }
    }
}