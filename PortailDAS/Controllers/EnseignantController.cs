using PortailDAS.Models.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortailDAS.Controllers
{
    public class EnseignantController : Controller
    {
        // GET: Enseignant
        public ActionResult demanderService()
        {
            Service service = (Service)Session["compte-Service"];
            Compte currentAccount = (Compte)Session["compte-utilisateur"];
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
    }
}