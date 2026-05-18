using MediaTek86.dal;
using MediaTek86.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
// controller/FrmPersonnelController.cs
using System.Collections.Generic;using MediaTek86.dal;
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
        public List<Personnel> GetLesPersonnels() { return personnelAccess.GetLesPersonnels(); }
        public List<Service> GetLesServices() { return personnelAccess.GetLesServices(); }
        public void AjoutPersonnel(Personnel personnel) { personnelAccess.AjoutPersonnel(personnel); }
        public void ModifPersonnel(Personnel personnel) { personnelAccess.ModifPersonnel(personnel); }
        public void SupprPersonnel(Personnel personnel) { personnelAccess.SupprPersonnel(personnel); }
    }
}
// controller/FrmAbsencesController.cs
using System;
using System.Collections.Generic;
using MediaTek86.dal;
using MediaTek86.model;
namespace MediaTek86.controller
{
    public class FrmAbsencesController
    {
        private readonly PersonnelAccess personnelAccess;
        private readonly AbsenceAccess absenceAccess;
        public FrmAbsencesController()
        {
            personnelAccess = new PersonnelAccess();
            absenceAccess = new AbsenceAccess();
        }
        public List<Personnel> GetLesPersonnels() { return personnelAccess.GetLesPersonnels(); }
        public List<Motif> GetLesMotifs() { return absenceAccess.GetLesMotifs(); }
        public List<Absence> GetLesAbsences(Personnel personnel) { return absenceAccess.GetLesAbsences(personnel); }
        public void AjoutAbsence(Absence absence) { absenceAccess.AjoutAbsence(absence); }
        public void ModifAbsence(Absence absence, DateTime ancienneDateDebut) { absenceAccess.ModifAbsence(absence, ancienneDateDebut); }
        public void SupprAbsence(Absence absence) { absenceAccess.SupprAbsence(absence); }
    }
}
}
