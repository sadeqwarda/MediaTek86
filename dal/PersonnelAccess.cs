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
    /// accès aux données PERSONNEL et services
    /// de l'application MediaTeck86
    /// finaliser le 23/05/2026
    /// Warda SADEQ
    /// </summary>
    public class PersonnelAccess
    {
        private readonly BddManager bddManager;
        private readonly string connectionString =
    "Server=localhost;Database=mediatek86;Uid=root;Pwd=;";
        public PersonnelAccess()
        {
            bddManager = BddManager.GetInstance(connectionString);
        }
        public List<Service> GetLesServices()
        {
            string req = "SELECT idservice, nom FROM service ORDER BY nom;";
            List<Dictionary<string, object>> records = bddManager.ReqSelect(req);
            List<Service> lesServices = new List<Service>();
            foreach (Dictionary<string, object> record in records)
            {
                lesServices.Add(new Service()
                {
                    Idservice = Convert.ToInt32(record["idservice"]),
                    Nom = record["nom"].ToString()
                });
            }
            return lesServices;
        }
        public List<Personnel> GetLesPersonnels()
        {
            string req = "SELECT p.idpersonnel, p.nom, p.prenom, p.tel, p.mail, " +
            "s.idservice, s.nom AS nomservice " +
            "FROM personnel p INNER JOIN service s ON p.idservice = s.idservice " +
            "ORDER BY p.nom, p.prenom;";
            List<Dictionary<string, object>> records = bddManager.ReqSelect(req);
            List<Personnel> lesPersonnels = new List<Personnel>();
            foreach (Dictionary<string, object> record in records)
            {
                Service service = new Service()
                {
                    Idservice = Convert.ToInt32(record["idservice"]),
                    Nom = record["nomservice"].ToString()
                };
                lesPersonnels.Add(new Personnel()
                {
                    Idpersonnel = Convert.ToInt32(record["idpersonnel"]),
                    Nom = record["nom"].ToString(),
                    Prenom = record["prenom"].ToString(),
                    Tel = record["tel"].ToString(),
                    Mail = record["mail"].ToString(),
                    Service = service
                });
            }
            return lesPersonnels;
        }
        public void AjoutPersonnel(Personnel personnel)
        {
            string req = "INSERT INTO personnel(nom, prenom, tel, mail, idservice) " +
            "VALUES(@nom, @prenom, @tel, @mail, @idservice);";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
{
    { "@nom", personnel.Nom },
    { "@prenom", personnel.Prenom },
    { "@tel", personnel.Tel },
    { "@mail", personnel.Mail },
    { "@idservice", personnel.Service.Idservice }
};
            bddManager.ReqUpdate(req, parameters);
        }
        public void ModifPersonnel(Personnel personnel)
        {
            string req = "UPDATE personnel SET nom=@nom, prenom=@prenom, tel=@tel, " +
            "mail=@mail, idservice=@idservice WHERE idpersonnel=@idpersonnel;";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
{
    { "@idpersonnel", personnel.Idpersonnel },
    { "@nom", personnel.Nom },
    { "@prenom", personnel.Prenom },
    { "@tel", personnel.Tel },
    { "@mail", personnel.Mail },
    { "@idservice", personnel.Service.Idservice }
};
            bddManager.ReqUpdate(req, parameters);
        }
        public void SupprPersonnel(Personnel personnel)
        {
            string req = "DELETE FROM personnel WHERE idpersonnel=@idpersonnel;";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
{
    { "@idpersonnel", personnel.Idpersonnel }
};
            bddManager.ReqUpdate(req, parameters);
        }
    }
}
    

