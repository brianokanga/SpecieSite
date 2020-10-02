using System;
using System.Collections.Generic;
using System.Text;

namespace Species.Data.Models
{
    public class SpecieInformation
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int SpeciesId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public Specie Species { get; set; }
        public Location Location { get; set; }
    }
}
