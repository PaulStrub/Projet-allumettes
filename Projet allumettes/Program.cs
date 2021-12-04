using System;
using System.Threading;

namespace Projet_allumettes
{
    class Program
    {
        static void Main()
        {
            LvlChoice();
        }

        //Lvl choice is a function wich permit to the player to decide the difficulty and if (s)he want to play on 1v1 mode or ia mode
        public static void LvlChoice()
        {
            Console.WriteLine("Helloooo jeune participant bienvenu dans ce jeu des allumettes au menu aujourd'hui de la joie de la bonne humeur mais aussi de la difficulté. Tu vas devoir choisir un mode de jeux parmis ceux proposés :");
            
            ChoiceLvlRead();
        }



        
        public static bool playerTurn()
        {

        }




        //this function is for IA mode easy wich withdraw random number of stick
        static void IaEasy()
        {
            int numAllumette = choixLigne();
            int[] tab = initTable(numAllumette);
            Random rand = new Random();
            int turnStart = rand.Next(1, 2);
            bool winPlayer = false;
            bool winIa = false;
            printTab(tab);
            while (winIa == false || winPlayer == false  )
            {
                if (turnStart == 1)
                {
                    winIa = playerTurn();
                }
                else
                {
                    winPlayer = IaEasyTurn(tab);
                }
            }
            if (winPlayer == true) {
                victory();
            }
            else
            {
                defeat();
            }
        }

        // this function make turn of the IA

        static bool IaEasyTurn(int[] tab)
        {
            Random rand = new Random();
            int allumetteRangée = rand.Next(1, tab.Length);
            while (tab[allumetteRangée] == 0)
            {
                allumetteRangée = rand.Next(1, tab.Length);
            }
            Random randAllumette = new Random();
            int allumette = randAllumette.Next(1, tab[allumetteRangée]);
            tab[allumetteRangée] = tab[allumetteRangée] - allumette;
            Console.WriteLine("au tour de l'Ia");
            Thread.Sleep(2000);
            Console.WriteLine("L'IA enlève " + allumette + " allumettes à la " + allumetteRangée + " ligne");
            printTab(tab);
            int win = testTab(tab);
            if (win > 0)
            {
                return (true);
            }
            else
            {
                return (false);
            }
            

        }

        //test if it rest some allumette in the tab 
        static int testTab(int[] tab)
        {
            int NumCol = 0;
            for (int i =1; i> tab.Length; i++)
            {
                if (tab[i] > 0)
                {
                    NumCol = NumCol + 1;
                }
                
            }
            return (NumCol);
        }

        //win of the player 
        static void victory()
        {
            Console.WriteLine("Bravo Vous avez gagné ! GG EZ ! tu veux rejoué ?");
            EndGame();
        }

        //lose of the player 
        static void defeat()
        {
            Console.WriteLine("Ho nonnnnn vous avez perdu c'est DOMMAGE voulez vous essayer à nouveau ?");
            EndGame();
        }

        //end of the game 
        static void EndGame()
        {
            string answer = Console.ReadLine();
            while (answer != "oui" || answer != "non")
            {
                answer = Console.ReadLine();
            }
            if (answer == "oui")
            {
                ChoiceLvlRead();
            }
            else
            {

            }
        }

        static void IaMedium()
        {
            int numAllumette = choixLigne();
            int[] tab = initTable(numAllumette);
            Random rand = new Random();
            int turnStart = rand.Next(1, 2);
            bool winPlayer = false;
            bool winIa = false;
            printTab(tab);
            while (winIa == false || winPlayer == false)
            {
                if (turnStart == 1)
                {
                    winIa = playerTurn();
                }
                else
                {
                    winPlayer = IaMediumTurn(tab);
                }
            }
            if (winPlayer == true)
            {
                victory();
            }
            else
            {
                defeat();
            }
        }

    
        static bool IaMediumTurn(int[] tab)
        {
            int testTab(tab)
            int allumetteRangée = rand.Next(1, tab.Length);
            while (tab[allumetteRangée] == 0)
            {
                allumetteRangée = rand.Next(1, tab.Length);
            }
            Random randAllumette = new Random();
            int allumette = randAllumette.Next(1, tab[allumetteRangée]);
            tab[allumetteRangée] = tab[allumetteRangée] - allumette;
            Console.WriteLine("au tour de l'Ia");
            Thread.Sleep(2000);
            Console.WriteLine("L'IA enlève " + allumette + " allumettes à la " + allumetteRangée + " ligne");
            printTab(tab);
            int win = testTab(tab);
            if (win > 0)
            {
                return (true);
            }
            else
            {
                return (false);
            }


        }

        static void IaHard()
        {
            int numAllumette = choixLigne();
            int[] tab = initTable(numAllumette);
            Random rand = new Random();
            int turnStart = rand.Next(1, 2);
            bool win = false;
            printTab(tab);
            while (win = !true)
            {
                if (turnStart == 1)
                {
                    win = playerTurn();
                }
                else
                {
                    win = IaHardTurn();
                }
            }
            victory();


        }


        //cette fonction retourne si le console.Readline est bien un int impaire 
        static int choixLigne()
        {
            Console.WriteLine("choisis la base en nombre d'allumettes que tu veux ATTENTION : il faut que la bse soit impaire et aussi qu'elle soit supérieur à 5");
            int numAllumette = int.Parse(Console.ReadLine());
            try
            {
                if (numAllumette%2 == 1 && numAllumette>=5)
                {
                    return (numAllumette);
                    
                }
                else
                {
                    Console.WriteLine("il nous faut un nombre impaire d'allumette à la base pour commencer le jeu et supérieur à 5 sinon c'est pas rigolo");
                    return (choixLigne());
                }
            }
            catch
            {
                Console.WriteLine("bien tenté mais redonne nous un nombre ");
                return (choixLigne());
            }
                }

        // créé un tableau avec le nombre de batons par ligne 
        static int[] initTable(int numAllumette)
        {
            float value = (numAllumette / 2 + 0.5f);
            int[] tableau =new int[(int)value+1];
            tableau[0] = numAllumette;
            int numPerLign = numAllumette;
            for (int i = (int)value+1; i > 1; i--)
            {
                tableau[i] = numPerLign;
                numPerLign = numPerLign - 2;
            }
            return (tableau);
        }

        //affiche le graphique avec les allumettes encore présentes
        static void printTab(int[] tableau)
        {
            Console.WriteLine("Voici le tableau actuel : ");
            int tablength = tableau.Length;
            for (int i = (tablength); i >=1 ; i--) {
                if (i==1 || i == (tablength) + 1)
                {
                    for (int j = 0; j <= tableau[0] + 1; j++) {
                        Console.Write("-");
                    }
                }
                else
                {
                    PrintLignAllumette(tableau[i],tableau[0]);
                }
                    }
        }

        //affiche ligne par ligne les allumettes 
        static void PrintLignAllumette(int numPerLign,int numBase)
        {
            if (numPerLign % 2 == 1)
            {
                Console.Write("|");
                for (int i = 0; i < (numBase - numPerLign) / 2; i++)
                {
                    Console.Write(" ");
                }
                for (int i =0; i < numPerLign; i++)
                {
                    Console.Write("I");
                }
                for (int i = 0; i < (numBase - numPerLign) / 2; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("|");
            }
            else
            {
                Console.Write("|");
                for (int i = 0; i <= (numBase - numPerLign +0.5) / 2; i++)
                {
                    Console.Write(" ");
                }
                for (int i = 0; i < numPerLign; i++)
                {
                    Console.Write("I");
                }
                for (int i = 0; i < (numBase - numPerLign) / 2; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("|");
            }
        }


        static void ChoiceLvlRead()
        {
            Console.WriteLine(" 1 :   1vs1 mode");
            Console.WriteLine(" 2 :   ia mode difficulté facile");
            Console.WriteLine(" 3 :   ia mode difficulté moyenne");
            Console.WriteLine(" 4 :   ia mode difficulté hardcore");
            int num = 0;
            try
            {
                num = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Il nous faut un nombre et non du texte ^^'");
                ChoiceLvlRead();
            }
            if (num == 1)
            {

            }
            if (num == 2)
            {
                IaEasy();
            }
            if (num == 3)
            {
                IaMedium();
            }
            if (num == 4)
            {
                IaHard();
            }
            else
            {
                Console.WriteLine("Il nous faut un nombre entre 1 et 4 pour continuer ^^'");
                ChoiceLvlRead();
            }
        }


        

    }
}
/*for (int i = 0; i < 5; i++)
           {
               Console.WriteLine("Sleep for 2 seconds.");
               Thread.Sleep(2000);
           }

           Console.WriteLine("Main thread exits.");*/