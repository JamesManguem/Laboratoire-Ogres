using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Ogres
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Console des ogres");
            try
            {
                TableOgres p = new TableOgres();
                p.Afficher = (s) =>
                {
                    Console.Clear();
                    Console.WriteLine(InfoThread() + Environment.NewLine + s);
                };
                p.DemarrerOgres();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
            Console.ReadKey();
        }

        public static string InfoThread()
        {
            Thread t = Thread.CurrentThread;
            return $"[Thread ID : {t.ManagedThreadId} , " +
                $"Priorité : {t.Priority}, " +
                $"Est background : {t.IsBackground}]";
        }
    }
}
