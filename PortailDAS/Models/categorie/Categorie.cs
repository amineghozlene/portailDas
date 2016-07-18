using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortailDAS {

    public class Categorie {

        public virtual int idCategorie { get; set; }
        public virtual string titre { get; set; }
        public virtual string description { get; set; }
        public virtual DateTime dateCreation { get; set; }
        public virtual string image { get; set; }
        public virtual int active { get; set; }


        public Categorie() { }

        #region Equals And HashCode Overrides
        /// <summary>
        /// local implementation of Equals based on unique value members
        /// </summary>
        public override bool Equals(object obj) {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            Categorie castObj = (Categorie)obj;
            return (castObj != null) &&
                (this.idCategorie == castObj.idCategorie);
        }

        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode() {
            int hash = 57;
            hash = 27 * hash * idCategorie.GetHashCode();
            return hash;
        }
        #endregion
    }

}