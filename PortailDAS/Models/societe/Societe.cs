using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortailDAS
{
    public class Societe
    {
        public virtual String idSociete { get; set; }
        public virtual string nomSociete { get; set; }
        public virtual string registreDeCommerce { get; set; }
        public virtual string matriculeFiscale { get; set; }
        public virtual string adresseSociete { get; set; }
        public virtual string type { get; set; }
        public virtual string domaineActivite { get; set; }

        public Societe() { }

        #region Equals And HashCode Overrides
        /// <summary>
        /// local implementation of Equals based on unique value members
        /// </summary>
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            Societe castObj = (Societe)obj;
            return (castObj != null) &&
                (this.idSociete == castObj.idSociete);
        }

        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * idSociete.GetHashCode();
            return hash;
        }
        #endregion
    }
}