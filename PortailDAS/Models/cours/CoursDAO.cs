using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortailDAS
{
    public class CoursDAO
    {
        public static Cours recupererCours(int idService)
        {
            Cours unCours = null;
            // HttpSessionState Session = ((HttpSessionState)System.Web.HttpContext.Current.Session);
            // int[] tableauEtat = new int[] { CompteBS.ACTIF, CompteBS.INACTIF };

            using (ISession session = SessionNHibernate.ouvrirSession())
            {

                try
                {
                    ICriteria criteres = session.CreateCriteria(typeof(Cours));
                    criteres.Add(Restrictions.Eq("idService", idService));
                    unCours = criteres.UniqueResult<Cours>();
                }
                catch (Exception exception)
                {
                    Log.versFichier.Error("\r\n " +
                        "Classe[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.')[System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.').Count() - 1] + "]\r\n " +
                        "Fonction[" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]\r\n " +
                        "Exception[" + exception.Message + "]\r\n " +
                        "TargetSite[" + exception.TargetSite + "]\r\n " +
                        "StackTrace[\r\n" + exception.StackTrace + "\r\n ]" +
                        ((exception.InnerException != null) ? "\r\n InnerException[\r\n  " + exception.InnerException + "\r\n ]" : "")
                    );
                    throw new Exception("Erreur authentifier : " + exception.Message);
                }
            }

            return unCours;
        }
    }
}