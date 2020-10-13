using System;
using System.Collections.Generic;
using System.Text;

namespace Species.Data.Models
{
    public class County
    {
        public County()
        {
            SubCounties = new List<SubCounty>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SubCounty> SubCounties { get; set; }
    }
}
