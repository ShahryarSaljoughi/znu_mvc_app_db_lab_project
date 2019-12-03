using System;
using System.Collections.Generic;

namespace myMVCApp
{
    public partial class Request
    {
        public Guid Id { get; set; }
        public Guid Estate { get; set; }
        public Guid? Malek { get; set; }
        public Guid Vakil { get; set; }
        public Guid Mandata { get; set; }

        public virtual Estate EstateNavigation { get; set; }
        public virtual Person MalekNavigation { get; set; }
        public virtual File MandataNavigation { get; set; }
        public virtual Person VakilNavigation { get; set; }
    }
}
