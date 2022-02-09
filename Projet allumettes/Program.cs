using System;
using System.Threading;

namespace Projet_allumettes
{
    class Program
    {
        static void Main() //starting of the app
        {
            LvlChoice();
        }

        
        public static void LvlChoice() //Lvl choice is a function wich permit to the player to decide the difficulty and if (s)he want to play on 1v1 mode or ia mode
        {
            Console.WriteLine("Helloooo jeune participant bienvenu dans ce jeu des allumettes au menu aujourd'hui de la joie de la bonne humeur mais aussi de la difficulté. Tu vas devoir choisir un mode de jeux parmis ceux proposés :");

            ChoiceLvlRead();
        }


        static void Vs() //player versus player, each player play turn by turn
        {
            int numAllumette = choixLigne();
            int[] tab = initTable(numAllumette);
            Random rand = new Random();
            int turnStart = rand.Next(0, 2);
            bool winPlayer = false;
            bool winPlayer2 = false;
            printTab(tab);
            while (winPlayer2 == false && winPlayer == false)
            {
                if (turnStart == 1)
                {

                    winPlayer2 = playerTurn(tab);
                    turnStart = 0;
                }
                else
                {
                    winPlayer = playerTurn(tab);
                    turnStart = 1;
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

        public static bool playerTurn(int[] tab) //player turn he choose the lign anb the number of sticks to take off
        {

            int lign = ChoixLign(tab);
            int numAll = ChoixAll(tab, lign);
            tab[lign] = tab[lign] - numAll;

            Console.Clear();
            printTab(tab);

            int win = testTab(tab);
            if (win == 0)
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        static int ChoixAll(int[] tab, int lign) //choose what stick to take off
        {
            Console.WriteLine("choisis le nombre ou écrit back pour revenir au choix de la ligne");
            string all = Console.ReadLine();
            if (all == "back")
            {
                return (ChoixLign(tab));
            }
            else
            {

                try
                {
                    int numAll = int.Parse(all);
                    if (numAll <= tab[lign])
                    {
                        return (numAll);

                    }
                    else
                    {

                        return (ChoixAll(tab, lign));
                    }
                }
                catch
                {

                    Console.WriteLine("bien tenté mais donne nous un nombre ");
                    return (ChoixLign(tab));
                }
            }
        }

        static int ChoixLign(int[] tab) //ask what lign the player want to choose
        {
            Console.WriteLine("choisis la ligne");
            int lign = int.Parse(Console.ReadLine());

            try
            {
                if (tab[lign] > 0)
                {
                    return (lign);

                }
                else
                {

                    return (ChoixLign(tab));
                }
            }
            catch
            {
                Console.WriteLine("bien tenté mais donne nous un nombre ");
                return (ChoixLign(tab));
            }
        }



        
        static void IaEasy() //this function is for IA mode easy wich withdraw random number of stick
        {
            int numAllumette = choixLigne();
            int[] tab = initTable(numAllumette);
            Random rand = new Random();
            int turnStart = rand.Next(0, 2);
            bool winPlayer = false;
            bool winIa = false;
            printTab(tab);
            while (winIa == false && winPlayer == false)
            {
                if (turnStart == 1)
                {

                    winIa = playerTurn(tab);
                    turnStart = 0;

                }
                else
                {
                    winPlayer = IaEasyTurn(tab);
                    turnStart = 1;

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

        

        static bool IaEasyTurn(int[] tab)// this function make turn of the IA
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

            Console.WriteLine("au tour de l'IA");
            Thread.Sleep(3000);
            Console.Clear();
            Console.WriteLine("L'IA enlève " + allumette + " allumettes à la " + allumetteRangée + " ligne");
            printTab(tab);
            int win = testTab(tab);
            if (win == 0)
            {
                return (true);
            }
            else
            {
                return (false);
            }


        }

        
        static int testTab(int[] tab) //test if it rest some allumette in tab 
        {
            int NumCol = 0;

            for (int i = 1; i < tab.Length; i = i + 1)
            {


                if (tab[i] > 0)
                {

                    NumCol = NumCol + 1;
                }

            }

            return (NumCol);
        }

       
        static void victory()  //win of the player 
        {
            Console.WriteLine("Bravo Vous avez gagné ! GG EZ ! tu veux rejoué ?");
            EndGame();
        }

         
        static void defeat() //lose of the player
        {
            Console.WriteLine("Ho nonnnnn vous avez perdu c'est le second joueur qui gagne, DOMMAGE voulez vous essayer à nouveau ?");
            EndGame();
        }

        
        static void EndGame() //end of the game 
        {

            try
            {
                string answer = Console.ReadLine();
                while (answer != "oui" && answer != "non")
                {
                    answer = Console.ReadLine();
                }
                if (answer == "oui")
                {
                    Console.Clear();

                    ChoiceLvlRead();


                }
                else if (answer == "non")
                {

                    Console.Clear();

                }
            }

            catch
            {

                EndGame();
            }

        }

        static void IaMedium() //this function is for IA mode medium 
        {
            int numAllumette = choixLigne();
            int[] tab = initTable(numAllumette);
            Random rand = new Random();
            int turnStart = rand.Next(0, 2);
            bool winPlayer = false;
            bool winIa = false;
            printTab(tab);
            while (winIa == false && winPlayer == false)
            {
                if (turnStart == 1)
                {
                    winIa = playerTurn(tab);
                    turnStart = 0;
                }
                else
                {
                    winPlayer = IaMediumTurn(tab);
                    turnStart = 1;
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


        static bool IaMediumTurn(int[] tab) // take off random stick until it rest 3 ligns and after play the if(s) conditions
        {
            int numCol = testTab(tab);
            Random rand = new Random();
            int allumetteRangée = rand.Next(1, tab.Length);
            int islignis1 = IsLign1(tab);
            int islignis2 = IsLign1(tab);
            Predicate<int> predicate = ligne;
            if (numCol > 2 && islignis1 > 0)
            {
                tab[islignis1] = 0;
                Console.WriteLine("au tour de l'Ia");
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("L'IA enlève toutes les allumettes à la " + islignis1 + " ligne");
            }
            else if (numCol == 2 && islignis1 > 0)
            {



                allumetteRangée = Array.FindIndex(tab, 1, predicate);
                tab[allumetteRangée] = 0;
                Console.WriteLine("au tour de l'Ia");
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("L'IA enlève les allumettes à la ligne " + allumetteRangée);
            }
            else if (numCol == 2 && islignis2 == 2)
            {
                allumetteRangée = Array.FindIndex(tab, 1, predicate);
                tab[allumetteRangée] = 2;
                Console.WriteLine("au tour de l'Ia");
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("L'IA enlève 1 allumette à la " + allumetteRangée + " ligne ");
            }
            else
            {
                while (tab[allumetteRangée] == 0)
                {
                    allumetteRangée = rand.Next(1, tab.Length);
                }
                Random randAllumette = new Random();
                int allumette = randAllumette.Next(1, tab[allumetteRangée]);
                tab[allumetteRangée] = tab[allumetteRangée] - allumette;
                Console.WriteLine("au tour de l'Ia");
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("L'IA enlève " + allumette + " allumettes à la " + allumetteRangée + " ligne");
            }
            printTab(tab);
            int win = testTab(tab);
            if (win == 0)
            {
                return (true);
            }
            else
            {
                return (false);
            }


        }




        private static bool ligne(int obj) // predicate that return lign which contain more than 1 stick
        {
            return obj > 1;
        }

        public static int IsLign2(int[] tab)
        {
            int plus2 = 0;
            for (int i = 1; i < tab.Length; i++)
            {

                if (tab[i] != 2 && tab[i] >0)
                {
                    plus2 = i;
                }

            }
            return (plus2);
        }

        public static int IsLign1(int[] tab) //return the first lign of the tab wich contain only one stick
        {
            
            for (int i = 1; i < tab.Length; i++)
            {
                if (tab[i] == 1)
                {
                    return (i);
                }

            }
            return (0);
        }

        public static int Full1(int[] tab) //return the number of lign wich contains only one stick
        {
            int num = 0;
            for (int i = 1; i < tab.Length; i++)
            {
                if (tab[i] == 1)
                {
                    num = num + 1;
                }

            }
            return (num);
        }


        static void IaHard() //this function is for IA mode hard
        {
            int numAllumette = choixLigne();
            int[] tab = initTable(numAllumette);
            int[,] arr = createDoubleArray(numAllumette);
            Random rand = new Random();
            int turnStart = rand.Next(0, 2);
            bool winPlayer = false;
            bool winIa = false;
            printTab(tab);
            while (winIa == false && winPlayer == false)
            {
                if (turnStart == 1)
                {
                    winIa = playerTurn(tab);
                    turnStart = 0;
                }
                else
                {
                    winPlayer = IaHardTurn(tab, arr);
                    turnStart = 1;
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

        static bool IaHardTurn(int[] tab, int[,] arr) // Hard Ia which respect if condition even if they can't work
        {
            int numCol = testTab(tab);

            int Numlign1 = Full1(tab);

            Predicate<int> predicate = ligne;
            if (numCol % 2 == 1 && Numlign1 == numCol - 1)
            {
               
                int allumetteRangée = Array.FindIndex(tab, 1, predicate);
                tab[allumetteRangée] = 1;
                Console.WriteLine("au tour de l'Ia");
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("L'IA ne laisse qu'une allumette à la " + allumetteRangée + " ligne ");
            }
            else if (numCol % 2 == 0 && Numlign1 == numCol - 1)
            {
                
                int allumetteRangée = Array.FindIndex(tab, 1, predicate);
                tab[allumetteRangée] = 0;
                Console.WriteLine("au tour de l'Ia");
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("L'IA enlève les allumettes à la ligne " + allumetteRangée );
            }
            else if (numCol == 2 && Numlign1 == 2)
            {
                int ligne = IsLign1(tab);
                tab[ligne] = 0;
                Console.WriteLine("au tour de l'Ia");
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("L'IA enleve la ligne " + ligne);
            }
            else if (numCol==2&& IsLign2(tab) >0)
            {
                tab[IsLign2(tab)] = 2;
                Console.WriteLine("au tour de l'Ia");
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("L'IA ne laisse que 2 à la ligne  ");
            }
            else if (egalisable(tab) == true)
            {
                
                bool order = égaliser(arr, tab);
                
            }
            else
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
                Thread.Sleep(3000);
                Console.Clear();
                Console.WriteLine("L'IA enlève " + allumette + " allumettes à la " + allumetteRangée + " ligne");
            }
            printTab(tab);
            int win = testTab(tab);
            if (win == 0)
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        public static bool egalisable(int[] tab) //return true if there is odd number of stick
        {
            int num = 0;
            for (int i = 1; i < tab.Length; i++)
            {
                num = num + tab[i];

            }

            if (num % 2 == 1)
            {
                return (true);
            }
            else
            {
                return false;
            }
        }

        private static bool Eq1(int obj) //predicate that return the first lign of the tab which contain 2 power 1
        {
            return (int)Math.Log2(obj)==1 ;
        }

        private static bool Eq0(int obj) //predicate that return the first lign of the tab which contain 2 power 0
        {
            return (int)Math.Log2(obj) == 0;
        }


        private static bool Eq2(int obj) //predicate that return the first lign of the tab which contain 2 power 2
        {
            return (int)Math.Log2(obj) == 2;
        }


        public static int KnowLign(int[,] tab, int a, int[] arr) //find the lign wich enter in conditions and wich contain less stick 
        {
            int inf = 26;
            Predicate<int> predicate1 = Eq1;
            Predicate<int> predicate0 = Eq0;
            Predicate<int> predicate2 = Eq2;
            int lign=0;
            if (a == 0)
            {
                lign = Array.FindIndex(arr, 1, predicate0);
            }
            else if (a == 1)
            {
                lign = Array.FindIndex(arr, 1, predicate1);
            }
            else if (a == 2)
            {
                lign = Array.FindIndex(arr, 1, predicate2);
            }
               

            for (int i = 1; i < arr.Length; i++)
            {

                if (tab[i, a] > 0 )
                {

                    if (arr[i] > inf)
                    {

                        if (arr[i] > 0 && i >0)
                        {
                            Console.WriteLine("ligne vaut " + lign);
                            
                            inf = arr[i];
                            lign = i;
                        }
                    }
                    
                }
            }
            Console.WriteLine("ligne vaut " + lign);
            return lign;
         }

        public static bool égaliser(int[,]DoubleArray,int[] array) //allows to equalize to keep an even numbe of power of 2 into the tab
        {
            DoubleArray = createDoubleArray(array[0]);
            int[,] arr = InitArrayDouble(DoubleArray,array);
            int numP0 = 0;
            int numP1 = 0;
            int numP2 = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int a = 0; a < arr.GetLength(0); a++)
                {
                    
                    if (i == 0)
                    {
                        numP0 = numP0 + arr[a, i];
                        
                    }
                    else if (i == 1)
                    {
                        numP1 = numP1 + arr[a, i];
                    }
                    else 
                    {
                        numP2 = numP2 + arr[a, i];
                    }
                    
                }
            }
            Console.WriteLine("nump0 vaut " + numP0 + " nump1 vaut " + numP1 + " nump2 vaut " + numP2);

            bool hardTri = HardTri(numP0, numP1, numP2, arr, array, 2);
            return (true);
        }

        static bool HardTri(int numP0,int numP1, int numP2, int[,] DoubleArray, int[] array,int turn) //allows to find what power of 2 the function has to equalize 
        {
            
            if (numP0 % 2 == 1 ^ numP1 % 2 == 1 ^ numP2 % 2 == 1)
            {
                
                if (numP0 % 2 == 1)
                {
                    int lign = KnowLign(DoubleArray, 0, array);
                    array[lign] = array[lign] - 1;
                    Console.WriteLine(numP0 + " " + lign);
                    Console.WriteLine("au tour de l'Ia");
                    Thread.Sleep(10000);
                    Console.Clear();
                    Console.WriteLine("L'IA enlève 1 allumettes à la " + lign + " ligne");
                    return (true);
                }
                else if (numP1 % 2 == 1)
                {
                    int lign = KnowLign(DoubleArray, 1, array);
                    array[lign] = array[lign] - 2;
                    Console.WriteLine(numP1 + " " + lign);
                    Console.WriteLine("au tour de l'Ia");

                    Thread.Sleep(10000);
                    Console.Clear();
                    Console.WriteLine("L'IA enlève 2 allumettes à la " + lign + " ligne");
                    return (true);
                }
                else if (numP2%2==1 )
                {
                    int lign = KnowLign(DoubleArray, 2, array);
                    array[lign] = array[lign] - 4;
                    Console.WriteLine(numP2 + " " + lign);
                    Console.WriteLine("au tour de l'Ia");
                    Thread.Sleep(10000);
                    Console.Clear();
                    Console.WriteLine("L'IA enlève 4 allumettes à la " + lign + " ligne");
                    return (true);
                }
                else
                {
                    
                    return (true);
                }
            }
            else
            {

                if (turn == 0)
                {
                    for (int i = 0; i < 3; i++)
                    {

                        for (int a = 0; a < DoubleArray.GetLength(0); a++)
                        {
                            if (i == 0)
                            {
                                numP0 = numP0 + DoubleArray[a, i];

                            }
                            else if (i == 1)
                            {
                                numP1 = numP1 + DoubleArray[a, i];
                            }
                            else
                            {
                                numP1 = numP1 + (DoubleArray[a, i] * 2);
                            }
                        }
                    }
                }
                else if (turn == 1)
                {
                    for (int i = 0; i < 3; i++)
                    {

                        for (int a = 0; a < DoubleArray.GetLength(0); a++)
                        {
                            if (i == 0)
                            {
                                numP0 = numP0 + DoubleArray[a, i];

                            }
                            else if (i == 1)
                            {
                                numP0 = numP0 + (DoubleArray[a, i]*2);
                            }
                            else
                            {
                                numP0 = numP0 + (DoubleArray[a, i] * 0);
                            }
                        }
                    }
                }
                else if (turn == 0)
                {
                    return (false);
                }
                
                return (HardTri(numP0, numP1, numP2, DoubleArray, array, turn - 1));
            }

        }

        public static int[,] InitArrayDouble(int[,] arr, int[]tab) //each turn init a double array with numbers of power of 2
        {
            
            for (int i = 1; i < tab.Length; i++)
            {
                
                int lign = tab[i];
                while (lign > 0)
                {
                    
                    int nbPerCol = (int)Math.Log2(lign);
                    if (nbPerCol >= 2)
                    {
                        arr[i, 2] = 1;
                        lign = lign - 4;
                        nbPerCol = nbPerCol - 1;
                        while (nbPerCol >= 2)
                        {
                            arr[i, 2] = arr[i, 2] + 1;
                            nbPerCol = nbPerCol - 1;
                            lign = lign - 4;
                        }
                        
                    } 
                    
                    else if (nbPerCol == 1)
                    {
                        arr[i, 1] = 1;
                        lign = lign - 2;
                    }
                    else if (nbPerCol == 0)
                    {
                        arr[i, 0] = 1;
                        lign = lign - 1;
                    }
                }
            }
            return (arr);
        }

        public static int[,] createDoubleArray(int numAllumette) //create a double array wich take the lengh of base number of stick
        {
            float valueF = (numAllumette / 2 + 2);
            int value = (int)valueF;
            int[,] arr = new int[value, 3];
            return arr;
        }

        
        static int choixLigne() //this function allow to choose the base number of stick
        {
            Console.WriteLine("choisis la base en nombre d'allumettes que tu veux ATTENTION : il faut que la bse soit impaire et aussi qu'elle soit supérieur à 5");
            
            try
            {
                int numAllumette = int.Parse(Console.ReadLine());
                if (numAllumette%2 == 1 && numAllumette>=5 && numAllumette<=25)
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

       
        static int[] initTable(int numAllumette) //create the array where numbers of sticks are stock 
        {
            float valueF = (numAllumette / 2 + 2);
            int value = (int)valueF;
            int[] tableau =new int[value];
            tableau[0] = numAllumette;
            int numPerLign = numAllumette;
            for (int i = value-1; i > 0; i--)
            {
                tableau[i] = numPerLign;
                numPerLign = numPerLign - 2;
            }

            return (tableau);

        }

        
        static void printTab(int[] tableau) // print the graph with sticks 
        {
            Console.WriteLine("Voici le tableau actuel : ");
            int tablength = tableau.Length;
            for (int i = 0; i <tableau.Length+1 ; i++) {
                if (i==0 || i == (tablength) )
                {
                    Console.Write(" ");
                    for (int j = 0; j <= tableau[0] + 1; j++) {
                        Console.Write("-");
                    }
                    Console.WriteLine(" ");
                }
                else
                {
                    
                    PrintLignAllumette(i,tableau[i],tableau[0]);
                }
                    }
        }

       
        static void PrintLignAllumette(int e, int numPerLign,int numBase) //print one lign of the array
        {
            if (numPerLign % 2 == 1)
            {
                
                Console.Write(e);
                Console.Write("|");
                for (int i = 0; i < (numBase - numPerLign) / 2; i++)
                {
                    Console.Write(" ");
                }
                for (int i =0; i < numPerLign; i++)
                {
                    Console.Write("I");
                }
                for (int i = 0; i <= (numBase - numPerLign) / 2; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("|");
            }
            else
            {
                Console.Write(e);
                Console.Write("|");
                for (int i = 0; i <= (numBase - numPerLign +1) / 2; i++)
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


        static void ChoiceLvlRead() //choose the difficulty level
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
                Vs();
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
            else if (num<1 || num>4)
            {
                
                Console.WriteLine("Il nous faut un nombre entre 1 et 4 pour continuer ^^'");
                ChoiceLvlRead();
            }
        }


        

    }
}
