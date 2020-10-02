using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Species.Data.Data;
using Species.Data.Models;
using Species.Data.Repository.IRepository;

namespace Species.Data.Repository
{
    public class SubCountyRepository : Repository<SubCounty>, ISubCountyRepository
    {
        private readonly ApplicationDbContext _db;

        public SubCountyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(SubCounty subCounty)
        {
            var objFromDb = _db.Counties.FirstOrDefault(s => s.Id == subCounty.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = subCounty.Name;

            }
        }

    }
}
