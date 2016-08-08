using PortailDAS.Models.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace PortailDAS.Controllers
{
    public class EnseignantController : Controller
    {
        // GET: Enseignant
        public ActionResult demanderService()
        {
            Service service = (Service)Session["Service"];
            Compte currentAccount = (Compte)Session["compteUtilisateur"];
            int nbrUsers = Int32.Parse(Request["register-nbrUtilisateur"].ToString());
            int periode= Int32.Parse(Request["register-periode"].ToString());
            DateTime dateUtilisation = Convert.ToDateTime(Request["register-dateUtilisation"]);
            DemandeService ds = new DemandeService();
            ds.idService = service;
            ds.idCompte = currentAccount;
            ds.nbrOrderService = nbrUsers;
            ds.periodeUtilisation = periode;
            ds.DateOrder = System.DateTime.Now;
            ds.DateUseOfService = dateUtilisation;
            DemandeServiceDAO.creerDemandeService(ds);
            return View("~/views/Elearning/accueilElearning.cshtml");
        }
        public ActionResult ReclamerProbleme()
        {
            return View("~/views/Elearning/accueilElearning.cshtml");
        }
        [HttpPost]
        public String sessionService()
        {
            HttpSessionState Session = System.Web.HttpContext.Current.Session;
            Service serv = ServiceDAO.recupererService(Int32.Parse(Request["session-service"].ToString()));
            Session["service"] = serv;
            return serv.titre;
        }
    }
}