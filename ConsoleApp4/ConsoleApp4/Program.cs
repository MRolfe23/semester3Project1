using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] college = new string[8, 5] {
                { "(Okalahoma State)", "(Louisville)", "(UCLA)", "(Southern California)", "(Oklahoma)" },

                { "(Penn State)", "(LSU)", "(Stanford)", "(Southern California)", "(Alabama)" },

                { "(Oklahoma State)", "(Okalahoma State)", "(Oklahoma State)", "(Memphis)", "(Alabama)" },

                { "(Washington)", "(Washington)", "(Florida)", "(Alabama)", "(Stanford)" },

                { "(Florida State)", "(Florida State)", "}(Ohio State)", "(Alabama)", "(Colorado)" },

                { "(Oklahoma)", "(So. Dakota State)", "(NC State)", "(Penn State", "(Wisconsin)" },

                { "(Georgia)", "(Virgina Tech)", "(Clemson)", "(Clemson)", "(Texas)" },

                { "(Oklahoma)", "(UCLA)", "(Western Michigan)", "(Texas)", "(Notre Dame)" }
            };
            string[,] draftPicks = new string[8, 5] {
                { "Mason Rudolph", "Lamar Jackson", "Josh Rosen", "Sam Darnold", "Baker Mayfield" },

                { "Saquon Barkley", "Derrius Guice", "Bryce Love", "Ronald Jones II", "Damien Harris" },

                { "Courtland Sutton", "James Washington", "Marcell Ateman", "Anthony Miller", "Calvin Ridley" },

                { "Maurice Hurst", "Vita Vea", "Taven Bryan", "Da'Ron Payne", "Harrison Phillips" },

                { "Joshua Jackson", "Derwin James", "Denzel Ward", "Minkah Fitzpatrick", "Isiaiah Oliver" },

                { "Mark Anderson", "Dallas Goedert", "Jaylen Samuels", "Mike Gesicki", "Troy Fumagalli" },

                { "Roquan Smith", "Tremaine Edmund", "Kendall Joseph", "Dorian O'Daniel", "Malik Jefferson" },

                { "Orlando Brown", "Kolton Miller", "Chukwuma Okorafor", "Connor Williams", "Mike McGlinchey" }
            };
            int[,] draftPrice = new int[8, 5] {
                { 26400000, 20300100, 17420300, 13100145, 10300000 },

                { 24500100, 19890200, 18700800, 15000000, 11600400 },

                { 23400000, 21900300, 19300230, 13400230, 10000000 },

                { 26200300, 22000000, 16000000, 18000000, 13000000 },

                { 24000000, 22500249, 20000100, 16000200, 11899999 },

                { 27800900, 21000800, 17499233, 27900200, 14900333 },

                { 22900300, 19000590, 18000222, 12999999, 10000100 },

                { 23000000, 20000000, 19400000, 16200700, 15900000 }
            };



            double funds = 95000000;
            int position;
            int draftee;
            string pick;

            int SENTINAL = 1;
            int rowCount = 8;
            int columCount = 5;
            int x, y, i = 0;

            string[] finalPicks = new string[5] { "", "", "", "", "" };

            housekeeping();
            Console.ReadKey();

            for (x = 0; x < rowCount; x++)
            {
                for (y = 0; y < columCount; y++)
                {
                    Console.WriteLine($"[{x},{y}] {draftPicks[x, y]} {college[x, y]} ${draftPrice[x, y]}");
                }
                Console.WriteLine(" \n");
            }
            Console.WriteLine("");
            while (SENTINAL != -1 && i < 5)
            {

                position = pickX();
                draftee = pickY();
                pick = draftPicks[position, draftee];

                for (x = 0; x < finalPicks.Length; x++)
                {
                    if (finalPicks[x] == pick)
                    {
                        while (finalPicks[x] == pick)
                        {
                            Console.WriteLine("The player you have selected has already been picked!");
                            Console.WriteLine("Please make a new selection");
                            position = pickX();
                            draftee = pickY();
                            pick = draftPicks[position, draftee];
                        }
                    }
                }
                finalPicks[i] = pick;
                i++;
                Console.WriteLine("Would you like to make another selection?");
                funds = funds - draftPrice[position, draftee];
                Console.WriteLine("Your remaining funds are $" + funds);
                SENTINAL = SENTIANALLOOP();
            }
            for (x = 0; x < finalPicks.Length; x++)
            {
                if (funds > 65000000)
                {
                    if (finalPicks[x] == draftPicks[0, 0] || finalPicks[x] == draftPicks[0, 1] || finalPicks[x] == draftPicks[0, 2] || finalPicks[x] == draftPicks[1, 0] || finalPicks[x] == draftPicks[1, 1] || finalPicks[x] == draftPicks[1, 2] || finalPicks[x] == draftPicks[2, 0] || finalPicks[x] == draftPicks[2, 1] || finalPicks[x] == draftPicks[2, 2] || finalPicks[x] == draftPicks[3, 0] || finalPicks[x] == draftPicks[3, 1] || finalPicks[x] == draftPicks[3, 2] || finalPicks[x] == draftPicks[4, 0] || finalPicks[x] == draftPicks[4, 1] || finalPicks[x] == draftPicks[4, 2] || finalPicks[x] == draftPicks[5, 0] || finalPicks[x] == draftPicks[5, 1] || finalPicks[x] == draftPicks[5, 2] || finalPicks[x] == draftPicks[6, 0] || finalPicks[x] == draftPicks[6, 1] || finalPicks[x] == draftPicks[6, 2] || finalPicks[x] == draftPicks[7, 0] || finalPicks[x] == draftPicks[7, 1] || finalPicks[x] == draftPicks[7, 2])
                    {
                        Console.WriteLine("Good selections! \nCost Effective");
                    }
                }
            }
            Console.WriteLine("Here is the list of your final picks");
            Console.WriteLine("====================================");
            for (x = 0; x < 5; x++)
            {
                Console.WriteLine((x+1) + ") {0}", finalPicks[x]);
            }
            Console.WriteLine("Program has concluded....");
            Console.ReadKey();
        }
        // methods
        public static void housekeeping()
        {
            Console.WriteLine("Welcome to the official NFL draft pick");
            Console.WriteLine("This program will allow you to select available players and display balance remaining for draft picks");
            Console.WriteLine("");
            Console.WriteLine("Please hit enter to start the program");
        }
        public static int pickX()
        {
            int pos;

            Console.WriteLine("Please enter 0-7 for which postion you want to pick from: ");
            pos = Convert.ToInt32(Console.ReadLine());
            while (pos != 0 && pos != 1 && pos != 2 && pos != 3 && pos != 4 && pos != 5 && pos != 6 && pos != 7)
            {
                Console.WriteLine("*****Incorrect entry*****");
                Console.WriteLine("Please enter 0-7 for which postion you want to pick from: ");
                pos = Convert.ToInt32(Console.ReadLine());
            }
            return pos;
        }
        public static int pickY()
        {
            int draf;

            Console.WriteLine("Please enter 0-4 for which colum you want to pick from: ");
            draf = Convert.ToInt32(Console.ReadLine());
            while (draf != 0 && draf != 1 && draf != 2 && draf != 3 && draf != 4)
            {
                Console.WriteLine("*****Incorrect entry*****");
                Console.WriteLine("Please enter 0-4 for which colum you want to pick from: ");
                draf = Convert.ToInt32(Console.ReadLine());
            }
            return draf;
        }
        public static int SENTIANALLOOP()
        {
            int SENT;

            Console.WriteLine("Enter 1 to continue or -1 to exit: ");
            SENT = Convert.ToInt32(Console.ReadLine());
            while (SENT != 1 && SENT != -1)
            {
                Console.WriteLine("*****Incorrect entry*****");
                Console.WriteLine("Enter 1 to continue or -1 to exit: ");
                SENT = Convert.ToInt32(Console.ReadLine());
            }
            return SENT;
        }
    }
}