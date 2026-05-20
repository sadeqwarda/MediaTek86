using System.Collections.Generic;
using MediaTek86.dal;
using MediaTek86.model;

namespace MediaTek86.controller
{
    public class FrmPersonnelController
    {
        private readonly PersonnelAccess personnelAccess;

        public FrmPersonnelController()
        {
            personnelAccess = new PersonnelAccess();
        }

        public List<Personnel> GetLesPersonnels()
        {
            return personnelAccess.GetLesPersonnels();
        }

        public List<Service> GetLesServices()
        {
            return personnelAccess.GetLesServices();
        }

        public void AjoutPersonnel(Personnel personnel)
        {
            personnelAccess.AjoutPersonnel(personnel);
        }

        public void ModifPersonnel(Personnel personnel)
        {
            personnelAccess.ModifPersonnel(personnel);
        }

        public void SupprPersonnel(Personnel personnel)
        {
            personnelAccess.SupprPersonnel(personnel);
        }
    }
}