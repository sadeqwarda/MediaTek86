using System;

namespace MediaTek86.model
{
    public class Absence
    {
        public Personnel Personnel { get; set; }
        public DateTime Datedebut { get; set; }
        public DateTime Datefin { get; set; }
        public Motif Motif { get; set; }
    }
}