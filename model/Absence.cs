using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTek86.model
{
    /// <summary>
    /// represente absence d'un personnel
    /// </summary>
    public class Absence
    {
        public Personnel Personnel {  get; set; }
        public DateTime Datedebut { get; set; }
        public DateTime datefin { get; set; }
        public Motif motif { get; set; }
    }
}
