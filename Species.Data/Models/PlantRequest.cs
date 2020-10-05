using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Species.Data.Models
{
    public class PlantRequest
    {
        public int Id { get; set; }
        public County County { get; set; }
        public ICollection<SubCounty> SubCounty { get; set; }
        public Location Location { get; set; }
        public Specie Specie { get; set; }
    }
}
