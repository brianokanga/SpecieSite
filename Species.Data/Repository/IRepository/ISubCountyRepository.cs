using System;
using System.Collections.Generic;
using System.Text;
using Species.Data.Models;

namespace Species.Data.Repository.IRepository
{
    public interface ISubCountyRepository : IRepository<SubCounty>
    {
        void Update(SubCounty subCounty);
    }
}
