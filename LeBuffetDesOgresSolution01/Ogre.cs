using Ogres.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ogres
{
    public class Ogre
    {
        private Plat platSeFaisantManger;

        public string Name { get; set; }

        public Action AnnoncerChangement { get; set; }

        private readonly BuffetBDContext contexte = new BuffetBDContext();

        private static readonly object verrouChoixPlat = new object();

        public Ogre(string name)
        {
            Name = name;
        }

        public void Demarrer()
        {
            while (true) // Manger pour l'éternité
            {
                platSeFaisantManger = PrendrePlat();
                bool etatChange = platSeFaisantManger != null;

                if (etatChange)
                    AnnoncerChangement();

                // Attendre 10 millisecondes si le plat est nul, sinon on va bombarder la BD
                Thread.Sleep(etatChange ? platSeFaisantManger.Taille : 10);

                platSeFaisantManger = null;

                if (etatChange)
                    AnnoncerChangement();
            }
        }

        private Plat PrendrePlat()
        {
            Plat p = null;

            lock (verrouChoixPlat) // Verrou partagé avec tous les ogres
            {
                p = contexte.Plats.FirstOrDefault();
                if (p != null)
                {
                    contexte.Plats.Remove(p);
                    contexte.SaveChanges();
                }
            }
            return p;
        }

        public override string ToString()
        {
            return Name + " mange " + platSeFaisantManger;
        }
    }
}
