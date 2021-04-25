using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DolgozoProjekt
{
    class Program
    {
        public struct tordeltAdatok
        {
            public string vezetknev;
            public string keresztnev;
            public string nem;
            public int eletkor;
            public int fizetes;
        }
        static List<tordeltAdatok> listaAdatok = new List<tordeltAdatok>();
        static StreamReader sr = new StreamReader("adatok.txt");
        static tordeltAdatok tra = new tordeltAdatok();
        static int adatokSzama = 1000;
        static void Main(string[] args)
        {
            string adat;
            while (!sr.EndOfStream)
            {
                adat = sr.ReadLine();
                for (int i = 0; i < 1000; i++)
                {
                    string[] felszabdaltAdat = adat.Split(' ');
                    tra.vezetknev = felszabdaltAdat[0];   
                    tra.keresztnev = felszabdaltAdat[1];   
                    tra.nem = felszabdaltAdat[2];   
                    tra.eletkor = int.Parse(felszabdaltAdat[3]);
                    tra.fizetes = int.Parse(felszabdaltAdat[4]);

                    listaAdatok.Add(tra);
                }
            }
            sr.Close();

            feladat3();
            feladat4();
            feladat5();
            feladat6();

            Console.ReadKey();
        }
        private static void feladat6()
        {
            Console.Write("Kérem adjon meg egy összeget: "); 
            int bekertSzam = int.Parse(Console.ReadLine());
            bool nagyobbVagyNem = false;

            for (int i = 0; i < adatokSzama; i++)
            {
                if (bekertSzam < tra.fizetes)
                {
                    nagyobbVagyNem = true;
                }
            }
            if (nagyobbVagyNem == true)
            {
                Console.WriteLine("Van olyan dolgozó, akinek a fizetése {0} Ft felett van", bekertSzam);
            }
            else
            {
                Console.WriteLine("Nincs olyan dolgozó, akinek a fizetése {0} Ft felett van", bekertSzam);
            }
        }

        private static void feladat5()
        {
            int fizetesMax = 0;
            for (int i = 0; i < adatokSzama; i++)
            {
                if (tra.fizetes > fizetesMax)
                {
                    fizetesMax = tra.fizetes;
                }
            }
            Console.WriteLine("A legnagyobb fizetésű dolgozó adatai: \nNeve: {0} {1} \nNem: {2} \nÉletkor: {3} \nFizetés: {4} {5}", tra.vezetknev, tra.keresztnev, tra.nem, tra.eletkor, tra.fizetes, "Ft"); 
        }

        private static void feladat4()
        {
            int huszonOtevAlattiakFizetes = 0;
            for (int i = 0; i < adatokSzama; i++)
            {
                if (tra.eletkor < 25)
                {
                    huszonOtevAlattiakFizetes = huszonOtevAlattiakFizetes + tra.fizetes;
                }
            }
            Console.WriteLine("4.feladat: 25 év alattiak összfizetése: {0} Ft", huszonOtevAlattiakFizetes); 
        }

        private static void feladat3()
        {
            int traFelvittErtek = 5;
            int dolgozokSzama = 0;
            for (int i = 0; i < listaAdatok.Count; i++)
            {
                dolgozokSzama++;
            }
            Console.WriteLine("3.feladat: Dolgozók száma: {0}", dolgozokSzama / traFelvittErtek);
        }
    }
}
