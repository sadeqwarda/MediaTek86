using MediaTek86.bddmanager;
using MediaTek86.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTek86.dal
{
    /// <summary>
    /// Accès aux données des absences et des motifs
    /// </summary>
    public class AbsenceAccess
    {
        private readonly BddManager bddManager;
        private readonly string connectionString =
    "Server=localhost;Database=mediatek86;Uid=root;Pwd=;";
        public AbsenceAccess()
        {
            bddManager = BddManager.GetInstance(connectionString);
        }
        public List<Motif> GetLesMotifs()
        {
            string req = "SELECT idmotif, libelle FROM motif ORDER BY libelle;";
            List<Dictionary<string, object>> records = bddManager.ReqSelect(req);
            List<Motif> lesMotifs = new List<Motif>();
            foreach (Dictionary<string, object> record in records)
            {
                lesMotifs.Add(new Motif()
                {
                    Idmotif = Convert.ToInt32(record["idmotif"]),
                    Libelle = record["libelle"].ToString()
                });
            }
            return lesMotifs;
        }
        public List<Absence> GetLesAbsences(Personnel personnel)
        {
            string req = "SELECT a.datedebut, a.datefin, m.idmotif, m.libelle " +
            "FROM absence a INNER JOIN motif m ON a.idmotif = m.idmotif " +
            "WHERE a.idpersonnel = @idpersonnel " +
            "ORDER BY a.datedebut DESC;";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
{
{ "@idpersonnel", personnel.Idpersonnel }
};
            List<Dictionary<string, object>> records = bddManager.ReqSelect(req, parameters);
            List<Absence> lesAbsences = new List<Absence>();
            foreach (Dictionary<string, object> record in records)
            {
                lesAbsences.Add(new Absence()
                {
                    Personnel = personnel,
                    Datedebut = Convert.ToDateTime(record["datedebut"]),
                    Datefin = Convert.ToDateTime(record["datefin"]),
                    Motif = new Motif()
                    {
                        Idmotif = Convert.ToInt32(record["idmotif"]),
                        Libelle = record["libelle"].ToString()
                    }
                });
            }
            return lesAbsences;
        }
        public void AjoutAbsence(Absence absence)
        {
            string req = "INSERT INTO absence(idpersonnel, datedebut, datefin, idmotif) " +
            "VALUES(@idpersonnel, @datedebut, @datefin, @idmotif);";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
{
{ "@idpersonnel", absence.Personnel.Idpersonnel },
{ "@datedebut", absence.Datedebut },
{ "@datefin", absence.Datefin },
{ "@idmotif", absence.Motif.Idmotif }
};
            bddManager.ReqUpdate(req, parameters);
        }
        public void ModifAbsence(Absence absence, DateTime ancienneDateDebut)
        {
            string req = "UPDATE absence SET datedebut=@datedebut, datefin=@datefin, idmotif=@idmotif " +
            "WHERE idpersonnel=@idpersonnel AND datedebut=@ancienneDateDebut;";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
{
{ "@idpersonnel", absence.Personnel.Idpersonnel },
{ "@ancienneDateDebut", ancienneDateDebut },
{ "@datedebut", absence.Datedebut },
{ "@datefin", absence.Datefin },
{ "@idmotif", absence.Motif.Idmotif }
};
            bddManager.ReqUpdate(req, parameters);
        }
        public void SupprAbsence(Absence absence)
        {
            string req = "DELETE FROM absence WHERE idpersonnel=@idpersonnel AND datedebut=@datedebut;";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
{
{ "@idpersonnel", absence.Personnel.Idpersonnel },
{ "@datedebut", absence.Datedebut }
};
            bddManager.ReqUpdate(req, parameters);
        }
    }
}
