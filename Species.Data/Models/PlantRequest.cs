using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Species.Data.Models
{
    public class PlantRequest
    {
        public PlantRequest()
        {
            Counties = new List<County>();

        }
        public int Id { get; set; }
        public int CountyId { get; set; }
        public virtual County County { get; set; }
        public virtual SubCounty SubCounty { get; set; }
        public virtual Location Location { get; set; }
        public virtual Specie Specie { get; set; }
        public virtual List<County> Counties { get; set; }
    }
}
