using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace PortailDAS {
    public class CategorieDAO {

        public static IList<Categorie> recupererListeDesCategories(int active) {
            HttpSessionState Session = ((HttpSessionState)HttpContext.Current.Session);

            IList<Categorie> listeDesCategories = null;

            using (ISession session = SessionNHibernate.ouvrirSession()) {

                try {
                    ICriteria criteres = session.CreateCriteria(typeof(Categorie));
                    criteres.Add(Restrictions.Eq("active", active));
                    listeDesCategories = criteres.List<Categorie>();
                } catch (Exception exception) {
                    Log.versFichier.Error("\r\n " +
                        "Classe[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.')[System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.').Count() - 1] + "]\r\n " +
                        "Fonction[" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]\r\n " +
                        "Exception[" + exception.Message + "]\r\n " +
                        "TargetSite[" + exception.TargetSite + "]\r\n " +
                        "StackTrace[\r\n" + exception.StackTrace + "\r\n ]\r\n " +
                        ((exception.InnerException != null) ? "InnerException[\r\n  " + exception.InnerException + "\r\n ]\r\n " : "")
                    );
                    throw new Exception("Erreur recupererListeDesCategories : " + exception.Message);
                }
            }

            return listeDesCategories;
        }
    }
}