using System;
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
            ds.DateOrder = System.DateTime.Now;
            ds.DateUseOfService = dateUtilisation.Date;
            DemandeServiceDAO.creerDemandeService(ds);
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
            Cours cours = CoursDAO.recupererCours(Int32.Parse(Request["idService"].ToString()));
            Session["cours"] = cours;
            //view manquante
            return View();
        }
    }
}