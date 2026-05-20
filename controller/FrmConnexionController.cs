using MediaTek86.dal;

namespace MediaTek86.controller
{
    public class FrmConnexionController
    {
        private readonly ResponsableAccess responsableAccess;

        public FrmConnexionController()
        {
            responsableAccess = new ResponsableAccess();
        }

        public bool ControleAuthentification(string login, string pwd)
        {
            return responsableAccess.ControleAuthentification(login, pwd);
        }
    }
}