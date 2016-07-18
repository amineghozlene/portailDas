using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortailDAS.Models.service
{
    public class ServiceCompte
    {
        public virtual int idService { get; set; }
        public virtual string idSociete { get; set; }
        public virtual DateTime dateAchat { get; set; }
        public virtual DateTime dateExpiration { get; set; }
        public virtual int idServiceCompte { get; set; }
    }
}