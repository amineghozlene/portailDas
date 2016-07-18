using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Management.Automation;

namespace PortailDAS
{
    public class AccueilController : InitialisationProjet
    {

        // GET: Accueil
        public ActionResult Accueil()
        {
            //unCompte.nom = "amara";
            //unCompte.prenom = "rami";
            //unCompte.email = "ramyscoops@hotmail.com";
            //unCompte.login = "aaa";
            //unCompte.password = "aaa";
            //unCompte.idCartePaiement = 1;
            
            //Societe soc = new Societe();
            //Role rol = new Role();
            //rol.libelle = "admin";
            //unCompte.idRole = rol;
            //soc.nomSociete = "DAS";
            //soc.adresseSociete = "Lac";
            //soc.matriculeFiscale = "f";
            //soc.registreDeCommerce = "aaa";
            //unCompte.idSociete = soc;

            //CompteDAO.creer(unCompte);
            return View();
        }

        public ActionResult inscription()
        {
            Compte unCompte = new Compte();
            unCompte.nom = Request["register-nom"].ToString();
            unCompte.prenom = Request["register-prenom"].ToString();
            unCompte.email = Request["register-email"].ToString();
            unCompte.login = Request["register-login"].ToString();
            unCompte.password = Cryptage.crypter<System.Security.Cryptography.AesManaged>(Request["register-password"].ToString().Trim());
            Societe soc= SocieteDAO.recupererSociete(Request["register-societe"].ToString());
            CartePaiement carteP = new CartePaiement();
            if (soc==null) 
            {
                soc = new Societe();
                soc.idSociete = Request["register-societe"].ToString();
                soc.nomSociete = Request["register-societe"].ToString();
                soc.adresseSociete = "";
                soc.matriculeFiscale = "";
                soc.registreDeCommerce = "";
            }
            Role rol = new Role();
            carteP.operateur = "";
            carteP.typeCarte = "";
            carteP.codeAutorisation = 111;
            unCompte.idRole = RoleBS.ICOMPTE_CLIENT;
            
            unCompte.idSociete = soc;
            unCompte.idCartePaiement = carteP;

            CompteDAO.creer(unCompte);

            //Add user into AD

           

            return View("~/views/accueil/accueil.cshtml");
        }

        public ActionResult seConnecter()
        {
            ActionResult retourServeur;

            Compte compteDeLUtilisateur = authentification(Request["identifiant"].ToString().Trim(), Cryptage.crypter<System.Security.Cryptography.AesManaged>(Request["motDePasse"].ToString().Trim()));

            if (compteDeLUtilisateur == null)
            {
                retourServeur = Content("authentificationEchouee");
            }
            //else if (compteDeLUtilisateur.etat == CompteBS.INACTIF)
            //{
            //    retourServeur = Content("compteDesactive|" + (message != "" ? message : ((String)HttpContext.GetGlobalResourceObject("langue", "COMPTE_CORRESPONDANT_AU_LOGIN_DESACTIVE")).Replace("[#EMAIL]", email).Replace("[#NUMERO_TELEPHONE]", numeroTelephone).Replace("[#NOM1_SOCIETE]", nom1).Replace("\n", "<br/>")));
            //    Session["compteUtilisateur"] = null;
            //    Session["identifiantCompte"] = null;
            //}
            else
            {
                retourServeur = View("~/views/accueil/accueil.cshtml");
                //ViewData["chargerLayout"] = "oui";
                //if (Request["resterConnecter"] == "oui")
                //{
                //    // On sauvegarde l'identifiant et le mot de passe crypté en cookie
                //    HttpCookie cookieIdentifiant = new HttpCookie("xol_id", compteDeLUtilisateur.identifiant);
                //    cookieIdentifiant.Expires = DateTime.Now.AddDays(ParametreApplication.recuperer().NOMBRE_JOURS_EXISTENCE_COOKIES_AUTHENTIFICATION);
                //    Response.Cookies.Add(cookieIdentifiant);
                //    HttpCookie cookieMotDePasse = new HttpCookie("xol_mp", compteDeLUtilisateur.motDePasse);
                //    cookieMotDePasse.Expires = DateTime.Now.AddDays(ParametreApplication.recuperer().NOMBRE_JOURS_EXISTENCE_COOKIES_AUTHENTIFICATION);
                //    Response.Cookies.Add(cookieMotDePasse);
                //}
            }

            return retourServeur;
        }
        public ActionResult seDeconnecter()
        {
            deconnexion();

            return View("~/views/accueil/accueil.cshtml");
        }

        public ActionResult afficherProfil() {
            return View("~/views/accueil/profile.cshtml");
        }

        public ActionResult modifierProfil() {
            Compte unCompte = CompteDAO.recuperer(((Compte)Session["compteUtilisateur"]).login);
            unCompte.nom = Request["register-nom"].ToString();
            unCompte.prenom = Request["register-prenom"].ToString();
            unCompte.email = Request["register-email"].ToString();
            unCompte.login = Request["register-login"].ToString();
            unCompte.idSociete.nomSociete = Request["register-societe"].ToString();
            unCompte.idSociete.registreDeCommerce = Request["register-commerce"].ToString();
            unCompte.idSociete.matriculeFiscale = Request["matricule-fiscale"].ToString();
            unCompte.idSociete.adresseSociete = Request["matricule-fiscale"].ToString();
            unCompte.idCartePaiement.operateur = Request["operateur"].ToString();
            unCompte.idCartePaiement.typeCarte = Request["typeCarte"].ToString();
            unCompte.idCartePaiement.codeAutorisation = int.Parse(Request["codeAutorisation"].ToString());
            CompteDAO.mettreAJour(unCompte);
            return View("~/views/accueil/profile.cshtml");
        }

    }
}