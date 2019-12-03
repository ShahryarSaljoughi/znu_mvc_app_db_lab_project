using System;
using System.Collections.Generic;

namespace myMVCApp
{
    public partial class File
    {
        public File()
        {
            Request = new HashSet<Request>();
        }

        public string Path { get; set; }
        public int Filetype { get; set; }
        public Guid Id { get; set; }

        public virtual ICollection<Request> Request { get; set; }
    }
}
