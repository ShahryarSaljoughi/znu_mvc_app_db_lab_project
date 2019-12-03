using System;
using System.Collections.Generic;

namespace myMVCApp
{
    public partial class Estate
    {
        public Estate()
        {
            Request = new HashSet<Request>();
        }

        public double? Arearequired { get; set; }
        public double Totallandarea { get; set; }
        public string Address { get; set; }
        public double Constructioarea { get; set; }
        public string Part { get; set; }
        public string Majorplaque { get; set; }
        public string Minorplaque { get; set; }
        public string Projectname { get; set; }
        public Guid Id { get; set; }
        public Guid? CityId { get; set; }
        public Guid? SortOfLand { get; set; }

        public virtual City City { get; set; }
        public virtual Sortofland SortOfLandNavigation { get; set; }
        public virtual ICollection<Request> Request { get; set; }
    }
}
