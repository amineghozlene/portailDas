using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace PortailDAS.Controllers
{
    public class ElearningController : InitialisationProjet
    { 
        public ActionResult Elearning()
        {
            return View();
        }
        // GET: Enseignant
        public ActionResult demanderService()
        {
            //// création d'une nouvel notification
            //Notification notif;
            HttpSessionState Session = ((HttpSessionState)System.Web.HttpContext.Current.Session);
            Service service = (Service)Session["service"];
            Compte currentAccount = (Compte)Session["compteUtilisateur"];
            int nbrUsers;
            if (currentAccount.idRole == 6)
            {
                nbrUsers = 1;
            }
            else
            {
                 nbrUsers = Int32.Parse(Request["register-nbrUtilisateur"].ToString());
            }
            int periode= Int32.Parse(Request["register-periode"].ToString());
            DateTime dateUtilisation = Convert.ToDateTime(Request["register-dateUtilisation"]);
            DemandeService ds = new DemandeService();
            ds.idService = service;
            ds.idCompte = currentAccount;
            ds.nbrOrderService = nbrUsers;
            ds.periodeUtilisation = periode;
            ds.dateCreation = System.DateTime.Now;
            ds.DateUseOfService = dateUtilisation.Date;
            DemandeServiceDAO.creerDemandeService(ds);
            //notif = new Notification();
            //notif.compte = unCompte;
            //notif.date = DateTime.Now;
            return View("~/views/Elearning/elearning.cshtml");
        }
        public ActionResult ReclamerProbleme()
        {
            return View("~/views/Elearning/elearning.cshtml");
        }
        public ActionResult afficheModalServiceDescription()
        {
            HttpSessionState Session = ((HttpSessionState)System.Web.HttpContext.Current.Session);
            Service serv = ServiceDAO.recupererService(Int32.Parse(Request["session-service"].ToString()));
            Session["service"] = serv;
            return View("~/views/Elearning/descriptionServiceModal.cshtml");
        }
        public ActionResult afficheModalServiceForm()
        {
            return View("~/views/Elearning/serviceModal.cshtml");
        }
        public ActionResult recupererCours()
        {
            HttpSessionState Session = ((HttpSessionState)System.Web.HttpContext.Current.Session);
            Cours cours = CoursDAO.recupererCoursParService(Int32.Parse(Request["idService"].ToString()));
            Session["cours"] = cours;
            //view manquante
            return View();
        }
        public ActionResult afficheNotification()
        {
            
            Session["notification"] = AccueilController.notification;
            return View("~/views/Elearning/notificationContainer.cshtml");
        }
        public ActionResult supprimerNotification()
        {  
            return View();
        }
        public ActionResult openNotification()
        {
            int idService;
            String idCompte;
            if (Request["idService"].ToString() != null) {
                idService = Int32.Parse(Request["idService"].ToString());
                //processus payement
            }else if (Request["idCompte"].ToString() != null) {
                idCompte =Request["idCompte"].ToString();
                Compte unCompte = CompteDAO.recuperer(idCompte);
                CompteDAO.validerCompteElearning(unCompte);
                AccueilController.notification.Remove(Notification.rechercheNotificationParCompte(unCompte));
            }
            return View("~/views/Elearning/notificationContainer.cshtml");
        }
        public ActionResult afficheListUser()
        {
            return View("~/views/Elearning/listUsers.cshtml");
        }
        public ActionResult afficheListAchat()
        {
            return View("~/views/Elearning/listDemandeAchat.cshtml");
        }
        // pas encore testé source stackoverflow
        [HttpGet]
        public ActionResult downloadFile()
        {
            int idCours = Int32.Parse(Request["fileID"].ToString());
            Cours unCours = CoursDAO.recupererCoursParID(idCours);
          //  string fullPath = Path.Combine(Server.MapPath("~/MyFiles"), unCours.titre);
            return File(unCours.lien, MimeMapping.GetMimeMapping(unCours.lien), unCours.titre);
        }
        public ActionResult validerUserDansNotifications()
        {
            string idCompte = Request["id"].ToString();
            Compte unCompte = CompteDAO.recuperer(idCompte);
            CompteDAO.validerCompteElearning(unCompte);
            AccueilController.notification.Remove(Notification.rechercheNotificationParCompte(unCompte));
            return View("~/views/Elearning/notificationContainer.cshtml");
        }
        public ActionResult supprimerUserDansNotifications()
        {
            string idCompte = Request["id"].ToString();
            Compte unCompte = CompteDAO.recuperer(idCompte);
            CompteDAO.supprimer(unCompte);
            AccueilController.notification.Remove(Notification.rechercheNotificationParCompte(unCompte));
            return View("~/views/Elearning/notificationContainer.cshtml");
        }
        public ActionResult listeMesServices()
        {
            return View("~/views/Elearning/notificationContainer.cshtml");
        }
        public ActionResult creerLicenceService()
        {

            return View("~/views/Elearning/listDemandeAchat.cshtml");
        }

    }
}