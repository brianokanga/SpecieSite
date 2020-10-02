using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Species.Data.Data;
using Species.Data.Models;
using Species.Data.Repository.IRepository;

namespace Species.Data.Repository
{
    public class SpecieInformationRepository : Repository<SpecieInformation>, ISpecieInformationRepository
    {
        private readonly ApplicationDbContext _db;

        public SpecieInformationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(SpecieInformation specieInformation)
        {
            var objFromDb = _db.SpecieInformations.FirstOrDefault(s => s.Id == specieInformation.Id);
            if (objFromDb != null)
            {
                objFromDb.Latitude = specieInformation.Latitude;
                objFromDb.Longitude = specieInformation.Longitude;
            }
        }
    }
}
