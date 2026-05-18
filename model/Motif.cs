using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MediaTek86.model
{
    /// <summary>
    /// represente le motif d'absence
    /// </summary>
    public class Motif
    {
        public int Idmotif { get; set; }
        public string Libelle { get; set; }
        public override string ToString()
        {
            return Libelle;
        }
    }
}
