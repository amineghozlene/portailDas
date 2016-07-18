using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortailDAS
{
    public class Role
    {
        public virtual int idRole { get; set; }
        public virtual string libelle { get; set; }


        public Role() { }

        #region Equals And HashCode Overrides
        /// <summary>
        /// local implementation of Equals based on unique value members
        /// </summary>
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            Role castObj = (Role)obj;
            return (castObj != null) &&
                (this.idRole == castObj.idRole);
        }

        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * idRole.GetHashCode();
            return hash;
        }
        #endregion
    }
}