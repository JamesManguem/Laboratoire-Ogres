using System;
using System.Collections.Generic;
using System.Text;

namespace Cuisine.Modeles
{
    public partial class Plats
    {
        public override string ToString()
        {
            return $"[{PlatId},{DateCreation},{Taille},{Nom}]";
        }
    }
}
