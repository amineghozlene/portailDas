using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortailDAS
{
    public class Notification
    {
        public virtual Compte compte { get; set; }
        public virtual DateTime date { get; set; }
        public virtual Service service { get; set; }
        public static Notification rechercheNotificationParCompte(Compte compte)
        {
            Notification notification = new Notification();
            foreach (Notification notif in AccueilController.notification)
            {
                if (notif.compte.Equals(compte))
                {
                    notification = notif;
                    break;
                }
            }
            return notification;
        }
        public static Notification rechercheNotificationParService(Service service)
        {
            Notification notification = new Notification();
            foreach (Notification notif in AccueilController.notification)
            {
                if (notif.service.Equals(service))
                {
                    notification = notif;
                    break;
                }
            }
            return notification;
        }
    }
}