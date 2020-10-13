using System;
using System.Collections.Generic;
using System.Text;

namespace Species.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICountyRepository County { get; }
        ISubCountyRepository SubCounty { get; }
        ILocationRepository Location { get; }
        ISpecieRepository Specie { get; }
        ISpecieDetailRepository SpecieDetail { get; }
        IPlantRequestRepository PlantRequest { get; }
        ISP_Call SP_Call { get; }

        void Save();
    }
}
