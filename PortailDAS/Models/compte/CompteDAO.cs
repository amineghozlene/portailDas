using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;
using System.Web.SessionState;

namespace PortailDAS
{
    public class CompteDAO
    {
        public static Compte creer(Compte unCompte)
        {
            using (ISession session = SessionNHibernate.ouvrirSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {

                    try
                    {
                        session.Save(unCompte);
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
                            "Compte[\r\n  " + new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(unCompte) + "\r\n ]" +
                            "SessionEnParametre[Non]" 


                        );
                        throw new Exception("Erreur creer compte : " + exception.Message);
                    }
                }
            }
            return unCompte;
        }

        public static Compte authentifier(string identifiant, string motDePasse)
        {
            Compte unCompte = null;
           // HttpSessionState Session = ((HttpSessionState)System.Web.HttpContext.Current.Session);
            // int[] tableauEtat = new int[] { CompteBS.ACTIF, CompteBS.INACTIF };

            using (ISession session = SessionNHibernate.ouvrirSession())
            {

                try
                {
                    ICriteria criteres = session.CreateCriteria(typeof(Compte));
                    criteres.Add(Restrictions.Eq("login", identifiant));
                    criteres.Add(Restrictions.Eq("password", motDePasse));
                    unCompte = criteres.UniqueResult<Compte>();
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

            return unCompte;
        }

        public static Compte recuperer(String idcompte) {
            Compte unCompte = new Compte();

            using (ISession session = SessionNHibernate.ouvrirSession()) {

                try {
                    unCompte = (Compte)session.Get(typeof(Compte), idcompte);
                } catch (Exception exception) {
                    Log.versFichier.Error("\r\n " +
                        "Classe[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.')[System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.').Count() - 1] + "]\r\n " +
                        "Fonction[" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]\r\n " +
                        "Exception[" + exception.Message + "]\r\n " +
                        "TargetSite[" + exception.TargetSite + "]\r\n " +
                        "StackTrace[\r\n" + exception.StackTrace + "\r\n ]\r\n " +
                        ((exception.InnerException != null) ? "InnerException[\r\n  " + exception.InnerException + "\r\n ]\r\n " : "") +
                        "NuméroCompte[" + idcompte + "]"
                    );
                    throw new Exception("Erreur recuperer compte : " + exception.Message);
                }
            }

            return unCompte;
        }

        

        public static Compte recuperer(string email, int typeDeCompte) {
            Compte unCompte = new Compte();

            using (ISession session = SessionNHibernate.ouvrirSession()) {

                try {
                    //ICriteria criteres = session.CreateCriteria(typeof(Compte));
                    //criteres.Add(Restrictions.Eq("numeroExterne", numeroExterneCompte));
                    //criteres.Add(Restrictions.Eq("typeDeCompte", typeDeCompte));

                    //DetachedCriteria sousRequeteFournisseur = DetachedCriteria.For(typeof(Societe));
                    //sousRequeteFournisseur.Add(Restrictions.Eq("societeFournisseur.numeroSociete", numeroSocieteFournisseur));
                    //sousRequeteFournisseur.Add(Restrictions.Eq("numeroExterne", numeroExterneSocieteClient));
                    //sousRequeteFournisseur.SetProjection(Projections.Property("numeroSociete"));

                    //criteres.Add(Property.ForName("societe.numeroSociete").In(sousRequeteFournisseur));


                    //unCompte = criteres.UniqueResult<Compte>();
                } catch (Exception exception) {
                    Log.versFichier.Error("\r\n " +
                        "Classe[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.')[System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.').Count() - 1] + "]\r\n " +
                        "Fonction[" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]\r\n " +
                        "Exception[" + exception.Message + "]\r\n " +
                        "TargetSite[" + exception.TargetSite + "]\r\n " +
                        "StackTrace[\r\n" + exception.StackTrace + "\r\n ]\r\n " +
                        ((exception.InnerException != null) ? "InnerException[\r\n  " + exception.InnerException + "\r\n ]\r\n " : "")
                  
                    );
                    throw new Exception("Erreur recuperer compte : " + exception.Message);
                }
            }

            return unCompte;
        }

        public static Compte mettreAJour(Compte unCompte) {
            using (ISession session = SessionNHibernate.ouvrirSession()) {
                using (ITransaction transaction = session.BeginTransaction()) {

                    try {
                        session.Update(unCompte);
                        session.Flush();
                        transaction.Commit();
                    } catch (Exception exception) {
                        transaction.Rollback();
                        Log.versFichier.Error("\r\n " +
                            "Classe[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.')[System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.').Count() - 1] + "]\r\n " +
                            "Fonction[" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]\r\n " +
                            "Exception[" + exception.Message + "]\r\n " +
                            "TargetSite[" + exception.TargetSite + "]\r\n " +
                            "StackTrace[\r\n" + exception.StackTrace + "\r\n ]\r\n " +
                            ((exception.InnerException != null) ? "InnerException[\r\n  " + exception.InnerException + "\r\n ]\r\n " : "") +
                            "Compte[\r\n  " + new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(unCompte) + "\r\n ]" +
                            "SessionEnParametre[Non]"


                        );
                        throw new Exception("Erreur creer compte : " + exception.Message);
                    }
                }
            }
            return unCompte;
        }
        // reste le test sur qui est autorisé à faire ces taches
        public static Compte validerCompteElearning(Compte compte)
        {
            HttpSessionState Session = ((HttpSessionState)HttpContext.Current.Session);
            using (ISession session = SessionNHibernate.ouvrirSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {

                    try
                    {
                        compte.etatValidation = "validé";
                        session.Update(compte);
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
                            "Compte[\r\n  " + new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(compte) + "\r\n ]" +
                            "SessionEnParametre[Non]"


                        );
                        throw new Exception("Erreur creer compte : " + exception.Message);
                    }
                }
            }
            return compte;
        }
        public static IList<Compte> recupererdemandeValidationCompteElearning()
        {
            IList<Compte> comptes;
            
            using (ISession session = SessionNHibernate.ouvrirSession())
            {

                try
                {
                    ICriteria criteres = session.CreateCriteria(typeof(Compte));
                    criteres.Add(Restrictions.Eq("etatValidation","nonValidé"));
                    
                  comptes = criteres.List<Compte>();
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

            return comptes;
        }

    }
}