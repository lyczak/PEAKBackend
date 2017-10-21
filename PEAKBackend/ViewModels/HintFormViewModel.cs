using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PEAKBackend.Models;

namespace PEAKBackend.ViewModels
{
    public class HintFormViewModel
    {
        public Hint Hint { get; set; }

        public IEnumerable<HintCategory> Categories { get; set; }
    }
}