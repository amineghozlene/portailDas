using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortailDAS {

    public class Service {
        public virtual int idService { get; set; }
        public virtual string titre { get; set; }
        public virtual string description { get; set; }
        public virtual string image { get; set; }
        public virtual decimal prixHT { get; set; }
        public virtual int active { get; set; }
        public virtual Categorie idCategorie { get; set; }


        public Service() { }

        #region Equals And HashCode Overrides
        /// <summary>
        /// local implementation of Equals based on unique value members
        /// </summary>
        public override bool Equals(object obj) {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            Service castObj = (Service)obj;
            return (castObj != null) &&
                (this.idService == castObj.idService);
        }

        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode() {
            int hash = 57;
            hash = 27 * hash * idService.GetHashCode();
            return hash;
        }
        #endregion
    }
}