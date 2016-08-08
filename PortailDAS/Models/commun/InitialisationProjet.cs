// Par défaut
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Gestion de la langue
using System.Threading;
using System.Globalization;
// Pour utiliser les sessions utilisateurs ds méthode static
//  via HttpSessionState Session = ((HttpSessionState) HttpContext.Current.Session);
using System.Web.SessionState;
// Pour hériter de la classe "Controller"
using System.Web.Mvc;
using PortailDAS;

/// <summary>
/// Classe mère dont tous les contrôleurs de page héritent
/// Le but de cet héritage est de centraliser tous les traitements liés aux utilisateurs dans la classe Utilisateur :
///     -	Sécurité : redirection sur la page d’accueil si l’utilisateur tente d’accéder à une page alors qu’il n’est pas authentifié
///     -	Gestion de la langue du site
///     -	Authentification : création des variables sessions nécessaires, récupération en base cookie dataTables et envois au client, authentification par interface utilisateur ou cookie
///     -	Déconnexion
/// Seul le contrôleur AideController n’hérite pas de la classe Utilisateur car c’est une page technique, destinée uniquement aux développeurs. Elle dispose de son propre mécanisme d’authentification (simplissime).
/// </summary>
public class InitialisationProjet : Controller
{
    public InitialisationProjet()
    {
        HttpSessionState Session = ((HttpSessionState)System.Web.HttpContext.Current.Session);
        HttpRequest Request = ((HttpRequest)System.Web.HttpContext.Current.Request);

        //Session["domaine"] = (System.Web.HttpContext.Current.Request.ServerVariables["SERVER_NAME"] == "localhost")
        //    ? "http://localhost:50003/"
        //    : "http://" + System.Web.HttpContext.Current.Request.ServerVariables["SERVER_NAME"] + "/"
        //;
        // Redirection si utilisateur non authentifié et essaye d'accèder à une page du site autre que l'authentification
        //if (
        //    Session["compteUtilisateur"] == null
        //    && !System.Web.HttpContext.Current.Request.ServerVariables["URL"].Contains("DasCloud/Accueil")
        //)
        //{
        //    // La redirection ne bloque pas l'appel initial, c.a.d. que la page appellée est chargée également, et juste après la page d'accueil est chargée 
        //    // Il faudrait idéalement que la page initiale ne soit pas chargée inutilement
        //    System.Web.HttpContext.Current.Response.Redirect("/");
        //}

    }


    /// <summary>
    /// Connection classique
    /// </summary>
    /// <param name="identifiant">Identifiant du compte</param>
    /// <param name="motDePasse">Mot de passe du compte</param>
    /// <returns>Utilisateur</returns>
    public static Compte authentification(string identifiant, string motDePasse)
    {
        Compte unCompte = CompteDAO.authentifier(identifiant, motDePasse);

        unCompte = processusAuthentification(unCompte);

        return unCompte;
    }

    /// <summary>
    /// Selon l'existence du compte, la méthode instancie les variables de session utilisateur
    /// </summary>
    /// <param name="identifiant">Identifiant du compte</param>
    /// <param name="motDePasse">Mot de passe du compte</param>
    public static Compte processusAuthentification(Compte unCompte)
    {
        HttpRequest Request = ((HttpRequest)System.Web.HttpContext.Current.Request);
        bool authentificationValide = false;
        if (unCompte != null)
        {
            authentificationValide = true;
            HttpSessionState Session = ((HttpSessionState)System.Web.HttpContext.Current.Session);
            HttpApplicationState Application = ((HttpApplicationState)System.Web.HttpContext.Current.Application);

            // On détruit et on les réaffecte au cas l'utilisateur s'est connecté une 1ère fois avec un compte et se reconnecte avec un autre compte. Là on est sur de supprimer toutes les variables sessions qui existent.

            //string domaine = Session["domaine"].ToString();

            Session.RemoveAll();

            //Session.Add("domaine", domaine);

            authentificationValide = preparationVariablesSessionsSuiteAuthentification(unCompte);
            if (!authentificationValide)
            { // cas webShop
                // Demande de Serge de loguer les erreurs de connexion
                Session.RemoveAll();
                unCompte = null;
                Log.versFichier.Info(
                    "Identifiant[" + Request["identifiant"] + "] - Mot de passe[" + Request["motDePasse"] + "]" +
                    "Classe[Utilisateur] - " +
                    "Fonction[" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] > Erreur d'authentification WebShop"
                );
            }

        }

        return unCompte;
    }

    /// <summary>
    /// Méthode appelée dans GererSocietesController, fonctionnellement appelée lorsque sélection compte par superadmin
    /// </summary>
    /// <param name="unCompte"></param>
    public static bool preparationVariablesSessionsSuiteAuthentification(Compte unCompte)
    {
        HttpSessionState Session = ((HttpSessionState)System.Web.HttpContext.Current.Session);
        bool authentificationValide = true;
        Session["compteUtilisateur"] = unCompte;
       

        // Détermination du profil utilisateur (éviter de faire se traitement x fois dans les templates)
        Session["utilisateurEstSuperAdministrateur"] = false;
        Session["utilisateurEstAdministrateurLogidas"] = false;
        Session["utilisateurEstAdministrateurSav"] = false;
        Session["utilisateurEstLaPost"] = false;
        Session["utilisateurEstClient"] = false;


        //PartenaireDAO Changements
        if (unCompte.idRole == RoleBS.ISUPER_ADMINISTRATEUR)
        {
            Session["utilisateurEstSuperAdministrateur"] = true;
        }
        else if (unCompte.idRole == RoleBS.IADMINISTRATEUR_LOGIDAS)
        {
            Session["utilisateurEstAdministrateurLogidas"] = true;
        }
        else if (unCompte.idRole == RoleBS.IADMINISTRATEUR_SAV)
        {
            Session["utilisateurEstAdministrateurSav"] = true;
        }
        else if (unCompte.idRole == RoleBS.ICOMPTE_LA_POSTE)
        {
            Session["utilisateurEstLaPost"] = true;
        }
        else if (unCompte.idRole == RoleBS.ICOMPTE_CLIENT)
        {
            Session["utilisateurEstClient"] = true;
        }
        //preparationVariablesSessionsAbonnementService(societeUtilisateurOuSocieteFournisseur);

        return authentificationValide;
    }



    /// <summary>
    /// Détruit les variables de session et redirige vers la page d'accueil
    /// </summary>
    public static void deconnexion()
    {
        HttpSessionState Session = ((HttpSessionState)System.Web.HttpContext.Current.Session);
        HttpApplicationState Application = ((HttpApplicationState)System.Web.HttpContext.Current.Application);

        if (Session["compteUtilisateur"] != null)
        {
            //string domaine = Session["domaine"].ToString();

            Session.RemoveAll();

            Session.Add("deconnexion", true);

        }

        // On efface les cookies d'authentification (en réalité on ne peut supprimer un cookie alors on fixe une date antérieure pour que le navigateur le supprime)
        // /!\ Avant ce bloc était dans le if précédent, or si utilisateur est en "restez connecté" et que perte de session, et qu'il fait déconnexion le cookie restait tjrs présent et donc suite à un F5 : authentification auto !
        // Maintenant on supprime systématiquement le cookie, plus de pb
        //HttpCookie cookieIdentifiant = new HttpCookie("xol_id", "");
        //cookieIdentifiant.Expires = DateTime.Now.AddDays(-1);
        //System.Web.HttpContext.Current.Response.Cookies.Add(cookieIdentifiant);
        //HttpCookie cookieMotDePasse = new HttpCookie("xol_mp", "");
        //cookieMotDePasse.Expires = DateTime.Now.AddDays(-1);
        //System.Web.HttpContext.Current.Response.Cookies.Add(cookieMotDePasse);
    }
}