using System;
using System.Collections.Generic;

namespace myMVCApp
{
    public partial class Person
    {
        public Person()
        {
            RequestMalekNavigation = new HashSet<Request>();
            RequestVakilNavigation = new HashSet<Request>();
        }

        public string Nationalid { get; set; }
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public string Telno { get; set; }
        public string Mobileno { get; set; }

        public virtual ICollection<Request> RequestMalekNavigation { get; set; }
        public virtual ICollection<Request> RequestVakilNavigation { get; set; }
    }
}
