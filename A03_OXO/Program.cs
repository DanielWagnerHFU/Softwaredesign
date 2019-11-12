using System;

namespace A03_OXO
{
    class OXO
    {
        static string[,] board = new string[3, 3];
        static int player;

        static void Main(string[] args)
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = "-";
                }
            }
            drawBoard();
            player = 1;
        
            keyInput();
        }

        static void drawBoard()
        {
            Console.WriteLine(board[0, 0] + " " + board[0, 1] + " " + board[0, 2]);
            Console.WriteLine(board[1, 0] + " " + board[1, 1] + " " + board[1, 2]);
            Console.WriteLine(board[2, 0] + " " + board[2, 1] + " " + board[2, 2]);
        }

        static void keyInput()
        {

            ConsoleKey choice;
            int x = 0;
            int y = 0;

            do{
                choice = Console.ReadKey(true).Key;
            } while(choice != ConsoleKey.D1 && choice != ConsoleKey.D2 && choice != ConsoleKey.D3 && choice != ConsoleKey.D4 && choice != ConsoleKey.D5 && choice != ConsoleKey.D6 && choice != ConsoleKey.D7 && choice != ConsoleKey.D8 && choice != ConsoleKey.D9);
            
            switch(choice)
            {
                case ConsoleKey.D1:
                    x = 2;
                    y = 0;
                    break;
                case ConsoleKey.D2:
                    x = 2;
                    y = 1;
                    break;
                case ConsoleKey.D3:
                    x = 2;
                    y = 2;
                    break;
                case ConsoleKey.D4:
                    x = 1;
                    y = 0;
                    break;
                case ConsoleKey.D5:
                    x = 1;
                    y = 1;
                    break;
                case ConsoleKey.D6:
                    x = 1;
                    y = 2;
                    break;
                case ConsoleKey.D7:
                    x = 0;
                    y = 0;
                    break;
                case ConsoleKey.D8:
                    x = 0;
                    y = 1;
                    break;
                case ConsoleKey.D9:
                    x = 0;
                    y = 2;
                    break;
            }

            if (board[x, y] == "-")
                {
                    Console.Clear();
                    if (player == 1)
                    {
                        board[x, y] = "X";
                    }
                    else if (player == 2)
                    {
                        board[x, y] = "O";
                    }

                    drawBoard();
                    if(checkWinConditions(x, y))
                    {
                        displayWinMessage(player);
                        return;
                    }
                    if(checkIfBoardIsFull()) {
                        displayDrawMessage();
                        return;
                    }

                    if(player == 1)
                    {
                        player = 2;
                    }
                    else
                    {
                        player = 1;
                    }
                    keyInput();
                }
                else
                {
                    keyInput();
                }
        }

        static void invalidInput()
        {
            Console.WriteLine("Ungültige Eingabe. Bitte versuche es erneut.");
        }

        static bool checkWinConditions(int row, int column)
        {
            string p;
            if(player == 1)
            {
                p = "X";
            }
            else
            {
                p = "O";
            }

            if(board[row, 0] == p && board[row, 1] == p && board[row, 2] == p) 
            {
                return true;
            }
            else if(board[0, column] == p && board[1, column] == p && board[2, 1] == p)
            {
                return true;
            }
            else if(board[0, 0] == p && board[1, 1] == p && board[2, 2] == p)
            {
                return true;
            }
            else if(board[0, 2] == p && board[1,1] == p && board[2,0] == p)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool checkIfBoardIsFull() {

            int counter = 0;

            foreach(string s in board)
            {
                if(s == "-")
                    counter += 1;
            }

            if(counter > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static void displayWinMessage(int player)
        {
            Console.WriteLine("Spieler " + player + " hat gewonnen!");
        }

        static void displayDrawMessage()
        {
            Console.WriteLine("Unentschieden.");
        }
    }
}
