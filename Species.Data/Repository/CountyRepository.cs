using System;
using System.Collections.Generic;
using System.Text;
using Species.Data.Data;
using System.Linq;
using Species.Data.Models;
using Species.Data.Repository.IRepository;

namespace Species.Data.Repository
{
    public class CountyRepository : Repository<County>, ICountyRepository
    {
        private readonly ApplicationDbContext _db;

        public CountyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(County county)
        {
            var objFromDb = _db.Counties.FirstOrDefault(s => s.Id == county.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = county.Name;
                objFromDb.SubCounties = county.SubCounties;
            }
        }
    }
}
