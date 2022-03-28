using System;
using System.Collections.Generic;
using System.Text;

namespace Ogres.Modeles
{
    public partial class Plat
    {
        public int PlatId { get; set; }
        public DateTime DateCreation { get; set; }
        public int Taille { get; set; }

        public string Nom { get; set; }
        public override string ToString()
        {
            return $"[{PlatId},{DateCreation},{Taille},{Nom}]";
        }
    }
}
