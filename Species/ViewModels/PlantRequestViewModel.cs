using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Species.Data.Models;

namespace Species.ViewModels
{
    public class PlantRequestViewModel
    {
        public PlantRequest PlantRequest { get; set; }

        public IEnumerable<SelectListItem> CountyList { get; set; }
        public IEnumerable<SelectListItem> SubCountyList { get; set; }
        public IEnumerable<SelectListItem> LocationList { get; set; }
        public IEnumerable<SelectListItem> SpecieList { get; set; }
    }
}
