using System.Collections.Generic;
using MediaTek86.bddmanager;

namespace MediaTek86.dal
{
    /// <summary>
    /// Classe permettant l'accès aux données du responsable
    /// de l'application MediaTeck86
    /// finaliser le 23/05/2026
    /// Warda SADEQ
    /// </summary>
    public class ResponsableAccess
    {
        /// <summary>
        /// Gestionnaire de connexion à la base de données
        /// </summary>
        private readonly BddManager bddManager;

        /// <summary>
        /// Chaîne de connexion MySQL
        /// </summary>
        private readonly string connectionString =
            "Server=localhost;Database=mediatek86;Uid=root;Pwd=;";

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public ResponsableAccess()
        {
            // Initialisation du gestionnaire de base de données
            bddManager = BddManager.GetInstance(connectionString);
        }

        /// <summary>
        /// Vérifie l'authentification du responsable
        /// </summary>
        /// <param name="login">Login saisi</param>
        /// <param name="pwd">Mot de passe saisi</param>
        /// <returns>True si authentification valide sinon False</returns>
        public bool ControleAuthentification(string login, string pwd)
        {
            string req = "SELECT login FROM responsable WHERE login = @login AND pwd = SHA2(@pwd, 256);";

            
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@login", login },
                { "@pwd", pwd }
            };

            // Retourne vrai si 1 résultat est trouvé
            return bddManager.ReqSelect(req, parameters).Count > 0;
        }
    }
}