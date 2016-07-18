using log4net;
using log4net.Config;
// Pour utiliser les sessions utilisateurs ds méthode static
using System.Web.SessionState;
using System.Web;
// BDD
using PortailDAS;
// Pour utiliser datetime
using System;
using System.IO;

// Spécifier le fichier de config de log4net
[assembly: XmlConfigurator(ConfigFile = "web.config")]

/// <summary>
/// Classe d'instanciation de Log4Net. GetLogger agit comme un singleton
/// </summary>
public static class Log
{
    public const string DEBUT = "Début";
    public const string FIN = "Fin";
    public const string PARSE_XML = "ParseXML";

    public static ILog versFichier
    {
        get
        {
            // Création du nom du fichier de log
            HttpSessionState Session = ((HttpSessionState)HttpContext.Current.Session);
            HttpApplicationState Application = ((HttpApplicationState)HttpContext.Current.Application);

            string identifiant = "NonAuthentifié";
            string numeroUtilisateur = "00000";
            if (Session != null && Session["compteUtilisateur"] != null)
            {
                identifiant = ((Compte)Session["compteUtilisateur"]).login;
                numeroUtilisateur = ((Compte)Session["compteUtilisateur"]).login.ToString();
            }


           // changerFichierDestinationDeLAppenderFichierAppender("[" + numeroUtilisateur + "]" + identifiant + ".log");

            return LogManager.GetLogger("FichierLogger");
        }
    }

    /// <summary>
    /// Modifier dynamiquement le nom du fichier dans lequel seront loguer les messages, pour l'appender FichierAppender
    /// </summary>
    /// <param name="nouveauNomFichier"></param>
    private static void changerFichierDestinationDeLAppenderFichierAppender(string nouveauNomFichier, bool journalier = true)
    {
        // Trouver l'appender pour vers les fichiers
        int cpt = 0;
        while (log4net.LogManager.GetRepository().GetAppenders()[cpt].Name != "FichierAppender")
        {
            cpt++;
        }

        // Affectation du chemin à l'appender
        if (journalier)
        {
            ((log4net.Appender.FileAppender)log4net.LogManager.GetRepository().GetAppenders()[cpt]).File =
                AppDomain.CurrentDomain.BaseDirectory +
                "App_Data\\log\\" +
                DateTime.Today.Year + "-" +
                    ((DateTime.Today.Month.ToString().Length == 1) ? "0" : "") + DateTime.Today.Month + "-" +
                    ((DateTime.Today.Day.ToString().Length == 1) ? "0" : "") + DateTime.Today.Day + "\\" +
                nouveauNomFichier
            ;
        }
        else
        {
            ((log4net.Appender.FileAppender)log4net.LogManager.GetRepository().GetAppenders()[cpt]).File = AppDomain.CurrentDomain.BaseDirectory + "app_data\\log\\" + nouveauNomFichier;
        }

        // Rafraichissement de l'appender
        ((log4net.Appender.FileAppender)log4net.LogManager.GetRepository().GetAppenders()[cpt]).ActivateOptions();
    }




}