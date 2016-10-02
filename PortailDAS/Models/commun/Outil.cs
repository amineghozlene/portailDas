using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace PortailDAS {

    public class Outil {
        /// <summary>
        /// Envoie de mail au format HTML
        /// </summary>
        /// <param name="expediteur"></param>
        /// <param name="destinataire"></param>
        /// <param name="objet"></param>
        /// <param name="corps"></param>
        /// <returns>True ou false suivant la réussite de l'envoie</returns>
        public static bool envoyerEmail(string destinataire, string objet, string corps) {
            bool resultatEnvoieEmail = false;
            HttpSessionState Session = ((HttpSessionState)System.Web.HttpContext.Current.Session);

            try {
                // Connexion au serveur
                SmtpClient smtp = new SmtpClient();
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                MailMessage mail;
                string[] emailsDestinataires = destinataire.Split(';');
                int cpt = 0;
                int nombreEmailsDestinataires = emailsDestinataires.Count();
                while (cpt < nombreEmailsDestinataires) {
                    // Construction du mail
                    mail = new MailMessage();
                    mail.To.Add(new MailAddress(emailsDestinataires[cpt]));
                    mail.Subject = objet;
                    mail.Body = "aaaa";
                    mail.IsBodyHtml = true;
                    smtp.Send(mail);
                    cpt++;
                }

                resultatEnvoieEmail = true;



            } catch (Exception exception) {
                Log.versFichier.Error("\r\n " +
                    "Classe[Outil]\r\n " +
                    "Fonction[" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]\r\n " +
                    "Exception[" + exception.Message + "]\r\n " +
                    "TargetSite[" + exception.TargetSite + "]\r\n " +
                    "StackTrace[\r\n" + exception.StackTrace + "\r\n ]" +
                    ((exception.InnerException != null) ? "\r\n InnerException[\r\n  " + exception.InnerException + "\r\n ]" : "")
                );
            }

            return resultatEnvoieEmail;
        }

        /// <summary>
        /// Retourne un template de mail dans une chaîne
        /// </summary>
        /// <param name="nomTemplate">Situé dans ressource\templateMail</param>
        /// <returns>Template sous forme de chaîne</returns>
        public static string chargerTemplateEnUneChaine(string cheminDeTemplate) {
            System.IO.Stream unTemplateMail = System.IO.File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + cheminDeTemplate);
            StringBuilder templateString = new StringBuilder();
            string uneLigne;
            using (System.IO.StreamReader lecteur = new System.IO.StreamReader(unTemplateMail)) {
                while ((uneLigne = lecteur.ReadLine()) != null) {
                    templateString.Append(uneLigne);
                }
            }
            return templateString.ToString();
        }
    }
}