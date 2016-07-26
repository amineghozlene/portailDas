using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortailDAS
{
    public class SocieteDAO
    {
        public static Societe recupererSociete(String nom)
        {
            using (ISession session = SessionNHibernate.ouvrirSession())
            {
                Societe soc = session.Get<Societe>(nom);
                
                return soc;
            }
        }
        public static IList<Societe> recupererToutSociete()
        {
            using (ISession session = SessionNHibernate.ouvrirSession())
            {
                ICriteria criteres = session.CreateCriteria(typeof(Societe));
                criteres.Add(Restrictions.Eq("type", "universite"));
                IList<Societe> socs = criteres.List<Societe>();
                return socs;
            }
        }
        public static Societe creerSociete(Societe soc)
        {
            using (ISession session = SessionNHibernate.ouvrirSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {

                    try
                    {
                        session.Save(soc);
                        session.Flush();
                        transaction.Commit();
                    }
                    catch (Exception exception)
                    {
                        transaction.Rollback();
                        Log.versFichier.Error("\r\n " +
                            "Classe[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.')[System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.').Count() - 1] + "]\r\n " +
                            "Fonction[" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]\r\n " +
                            "Exception[" + exception.Message + "]\r\n " +
                            "TargetSite[" + exception.TargetSite + "]\r\n " +
                            "StackTrace[\r\n" + exception.StackTrace + "\r\n ]\r\n " +
                            ((exception.InnerException != null) ? "InnerException[\r\n  " + exception.InnerException + "\r\n ]\r\n " : "") +
                            "Compte[\r\n  " + new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(soc) + "\r\n ]" +
                            "SessionEnParametre[Non]"


                        );
                        throw new Exception("Erreur creer compte : " + exception.Message);
                    }
                }
                return soc;
            }
        }
    }
}