using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace PortailDAS.Models.demandeservice
{
    public class DemandeServiceDAO
    {
        public static DemandeService creerDemandeService(DemandeService ds)
        {
            using (ISession session = SessionNHibernate.ouvrirSession())
            {
                using (ITransaction transaction = session.BeginTransaction()) { 
                    try
                    {
                        session.Save(ds);
                        session.Flush();
                        transaction.Commit();
                    return ds;
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
                        "NuméroRole[" + ds.idService + "]"
                    );
                    throw new Exception("Erreur recuperer Service : " + exception.Message);
                }

                }

            }
        }
        
        
    }
}