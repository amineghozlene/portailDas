﻿using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace PortailDAS
{

    public class ServiceDAO {
        public static object Restriction { get; private set; }

        public static IList<Service> recupererListeDesServicesAvecCatalogue() {
            HttpSessionState Session = ((HttpSessionState)HttpContext.Current.Session);

            IList<Service> listeDesServices = null;

            using (ISession session = SessionNHibernate.ouvrirSession()) {

                try {
                    ICriteria criteres = session.CreateCriteria(typeof(Service));
                    listeDesServices = criteres.List<Service>();
                } catch (Exception exception) {
                    Log.versFichier.Error("\r\n " +
                        "Classe[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.')[System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.').Count() - 1] + "]\r\n " +
                        "Fonction[" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]\r\n " +
                        "Exception[" + exception.Message + "]\r\n " +
                        "TargetSite[" + exception.TargetSite + "]\r\n " +
                        "StackTrace[\r\n" + exception.StackTrace + "\r\n ]\r\n " +
                        ((exception.InnerException != null) ? "InnerException[\r\n  " + exception.InnerException + "\r\n ]\r\n " : "")
                    );
                    throw new Exception("Erreur recupererListeDesServicesAvecCatalogue : " + exception.Message);
                }
            }

            return listeDesServices;
        }
        public static IList<LicenceService> recupererListeDesServicesELearning()
        {
            HttpSessionState Session = ((HttpSessionState)HttpContext.Current.Session);

            IList<LicenceService> listeDesServices = null;

            using (ISession session = SessionNHibernate.ouvrirSession())
            {

                try
                {
                    ICriteria criteres = session.CreateCriteria(typeof(LicenceService));
                  //  criteres.Add(Restriction.eq());
                    listeDesServices = criteres.List<LicenceService>();
                }
                catch (Exception exception)
                {
                    Log.versFichier.Error("\r\n " +
                        "Classe[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.')[System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.').Count() - 1] + "]\r\n " +
                        "Fonction[" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]\r\n " +
                        "Exception[" + exception.Message + "]\r\n " +
                        "TargetSite[" + exception.TargetSite + "]\r\n " +
                        "StackTrace[\r\n" + exception.StackTrace + "\r\n ]\r\n " +
                        ((exception.InnerException != null) ? "InnerException[\r\n  " + exception.InnerException + "\r\n ]\r\n " : "")
                    );
                    throw new Exception("Erreur recupererListeDesServicesAvecCatalogue : " + exception.Message);
                }
            }

            return listeDesServices;
        }
        public static Service recupererService(int idService)
        {
            Service unService = new Service();

            using (ISession session = SessionNHibernate.ouvrirSession())
            {

                try
                {
                    unService = (Service)session.Get(typeof(Service), idService);
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
                        "NuméroCompte[" + idService + "]"
                    );
                    throw new Exception("Erreur recuperer compte : " + exception.Message);
                }
            }

            return unService;
        }
    }
}