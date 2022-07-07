using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class TicTacToe
    {
        private int x;
        private int y;
        private bool win;
        private char winner;
        private int X
        {
            get
            {
                return x;
            }
            set
            {
                if (value >= 0 && value <= 2)
                {
                    x = value;
                }
                else
                {
                    Console.SetCursorPosition(0, 0);
                    Console.Write("Enter X value: ");
                    X = int.Parse(Console.ReadLine());
                }
            }
        }
        private int Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value >= 0 && value <= 2)
                {
                    y = value;
                }
                else
                {
                    Console.SetCursorPosition(0, 1);
                    Console.Write("Enter Y value: ");
                    Y = int.Parse(Console.ReadLine());
                }
            }
        }

        private char[,] matrix;

        public TicTacToe()
        {
            matrix = new char[3, 3];
        }

        public void Play()
        {
            PrintGameBoard();
            while (!win)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write("Enter X value: ");
                X = int.Parse(Console.ReadLine());

                Console.SetCursorPosition(0, 1);
                Console.Write("Enter Y value: ");
                Y = int.Parse(Console.ReadLine());
                if (matrix[X, Y] != 'x' && matrix[X, Y] != 'o')
                {
                    matrix[X, Y] = 'x';
                    Console.SetCursorPosition(X + 1, Y + 3);
                    Console.Write("x");
                    if (CheckWin())
                    {
                        break;
                    }

                    ComputerSpot computerSpot = EnemyTurn();
                    matrix[computerSpot.X, computerSpot.Y] = 'o';
                    Console.SetCursorPosition(computerSpot.X + 1, computerSpot.Y + 3);
                    Console.Write("o");
                    
                    CheckWin();
                }
            }
        }

        private ComputerSpot EnemyTurn()
        {
            ComputerSpot spot = new ComputerSpot();
            List<ComputerSpot> avalableSpots = new List<ComputerSpot>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if(matrix[i, j] != 'x' && matrix[i, j] != 'o')
                    {
                        avalableSpots.Add(new ComputerSpot(i, j));
                    }
                }
            }

            Random random = new Random();
            int n = random.Next(0, avalableSpots.Count - 1);
            spot.X = avalableSpots[n].X;
            spot.Y = avalableSpots[n].Y;
            return spot;
        }
        private bool CheckWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (matrix[i, 0] == 'x' && matrix[i, 1] == 'x' && matrix[i, 2] == 'x')
                {
                    winner = 'x';
                    win = true;
                }
                else if (matrix[0, i] == 'x' && matrix[1, i] == 'x' && matrix[2, i] == 'x')
                {
                    winner = 'x';
                    win = true;
                }
            }
            if(matrix[0, 0] == 'x' && matrix[1, 1] == 'x' && matrix[2, 2] == 'x' ||
               matrix[0, 2] == 'x' && matrix[2, 0] == 'x' && matrix[1, 1] == 'x')
            {
                winner = 'x';
                win = true;
            }

            for (int i = 0; i < 3; i++)
            {
                if (matrix[i, 0] == 'o' && matrix[i, 1] == 'o' && matrix[i, 2] == 'o')
                {
                    winner = 'o';
                    win = true;
                }
                else if (matrix[0, i] == 'o' && matrix[1, i] == 'o' && matrix[2, i] == 'o')
                {
                    winner = 'o';
                    win = true;
                }
            }
            if(matrix[0, 0] == 'o' && matrix[1, 1] == 'o' && matrix[2, 2] == 'o' ||
               matrix[0, 2] == 'o' && matrix[2, 0] == 'o' && matrix[1, 1] == 'o')
            {
                winner = 'o';
                win = true;
            }
            if (win)
            {
                EndGame(winner);
            }
            return win;
        }

        private static void PrintGameBoard()
        {
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("_____");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("|   |");
            }
            Console.WriteLine("-----");
        }

        private static void EndGame(char winner)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("                                 ");
            Console.WriteLine("                                 ");
            Console.SetCursorPosition(0, 1);

            if (winner == 'x')
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.WriteLine($"Winner is {winner}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(0, 8);
        }
    }
}
