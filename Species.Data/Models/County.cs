﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Species.Data.Models
{
    public class County
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SubCounty> SubCounties { get; set; }
    }
}
