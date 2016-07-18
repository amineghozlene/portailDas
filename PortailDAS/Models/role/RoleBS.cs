using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortailDAS
{
    public static class RoleBS
    {
        public const string SUPER_ADMINISTRATEUR = "SUPER_ADMINISTRATEUR";
        public const string ADMINISTRATEUR_LOGIDAS = "ADMINISTRATEUR_LOGIDAS";
        public const string ADMINISTRATEUR_SAV = "ADMINISTRATEUR_SAV";
        public const string COMPTE_CLIENT = "COMPTE_CLIENT";
        public const string COMPTE_LA_POSTE = "COMPTE_LA_POSTE";
        public const int ISUPER_ADMINISTRATEUR = 1;
        public const int IADMINISTRATEUR_LOGIDAS = 2;
        public const int IADMINISTRATEUR_SAV = 3;
        public const int ICOMPTE_CLIENT = 4;
        public const int ICOMPTE_LA_POSTE = 5;
    }
}