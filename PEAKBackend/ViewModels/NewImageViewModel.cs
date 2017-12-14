using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PEAKBackend.Models;

namespace PEAKBackend.ViewModels
{
    public class NewImageViewModel
    {
        [Required]
        public Image Image { get; set; }

        public string ErrorMessage { get; set; }

        public int? ModuleId { get; set; }
    }
}