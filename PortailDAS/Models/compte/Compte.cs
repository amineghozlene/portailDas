using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortailDAS
{
    public class Compte
    {
        public virtual string nom { get; set; }
        public virtual string prenom { get; set; }
        public virtual string password { get; set; }
        public virtual string login { get; set; }
        public virtual string email { get; set; }
        public virtual Societe idSociete { get; set; }
        public virtual int idRole { get; set; }
        public virtual CartePaiement idCartePaiement { get; set; }
        
        public virtual string etatValidation { get; set; }

        public Compte() { }

        #region Equals And HashCode Overrides
        /// <summary>
        /// local implementation of Equals based on unique value members
        /// </summary>
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            Compte castObj = (Compte)obj;
            return (castObj != null) &&
                (this.login == castObj.login);
        }

        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * login.GetHashCode();
            return hash;
        }
        #endregion
    }
}