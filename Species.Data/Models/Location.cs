using System;
using System.Collections.Generic;
using System.Text;

namespace Species.Data.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SubcountyId { get; set; }
        public SubCounty SubCounty { get; set; }
        public string MapFile { get; set; }
        public ICollection<SpecieInformation> SpeciesDetails { get; set; }
    }
}
