using MediaTek86.bddmanager;
using MediaTek86.model;
using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTek86.dal
{
    /// <summary>
    /// accès aux données PERSONNEL et services
    /// </summary>
    public class PersonnelAccess
    {
        private readonly BddManager bddManager;
        private readonly string connectionString =
        "Server=localhost;Database=mediatek86;Uid=admin;Pwd=admin;";
        public ResponsableAccess()
        {
            bddManager = BddManager.GetInstance(connectionString);
        }
        /// <summary>
        ///Vérifie le login et le MDP du responsable.
        /// </summary>
        public bool ControleAuthentification(string login, string pwd)
        {
            string req = "SELECT login FROM responsable " +
            "WHERE login = @login AND pwd = SHA2(@pwd, 256);";
            Dictionary<string, object> parameters = new Dictionary<string, object>() {
{ "@login", login },
{ "@pwd", pwd }
};
            return bddManager.ReqSelect(req, parameters).Count > 0;
        }
    }
}
