using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortailDAS
{
    public class LicenceService
    {
        public virtual Service idService { get; set; }
        public virtual Compte idCompte { get; set; }
        public virtual DateTime dateAchat { get; set; }
        public virtual DateTime dateExpiration { get; set; }
        public virtual int idServiceCompte { get; set; }
        public virtual string etatLicence { get; set; }
    }
}