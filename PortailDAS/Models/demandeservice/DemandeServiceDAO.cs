using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace PortailDAS
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
        public static IList<DemandeService> recupererDemandesServices(Compte cpt)
        {
            IList<DemandeService> demandes;

            using (ISession session = SessionNHibernate.ouvrirSession())
            {

                try
                {
                    var compteCriteria = DetachedCriteria.For<Compte>()
                .SetProjection(Projections.Distinct(Projections.Property("login")))
                    .Add(Restrictions.Eq("idSociete", cpt.idSociete));

                    var demandeServiceCriteria= DetachedCriteria.For<DemandeService>()
                .Add(Subqueries.PropertyIn("idCompte", compteCriteria));
                    demandes = demandeServiceCriteria.GetExecutableCriteria(session).List<DemandeService>();
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

            return demandes;
        }


    }
}