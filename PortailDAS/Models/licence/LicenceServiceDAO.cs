using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortailDAS
{
    public class LicenceServiceDAO
    {
        public static LicenceService creerLicence(LicenceService ls)
        {
            using (ISession session = SessionNHibernate.ouvrirSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {

                    try
                    {
                        session.Save(ls);
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
                            "Compte[\r\n  " + new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(ls) + "\r\n ]" +
                            "SessionEnParametre[Non]"


                        );
                        throw new Exception("Erreur creer compte : " + exception.Message);
                    }
                }
            }
            return ls;
        }
        public static LicenceService modifierLicence(LicenceService ls)
        {
            using (ISession session = SessionNHibernate.ouvrirSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {

                    try
                    {
                        session.Update(ls);
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
                            "Compte[\r\n  " + new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(ls) + "\r\n ]" +
                            "SessionEnParametre[Non]"


                        );
                        throw new Exception("Erreur creer compte : " + exception.Message);
                    }
                }
            }
            return ls;
        }

        public static IList<LicenceService> recupererLicence(Compte cpt){
            IList<LicenceService> licences = new List<LicenceService>();
            using (ISession session = SessionNHibernate.ouvrirSession())
            {

                try
                {
                    ICriteria criteres = session.CreateCriteria(typeof(LicenceService));
                    criteres.Add(Restrictions.Eq("idCompte", cpt));
                    licences = criteres.List<LicenceService>();
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
                        "NuméroCompte[" + cpt.login + "]"
                    );
                    throw new Exception("Erreur recuperer compte : " + exception.Message);
                }
            }

            return licences;
            
        }
    }
}