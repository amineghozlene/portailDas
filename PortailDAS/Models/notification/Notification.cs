using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortailDAS
{
    public class Notification
    {
        public virtual DateTime dateCreation { get; set; }
        public static Notification rechercheNotificationParCompte(Compte compte)
        {
            Notification notification = null;
            foreach (Notification notif in AccueilController.notification)
            {
                if (notif is Compte)
                {
                    if (((Compte)notif).idSociete.Equals(compte.idSociete)) { 
                    notification = notif;
                    break;
                    }
                }
            }
            return notification;
        }
        public static Notification rechercheNotificationParService(Compte compte)
        {
            Notification notification = null;
            foreach (Notification notif in AccueilController.notification)
            {
                if (notif is DemandeService)
                {
                    if (((DemandeService)notif).idCompte.idSociete.Equals(compte.idSociete))
                    {
                        notification = notif;
                        break;
                    }
                }
            }
            return notification;
        }
        public static void supprimer(Notification not)
        {
            AccueilController.notification.Remove(not);
           
        }
        public static void recupererNotificationInscription(Compte cpt)
        {
            
                IList<Compte> list = CompteDAO.recupererdemandeValidationCompteElearning(cpt);
            
                foreach (Compte elm in list)
                {
                if (!AccueilController.notification.Contains(elm))
                        AccueilController.notification.Add(elm);
                }
            
        }
        public static void recupererNotificationDemandeAchat(Compte cpt)
        {
            IList<DemandeService> list = DemandeServiceDAO.recupererDemandesServices(cpt);
            foreach (DemandeService elm in list)
            {
                bool testc = false;
                foreach (Notification notf in AccueilController.notification)
                {
                    if(notf is DemandeService)
                    {
                        if (((DemandeService)notf).idOrderService==elm.idOrderService)
                        {
                            testc = true;
                            break;
                        }
                    }
                }
                    
                if (testc==false)
                    AccueilController.notification.Add(elm);
            }
        }
    }
}