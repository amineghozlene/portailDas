using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortailDAS
{
    public class CartePaiement
    {
        public virtual int idCartePaiement { get; set; }
        public virtual string operateur { get; set; }
        public virtual string typeCarte { get; set; }
        public virtual int codeAutorisation { get; set; }


        public CartePaiement() { }

        #region Equals And HashCode Overrides
        /// <summary>
        /// local implementation of Equals based on unique value members
        /// </summary>
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            CartePaiement castObj = (CartePaiement)obj;
            return (castObj != null) &&
                (this.idCartePaiement == castObj.idCartePaiement);
        }

        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * idCartePaiement.GetHashCode();
            return hash;
        }
        #endregion
    }
}