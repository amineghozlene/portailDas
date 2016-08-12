using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortailDAS
{
    public class DemandeService
    {
        public virtual int idOrderService { get; set; }
        public virtual DateTime DateOrder { get; set; }
        public virtual DateTime DateUseOfService { get; set; }
        public virtual int periodeUtilisation { get; set; }
        public virtual int nbrOrderService { get; set; }
        public virtual Service idService { get; set; }
        public virtual Compte idCompte { get; set; }

    }
}