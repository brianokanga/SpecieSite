using System;
using System.Collections.Generic;
using System.Text;
using Species.Data.Data;
using Species.Data.Models;
using Species.Data.Repository.IRepository;

namespace Species.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            County = new CountyRepository(_db);
            SubCounty = new SubCountyRepository(_db);
            Location = new LocationRepository(_db);
            Specie = new SpecieRepository(_db);
            SpecieInformation = new SpecieInformationRepository(_db);
            PlantRequest = new PlantRequestRepository(_db);
            SP_Call = new SP_Call(_db);
        }

        public ICountyRepository County { get; private set; }
        public ISubCountyRepository SubCounty { get; private set; }
        public ILocationRepository Location { get; private set; }
        public ISpecieRepository Specie { get; private set; }
        public ISpecieInformationRepository SpecieInformation { get; private set; }
        public IPlantRequestRepository PlantRequest { get; private set; }
        public ISP_Call SP_Call { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
