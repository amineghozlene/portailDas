using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortailDAS
{
    public class Cours
    {
        public virtual int idCours { get; set; }
        public virtual String titre { get; set; }
        public virtual String description { get; set; }
        public virtual String lien { get; set; }
        public virtual Service idService { get; set; }
    }
}