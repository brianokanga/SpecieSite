namespace Species.Data.Models
{
    public class PlantRequest
    {
        public int Id { get; set; }

        public int CountyId { get; set; }
        public int SubCountyId { get; set; }
        public int SpecieId { get; set; }
        public int SpecieInformationId { get; set; }
        public County County { get; set; }
        public SubCounty SubCounty { get; set; }
        public Location Location { get; set; }
        public Specie Specie { get; set; }
        public SpecieInformation SpecieInformation { get; set; }

    }
}
