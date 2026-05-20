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

        public List<Personnel> GetLesPersonnels()
        {
            return personnelAccess.GetLesPersonnels();
        }

        public List<Motif> GetLesMotifs()
        {
            return absenceAccess.GetLesMotifs();
        }

        public List<Absence> GetLesAbsences(Personnel personnel)
        {
            return absenceAccess.GetLesAbsences(personnel);
        }

        public void AjoutAbsence(Absence absence)
        {
            absenceAccess.AjoutAbsence(absence);
        }

        public void ModifAbsence(Absence absence, DateTime ancienneDateDebut)
        {
            absenceAccess.ModifAbsence(absence, ancienneDateDebut);
        }

        public void SupprAbsence(Absence absence)
        {
            absenceAccess.SupprAbsence(absence);
        }
    }
}