using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using NHibernate;


namespace PortailDAS
{
    /// <summary>
    /// Classe d'instanciation des sessions Hibernate. 
    /// La sessionFactory qui fabrique les instanciations de sessions se comporte comme un singleton.
    /// </summary>
    public static class SessionNHibernate
    {
        private static ISessionFactory sessionFactory;

        private static ISessionFactory recupererSessionFactory
        {
            get
            {
                if (sessionFactory == null)
                {
                    initialiserSessionFactory();
                }
                return sessionFactory;
            } 
        }

        public static ISession ouvrirSession() // utiliser pour les select
        {
            ISession uneSession = null;

            try
            {
                // OpenSession() retourne une session depuis la factory
                uneSession = recupererSessionFactory.OpenSession();
            }
            catch (Exception exception)
            {
                //Log.versFichier.Error("\r\n " +
                //    "Classe[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.')[System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.').Count() - 1] + "]\r\n " +
                //    "Fonction[" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]\r\n " +
                //    "Exception[" + exception.Message + "]\r\n " +
                //    "TargetSite[" + exception.TargetSite + "]\r\n " +
                //    "StackTrace[\r\n" + exception.StackTrace + "\r\n ]" +
                //    ((exception.InnerException != null) ? "\r\n InnerException[\r\n  " + exception.InnerException + "\r\n ]" : "")
                //);
                throw new Exception("Erreur ouvrir session hibernate : " + exception.Message);
            }

            return uneSession;
        }

        /*public static IStatelessSession ouvrirSessionSansEtat() // utiliser pour l'insertion, les updates, les deletes, session sans état, on n'a pas besoin de conserver les objets
        {
            IStatelessSession uneSessionSansEtat = null;

            try {
                // OpenSession() retourne une session depuis la factory
                uneSessionSansEtat = recupererSessionFactory.OpenStatelessSession();
            } catch (Exception exception) {
                Log.versFichier.Error("\r\n " +
                    "Classe[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.')[System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.').Count() - 1] + "]\r\n " + 
                    "Fonction[" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]\r\n " + 
                    "Exception[" + exception.Message + "]\r\n " +
                    "TargetSite[" + exception.TargetSite + "]\r\n " + 
                    "StackTrace[\r\n" + exception.StackTrace + "\r\n ]" +
                    ((exception.InnerException != null) ? "\r\n InnerException[\r\n  " + exception.InnerException + "\r\n ]" : "") 
                );
                throw new Exception("Erreur ouvrir session sans état hibernate : " + exception.Message);
            }

            return uneSessionSansEtat;
        }*/

        private static void initialiserSessionFactory()
        {
            try
            {
                // Chemin du fichier de config non spécifié, donc on tape dans le web.config
                sessionFactory = (new Configuration().Configure().BuildSessionFactory());
            }
            catch (Exception exception)
            {
                //Log.versFichier.Error("\r\n " +
                //    "Classe[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.')[System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.').Count() - 1] + "]\r\n " +
                //    "Fonction[" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]\r\n " +
                //    "Exception[" + exception.Message + "]\r\n " +
                //    "TargetSite[" + exception.TargetSite + "]\r\n " +
                //    "StackTrace[\r\n" + exception.StackTrace + "\r\n ]" +
                //    ((exception.InnerException != null) ? "\r\n InnerException[\r\n  " + exception.InnerException + "\r\n ]" : "")
                //);
                throw new Exception("Erreur configuration hibernate : " + exception.Message);
            }
        }


    }
}