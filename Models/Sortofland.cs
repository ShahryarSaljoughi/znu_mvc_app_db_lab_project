using System;
using System.Collections.Generic;

namespace myMVCApp
{
    public partial class Sortofland
    {
        public Sortofland()
        {
            Estate = new HashSet<Estate>();
        }

        public string Landsort { get; set; }
        public Guid Id { get; set; }

        public virtual ICollection<Estate> Estate { get; set; }
    }
}
