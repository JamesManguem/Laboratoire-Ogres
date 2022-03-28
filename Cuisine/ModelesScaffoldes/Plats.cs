using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Cuisine.Modeles
{
    public partial class Plats
    {
        public int PlatId { get; set; }
        public DateTime DateCreation { get; set; }
        public int Taille { get; set; }
        public string Nom { get; set; }

       
    }
}
