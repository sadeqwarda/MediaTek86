using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTek86.model
{
    /// <summary>
    /// represente un service de la médiathèque
    /// </summary>
    public class Service

    {
        public int Idservice { get; set; }
        public string Nom { get; set; }
        public override string ToString()
        {
            return Nom;
        }
    }
}
