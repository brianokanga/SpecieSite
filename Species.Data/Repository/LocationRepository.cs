using System;
using System.Collections.Generic;
using System.Text;
using Species.Data.Data;
using System.Linq;
using Species.Data.Models;
using Species.Data.Repository.IRepository;

namespace Species.Data.Repository
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        private readonly ApplicationDbContext _db;

        public LocationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Location location)
        {
            var objFromDb = _db.Locations.FirstOrDefault(s => s.Id == location.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = location.Name;
                

            }
        }
    }
}
