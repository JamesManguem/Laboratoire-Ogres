using Ogres.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Ogres
{
    class TableOgres
    {
        private static readonly object verrouMiseAJour = new object();
        public const int NB_OGRES = 7;

        private List<Ogre> ogres;

        private readonly BuffetBDContext contexte = new BuffetBDContext();
        public Action<string> Afficher { get; set; }

        public TableOgres() { }

        public void DemarrerOgres()
        {
            ogres = new List<Ogre>();

            for (int i = 0; i < NB_OGRES; i++)
            {
                Ogre o = new Ogre("Ogre #" + i);
                ogres.Add(o);
                o.AnnoncerChangement += MiseAJour; 
                Task task = new Task(o.Demarrer);
                task.ContinueWith( // Gestion des exception si une tâche échoue
                    (t) => Console.Error.WriteLine(t.Exception), 
                    TaskContinuationOptions.OnlyOnFaulted);
                task.Start();
            }
            MiseAJour();
        }

        public void MiseAJour()
        {
            lock (verrouMiseAJour)
            {
                string s = "";

                ogres.ForEach(o => s += o.ToString() + Environment.NewLine);
                s += Environment.NewLine + "Table :" + Environment.NewLine;

                foreach (Plat p in contexte.Plats)
                    s += p + Environment.NewLine;
                Afficher(s);
            }
        }

      
    }
}
