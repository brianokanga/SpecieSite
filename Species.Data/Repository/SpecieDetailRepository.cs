using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Species.Data.Data;
using Species.Data.Models;
using Species.Data.Repository.IRepository;

namespace Species.Data.Repository
{
    public class SpecieDetailRepository : Repository<SpecieDetail>, ISpecieDetailRepository
    {
        private readonly ApplicationDbContext _db;

        public SpecieDetailRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(SpecieDetail specieDetail)
        {
            var objFromDb = _db.SpecieDetails.FirstOrDefault(s => s.Id == specieDetail.Id);
            if (objFromDb != null)
            {
                objFromDb.MapUrl = specieDetail.MapUrl;
                objFromDb.Location = specieDetail.Location;
                objFromDb.Specie = specieDetail.Specie;
            }
        }
    }
}
