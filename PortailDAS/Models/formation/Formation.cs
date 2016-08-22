using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortailDAS
{
    public class Formation
    {
        public virtual int idFormation { get; set; }
        public virtual String titre { get; set; }
        public virtual String description { get; set; }
        public virtual DateTime dateFormation { get; set; }
        public virtual DateTime dureeFormation { get; set; }
    }
}