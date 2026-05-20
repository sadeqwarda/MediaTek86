namespace MediaTek86.model
{
    public class Personnel
    {
        public int Idpersonnel { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        public Service Service { get; set; }

        public string NomPrenom
        {
            get { return Nom + " " + Prenom; }
        }
    }

}