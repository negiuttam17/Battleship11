using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship11
{
    public class Program
    {
        //Declare and initialize 10x10 board for both player 1 and 2
        public static String[,] p2Board = new String[10,10];
        public static String[,] p1Board = new String[10,10];

        //This is the board after player 1 and 2 start attacking eachother
        static String[,] p2Hit = new String[10,10];
        static String[,] p1Hit = new String[10,10];

        
        static int hitCounterP1 = 0;
        static int hitCounterP2 = 0;

        static int lengthsubmarine1;
        static int lengthDestroyer1;
        static int lengthPetrolShip1;

        static int lengthsubmarine2;
        static int lengthDestroyer2;
        static int lengthPetrolShip2;


        static Boolean Winner_player1 = false;
        static Boolean Winner_player2 = false;


        static void initializeVariables()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    p1Board[i, j] = " ";
                    p2Board[i, j] = " ";
                    p1Hit[i, j] = " ";
                    p2Hit[i, j] = " ";
                }
            }
        }

        public static void Main(string[] args)
        {

            initializeVariables();
            Welcome();
            Play();
            DeclareWinner();

        }
        static void Welcome()
        {
            Console.Title = "Battleship";

            Console.WriteLine("Welcome to Battleship.\n\nPress any key to continue.");
            Console.ReadLine();
        }
       

        public static void PutShipOnBoard1()
        {
            //Console.Clear();
            Console.WriteLine("This is the turn for Player 1! Player 2: LEAVE!");
            Console.ReadLine();
            Console.Clear();

            int orientation=0; //Default orientation is verticle
            drawBoard("P1");
            Console.WriteLine("Where would you like to  put a Petrol Ship ? Enter the row(1-10) and column(1-10) followed by a comma:");
            string selection = Console.ReadLine();
            int num1 = Convert.ToInt32(selection.Split(',')[0]);
            int num2 = Convert.ToInt32(selection.Split(',')[1]);
            Console.WriteLine("Please select the orientation of your ship: 0-Verticle, 1-Horizontal");
            orientation = Convert.ToInt32(Console.ReadLine());
            
            p1Board[num1,num2] = "P";
            if (orientation == 1)
                p1Board[num1, num2+1] = "P";
            else
                p1Board[num1 + 1, num2] = "P";
            //---------
            drawBoard("P1");
            Console.WriteLine("Where would you like to put a Destroyer? Enter the row(1 - 10) and column(1 - 10) followed by a comma:");
            selection = Console.ReadLine();
            num1 = Convert.ToInt32(selection.Split(',')[0]);
            num2 = Convert.ToInt32(selection.Split(',')[1]);
            Console.WriteLine("Please select the orientation of your ship: 0-Verticle, 1-Horizontal");
            orientation = Convert.ToInt32(Console.ReadLine());
            
            p1Board[num1, num2] = "D";
            if (orientation == 1)
            {
                p1Board[num1, num2+1] = "D";
                p1Board[num1, num2+2] = "D";
            }
            else
            {
                p1Board[num1+1, num2] = "D";
                p1Board[num1+2, num2] = "D";
            }
            //---------
            drawBoard("P1");
            Console.WriteLine("Where would you like to put a Submarine? Enter the row(1-10) and column(1-10) followed by a comma:");
            selection = Console.ReadLine();
            num1 = Convert.ToInt32(selection.Split(',')[0]);
            num2 = Convert.ToInt32(selection.Split(',')[1]);
            Console.WriteLine("Please select the orientation of your ship: 0-Verticle, 1-Horizontal");
            orientation = Convert.ToInt32(Console.ReadLine());
           
            p1Board[num1, num2] = "S";
            if (orientation == 1)
            {
                p1Board[num1, num2+1] = "S";
                p1Board[num1, num2+2] = "S";
            }
            else
            {
                p1Board[num1+1, num2] = "S";
                p1Board[num1+2, num2] = "S";
            }
            drawBoard("P1");          
        }
        public static void PutShipOnBoard2()
        {
            Console.Clear();
            Console.WriteLine("Player 2! Your turn right now! Press any key to continue.");
            Console.ReadLine();

            int orientation = 0; //Default orientation is verticle
            drawBoard("P2");
            Console.WriteLine("Where would you like to put a Petrol Ship? Enter the row(1-10) and column(1-10) followed by a comma:");
            string selection = Console.ReadLine();
            int num1 = Convert.ToInt32(selection.Split(',')[0]);
            int  num2 = Convert.ToInt32(selection.Split(',')[1]);
            Console.WriteLine("Please select the orientation of your ship: 0-Verticle, 1-Horizontal");
            orientation = Convert.ToInt32(Console.ReadLine());

            p2Board[num1, num2] = "P";
            if (orientation == 1)
                p2Board[num1, num2 + 1] = "P";
            else
                p2Board[num1 + 1, num2] = "P";


            ////---------

            drawBoard("P2");
            Console.WriteLine("Please select the location of your Destroyer based on the box #");
            selection = Console.ReadLine();
            num1 = Convert.ToInt32(selection.Split(',')[0]);
            num2 = Convert.ToInt32(selection.Split(',')[1]);
            Console.WriteLine("Please select the orientation of your ship: 0-Verticle, 1-Horizontal");
            orientation = Convert.ToInt32(Console.ReadLine());


            p2Board[num1, num2] = "D";
            if (orientation == 1)
            {
                p2Board[num1, num2 + 1] = "D";
                p2Board[num1, num2 + 2] = "D";
            }
            else
            {
                p2Board[num1 + 1, num2] = "D";
                p2Board[num1 + 2, num2] = "D";
            }


            drawBoard("P2");
            Console.WriteLine("Please select the location of your ship Submarine based on the box #");
            selection = Console.ReadLine();
            num1 = Convert.ToInt32(selection.Split(',')[0]);
            num2 = Convert.ToInt32(selection.Split(',')[1]);
            Console.WriteLine("Please select the orientation of your ship: 0-Verticle, 1-Horizontal");
            orientation = Convert.ToInt32(Console.ReadLine());


            p2Board[num1, num2] = "S";
            if (orientation == 1)
            {
                p2Board[num1, num2 + 1] = "S";
                p2Board[num1, num2 + 2] = "S";
            }
            else
            {
                p2Board[num1 + 1, num2] = "S";
                p2Board[num1 + 2, num2] = "S";
            }
            drawBoard("P2");
        }

        public static void Attack()
        {
            Console.Clear();
            drawBoard("P1Hit");
            Console.WriteLine("Player 1: Please enter your selection based on the previous hit field.");
            string selection = Console.ReadLine();
            int num1 = Convert.ToInt32(selection.Split(',')[0]);
            int num2 = Convert.ToInt32(selection.Split(',')[1]);
            if (p2Board[num1, num2] != " ")
            {
                Console.WriteLine("HIT!");
                if (p2Board[num1, num2] == "P")
                {
                    lengthPetrolShip1 = lengthPetrolShip1 + 1;
                    if (lengthPetrolShip1 == 2)
                    {
                        Console.WriteLine("You Sunk my Petrolship!");
                    }
                }
                if (p2Board[num1, num2] == "S")
                {
                    lengthsubmarine1 = lengthsubmarine1 + 1;
                    if (lengthsubmarine1 == 3)
                    {
                        Console.WriteLine("You Sunk my Submarine!");
                    }
                }
                if (p2Board[num1, num2] == "D")
                {
                    lengthDestroyer1 = lengthDestroyer1 + 1;
                    if (lengthDestroyer1 == 3)
                    {
                        Console.WriteLine("You Sunk my Destroyer!");
                    }
                }
                p1Hit[num1, num2] = "H";
                hitCounterP1++;
                if (hitCounterP1 == 8)
                    Winner_player1 = true;
            }
            else
            {
                Console.WriteLine("MISS!");
                p1Hit[num1, num2] = "M";
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadLine();
            Console.Clear();
            drawBoard("P2Hit");
            Console.WriteLine("Player 2: Please enter your selection based on the previous hit field.");
            selection = Console.ReadLine();
            num1 = Convert.ToInt32(selection.Split(',')[0]);
            num2 = Convert.ToInt32(selection.Split(',')[1]);
            if (p1Board[num1,num2] != " ")
            {
                Console.WriteLine("HIT!");
                if (p1Board[num1,num2]=="P")
                {
                    lengthPetrolShip2 = lengthPetrolShip2 + 1;
                    if(lengthPetrolShip2 == 2)
                    {
                        Console.WriteLine("You Sunk my PetrolShip!");
                    }
                }
                if (p1Board[num1, num2] == "S")
                {
                    lengthsubmarine2 = lengthsubmarine2 + 1;
                    if (lengthsubmarine2 == 3)
                    {
                        Console.WriteLine("You Sunk my Submarine!");
                    }
                }
                if (p1Board[num1, num2] == "D")
                {
                    lengthDestroyer2 = lengthDestroyer2 + 1;
                    if (lengthDestroyer2 == 3)
                    {
                        Console.WriteLine("You Sunk my Destroyer!");
                    }
                }
                p2Hit[num1,num2] = "H";
                hitCounterP2++;
                if (hitCounterP2 == 8)
                    Winner_player2 = true;

            }
            else
            {
                Console.WriteLine("MISS!");
                p2Hit[num1,num2] = "M";
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadLine();
        }
       
        static void Play()
        {
            Console.Clear();
            PutShipOnBoard1();
            Console.Clear();
            PutShipOnBoard2();

            while (!Winner_player1 && !Winner_player2)
            {
                Attack();

            }
        }

       

        public static void drawBoard(String selection)
        {
            if (selection.Equals("P1"))
            {
                Console.Write("\t ");
                for (int i = 0; i < 10; i++) Console.Write("{0} ", i);  // print column numbers
                Console.WriteLine();
                for (int i = 0; i < 10; i++)
                {
                    Console.Write("{0}\t", i);
                    for (int j = 0; j < 10; j++)
                        Console.Write('|'+p1Board[i,j]);
                    Console.WriteLine('|');
                }
            }
            
            else if (selection.Equals("P2"))
            {
                Console.Write("\t ");
                for (int i = 0; i < 10; i++) Console.Write("{0} ", i);  // print column numbers
                Console.WriteLine();
                for (int i = 0; i < 10; i++)
                {
                    Console.Write("{0}\t", i);
                    for (int j = 0; j < 10; j++)
                        Console.Write('|' + p2Board[i, j]);
                    Console.WriteLine('|');
                }
            }
            else if (selection.Equals("P1Hit"))
            {
                Console.Write("\t ");
                for (int i = 0; i < 10; i++) Console.Write("{0} ", i);  // print column numbers
                Console.WriteLine();
                for (int i = 0; i < 10; i++)
                {
                    Console.Write("{0}\t", i);
                    for (int j = 0; j < 10; j++)
                        Console.Write('|' + p1Hit[i, j]);
                    Console.WriteLine('|');
                }
            }
            else
            {
                Console.Write("\t ");
                for (int i = 0; i < 10; i++) Console.Write("{0} ", i);  // print column numbers
                Console.WriteLine();
                for (int i = 0; i < 10; i++)
                {
                    Console.Write("{0}\t", i);
                    for (int j = 0; j < 10; j++)
                        Console.Write('|' + p2Hit[i, j]);
                    Console.WriteLine('|');
                }
            }

        }
        static void DeclareWinner()
        {
            Console.Clear();
            Console.WriteLine("Game ended!");
            if (Winner_player1)
                Console.WriteLine("The winner is Player 1!");
            else
                Console.WriteLine("The winner is Player 2!");
            Console.WriteLine("\nThank you for playing.");
            Console.ReadLine();

        }

    }
}
