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
            Compte currentAccount = (Compte)Session["compte-utilisateur"];
            int idService =Int32.Parse( Request["idService"].ToString());
            int nbrUsers = Int32.Parse(Request["nombre-Utilisateur"].ToString());
            DemandeServiceDAO.creerDemandeService(idService, nbrUsers, currentAccount);
            return View("~/views/Elearning/accueilElearning.cshtml");
        }
        public ActionResult ReclamerProbleme()
        {
            return View("~/views/Elearning/accueilElearning.cshtml");
        }
    }
}