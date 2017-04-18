using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace benzinkut_frontendart
{
    class Program
    {
        static void Main(string[] args)
        {
            int benzinkutSzamMax = 10; // Benzinkutak maximális száma
            int tavolsagMax = 100; // Benzinkutak maximális távolsága egymáshoz képest

            Random rnd = new Random();
            int benzinkutSzam = rnd.Next(1, benzinkutSzamMax); // Benzinkutak száma, ténylegesen ennyi benzinkút van
            int osszTavolsag = 0; // Távolság összesen a benzinkutak között ténylegesen
            #region Teszt
            // Benzinkútak számának manuális beállítása
            benzinkutSzam = 5;
            #endregion
            int[] tavolsag = new int[benzinkutSzam]; // Megmutatja, hogy a következő benzinkútig mennyi a távolság
            int[] benzin = new int[benzinkutSzam]; // Üzemanyag a benzinkutakon
            int benzinKocsi = 0; // Üzemanyag a kocsiban
            bool lehetseges = true; // Lehetséges-e megcsinálni a feladatot

            // Feltölti véletlenszerű számokkal a tavolsag tömböt, ami megmutatja, mennyi a távolság egyes benzinkutak között
            // Összeadja az összes távolságot az osszTavolsag nevű változóba
            for (int i = 0; i < benzinkutSzam; i++)
            {
                tavolsag[i] = rnd.Next(1, tavolsagMax);
                osszTavolsag += tavolsag[i];
            }

            // Feltételezzük, hogy 1 egység távolsághoz 1 egység üzemanyag jár, valamint hogy a kocsi üzemanyag tankja = benzinOssz értékével
            int benzinOssz = osszTavolsag; // Benzin összesen
            int maradekBenzin = benzinOssz; // Maradék benzin, kezdetben ugyanannyi, mint az összes benzin

            // Feltölti véletlenszerű számokkal a benzin tömböt, ami megmutatja, hogy mennyi üzemanyag van a benzinkutakon
            // A jelenlegi kútnál lévő üzemanyag mennyiséget kivonjuk a maradekBenzin változóból, így megkapjuk, hogy
            //          mennyi üzemanyagot használhatunk fel a többi benzinkútnál
            for(int i = 0; i < benzinkutSzam; i++)
            {
                benzin[i] = rnd.Next(0, maradekBenzin);
                maradekBenzin -= benzin[i];
            }

            #region Teszt
            // Távolságok megadása manuálisan
            tavolsag[0] = 10;
            tavolsag[1] = 5;
            tavolsag[2] = 15;
            tavolsag[3] = 10;
            tavolsag[4] = 10;
            // Üzemanyag megadása manuálisan
            benzin[0] = 10;
            benzin[1] = 10;
            benzin[2] = 10;
            benzin[3] = 10;
            benzin[4] = 10;
            // Összes távolság és üzemanyag beállítása
            osszTavolsag = 50;
            benzinOssz = 50;
            maradekBenzin = 0;
            #endregion

            // Ez a for ciklus azért kell, hogy segítségével megvizsgáljuk, honnan tud körbemenni az autó
            // Az i változó értékét használjuk kiindulási pontnak
            for (int i = 0; i < benzinkutSzam; i++)
            {
                int j = i;
                // Ezzel a for ciklussal csináljuk meg, hogy "körbe" menjen az autó
                for(int k = 0; k < benzinkutSzam; k++)
                { 
                    
                    #region Teszteléshez kiíratás
                    Console.WriteLine("Benzinkút száma: {0}", j);
                    Console.WriteLine("Üzemanyag a kocsiban érkezéskor: {0}", benzinKocsi);
                    Console.WriteLine("Benzinkúton lévő üzemanyag: {0}", benzin[j]);
                    Console.WriteLine("Távolság a következő benzinkútig: {0}", tavolsag[j]);
                    #endregion
                    

                    benzinKocsi += benzin[j];
                    if (benzinKocsi >= tavolsag[j])
                    {
                        benzinKocsi -= tavolsag[j];
                    }
                    else
                    {
                        lehetseges = false;
                        Console.WriteLine("A következő állomásról indulva nem lehetséges megtenni a kört: {0}", i);
                        break;
                    }
                    j++; // j változó léptetése a következő benzinkúthoz
                    if (j == benzinkutSzam)
                    { // Vizsgáljuk, hogy a körbeért-e az autó, ha igen, akkor j átírása, ugyanis 4 után nem az 5-ös
                        // benzinkút jön, hanem a 0-ás
                        j = 0;
                    }
                    
                    #region Teszteléshez kiíratás
                    Console.WriteLine("Üzemanyag a kocsiban távozáskor: {0}", benzinKocsi);
                    Console.WriteLine("Következő benzinkút száma: {0}", j);
                    Console.WriteLine("Lehetséges? {0}\n", lehetseges);
                    #endregion
                    
                }
                Console.WriteLine("=======================================");
            }
            if (lehetseges)
                Console.WriteLine("Lehetséges minden benzinkútról indulva");

            // Tömbök kiíratása
            Console.WriteLine("Távolság tömb:");
            Console.WriteLine(string.Join(",", tavolsag));
            Console.WriteLine("Üzemanyag tömb:");
            Console.WriteLine(string.Join(",", benzin));
            Console.WriteLine("Össz távolság: {0}", osszTavolsag);
            Console.WriteLine("Összes benzin: {0}", benzinOssz);
            Console.ReadLine();
        }
    }
}
