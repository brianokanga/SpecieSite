using System;
using System.Collections.Generic;
using System.Text;

namespace Species.Data.Models
{
    public class SubCounty
    {
        public SubCounty()
        {
            Locations = new List<Location>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CountyId { get; set; }
        public virtual County County { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}
