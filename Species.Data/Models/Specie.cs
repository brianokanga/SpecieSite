using System;
using System.Collections.Generic;
using System.Text;

namespace Species.Data.Models
{
    public class Specie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SpecieInformation> SpeciesDetails { get; set; }
    }
}
