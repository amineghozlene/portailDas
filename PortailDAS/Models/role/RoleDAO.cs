using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortailDAS
{
    public class RoleDAO
    {
        public static Role recuperer(int idRole)
        {
            Role unRole = new Role();

            using (ISession session = SessionNHibernate.ouvrirSession())
            {

                try
                {
                    unRole = (Role)session.Get(typeof(Role), idRole);
                }
                catch (Exception exception)
                {
                    Log.versFichier.Error("\r\n " +
                        "Classe[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.')[System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.').Count() - 1] + "]\r\n " +
                        "Fonction[" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]\r\n " +
                        "Exception[" + exception.Message + "]\r\n " +
                        "TargetSite[" + exception.TargetSite + "]\r\n " +
                        "StackTrace[\r\n" + exception.StackTrace + "\r\n ]\r\n " +
                        ((exception.InnerException != null) ? "InnerException[\r\n  " + exception.InnerException + "\r\n ]\r\n " : "") +
                        "NuméroRole[" + idRole + "]"
                    );
                    throw new Exception("Erreur recuperer compte : " + exception.Message);
                }
            }

            return unRole;
        }
       
    }
}