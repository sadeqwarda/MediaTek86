using System.Collections.Generic;
using MediaTek86.bddmanager;

namespace MediaTek86.dal
{
    public class ResponsableAccess
    {
        private readonly BddManager bddManager;

        private readonly string connectionString =
            "Server=localhost;Database=mediatek86;Uid=admin;Pwd=admin;";

        public ResponsableAccess()
        {
            bddManager = BddManager.GetInstance(connectionString);
        }

        public bool ControleAuthentification(string login, string pwd)
        {
            string req = "SELECT login FROM responsable WHERE login = @login AND pwd = SHA2(@pwd, 256);";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@login", login },
                { "@pwd", pwd }
            };

            return bddManager.ReqSelect(req, parameters).Count > 0;
        }
    }
}