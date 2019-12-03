using System;
using System.Collections.Generic;

namespace myMVCApp
{
    public partial class City
    {
        public City()
        {
            Estate = new HashSet<Estate>();
        }

        public Guid Id { get; set; }
        public string Cityname { get; set; }

        public virtual ICollection<Estate> Estate { get; set; }
    }
}
