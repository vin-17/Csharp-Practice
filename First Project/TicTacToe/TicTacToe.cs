using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Project
{
    internal class TicTacToe
    {
        char[,] board;
        Dictionary<int, Tuple<int, int>> dictionary;
        

        public TicTacToe()
        {
            char[,] arr = { {'1', '2', '3' }, {'4', '5', '6' }, {'7', '8' , '9'} } ;
            this.board = arr;
            dictionary = new Dictionary<int, Tuple<int, int>>();
           
            dictionary.Add(1, Tuple.Create(0, 0));
            dictionary.Add(2, Tuple.Create(0, 1));
            dictionary.Add(3, Tuple.Create(0, 2));
            dictionary.Add(4, Tuple.Create(1, 0));
            dictionary.Add(5, Tuple.Create(1, 1));
            dictionary.Add(6, Tuple.Create(1, 2));
            dictionary.Add(7, Tuple.Create(2, 0));
            dictionary.Add(8, Tuple.Create(2, 1));
            dictionary.Add(9, Tuple.Create(2, 2));

        }

        //check if string to int convertible or not
        public int canConvert(string input)
        {
            if (int.TryParse(input, out int num))
            {
                return num;
            }
            else
            {
                return -1;
            }

        }

        //method : start()
        public void start()
        {
            Console.WriteLine("First Player will mark 'X' , Second Player will mark 'O' . Enter 1 to play and 0 to Exit " );
            string input = Console.ReadLine();
            bool success = false;
            while (!success)
            {
                if (int.TryParse(input, out int num))
                {
                    success = true;
                    if (num == 0)
                    {
                        Console.WriteLine("You have exited the game.");
                        break;
                    }
                    else this.runGame();
                }
                else
                {
                    Console.WriteLine("Wrong Input :( ");
                }
            }
            
        }

        //method : runnigLoop()
        public void runGame()
        {
            //players 1 & 2
            int markedTiles = 0;
            int current_player = 1;
            bool winnerFound = false;
            
            while(markedTiles <= 9)
            {
                this.printBoard();
                if(current_player == 1)
                {
                    Console.Write("\nPlease enter the tile number where you want to mark X : ");
                    string input = Console.ReadLine();
                    int tileNumber = canConvert(input);
                    if(tileNumber != -1)
                    {
                        Tuple<int, int> pos = dictionary[tileNumber];
                        if (board[pos.Item1, pos.Item2] != 'X' && board[pos.Item1, pos.Item2] != 'O'){
                            //reflect changes
                            this.mark(pos.Item1, pos.Item2, 1);
                            markedTiles++;
                            //check if matched
                            //check if matched
                            if (checkForSuccess(pos.Item1, pos.Item2, 1)){
                                this.printBoard();
                                winnerFound = true;
                                Console.WriteLine("\nPlayer 1 WINS !! ");
                                break;
                            }
                            //move the game ahead
                            current_player = 2;
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("\nThe tile you entered is already marked ! Please enter again ");
                            continue;
                        }
                        

                    }
                    else
                    {
                        Console.Write("\nPlease enter a valid tile number !! ");
                        continue;
                    }
                }
                else
                {
                    Console.Write("\nPlease enter the tile number where you want to mark O : ");
                    string input = Console.ReadLine();
                    int tileNumber = canConvert(input);
                    if (tileNumber != -1 && tileNumber >= 1 && tileNumber <=9 )
                    {
                        Tuple<int, int> pos = dictionary[tileNumber];
                        if (board[pos.Item1, pos.Item2] != 'X' && board[pos.Item1, pos.Item2] != 'O')
                        {
                            //reflect changes
                            this.mark(pos.Item1, pos.Item2, 2);
                            markedTiles++;
                            //check if matched
                            if (checkForSuccess(pos.Item1, pos.Item2, 2)){
                                this.printBoard();
                                winnerFound = true;
                                Console.WriteLine("\nPlayer 2 WINS !! ");
                                break;
                            }
                            //move the game ahead
                            current_player = 1;
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("\nThe tile you entered is already marked ! Please enter again ");
                            continue;
                        }


                    }
                    else
                    {
                        Console.Write("\nPlease enter a valid tile number !! ");
                        continue;
                    }
                }
            }

            if (winnerFound == false)
            {
                Console.WriteLine("Game is a draw, No player Wins !! ");
            }
            
        }


        //method : mark(position, player)
        public void mark(int x, int y, int player)
        {
            if(player == 1)
            {
                this.board[x, y] = 'X';
            }
            else
            {
                this.board[x, y] = 'O';
            }
        }

        //method : checkForSuccess()
        public bool checkForSuccess(int x, int y, int player)
        {
            //horizontal
            if(player == 1)
            {
                int x1 = x;
                if (x == 0) x1 = x + 1;
                if (x == 2) x1 = x - 1;
                int y1 = y;
                if (y == 0) y1 = y + 1;
                if (y == 2) y1 = y - 1;

                int Xcount = 0;
                for (int i = -1; i <= 1; i++)
                {
                    if (board[x1 + i, y] == 'X')
                    {
                        Xcount++;
                    }
                }
                if (Xcount == 3) { return true; }

                //vertical

                int Ycount = 0;
                for (int i = -1; i <= 1; i++)
                {
                    if (board[x, y1 + i] == 'X')
                    {
                        Ycount++;
                    }
                }
                if (Ycount == 3) {  return true; }

                //diagonal

                int[] delX = { -1, 0, +1 };
                int[] delY = { -1, 0, +1 };

                int D1count = 0;
                for (int i = 0; i < 3; i++)
                {

                    if (board[x1 + delX[i], y1 + delY[i]] == 'X')
                    {
                        D1count++;
                    }
                }
                if (D1count == 3) {return true; }

                int[] delXI = { +1, 0, -1 };
                int[] delYI = { -1, 0, +1 };

                int D2count = 0;
                for (int i = 1; i < 3; i++)
                {
                    if (board[x1 + delX[i], y1 + delY[i]] == 'X')
                    {
                        D2count++;
                    }
                }
                if (D2count == 3) {  return true; }


                return false;
            }
            else
            {
                int x1 = x;
                if (x == 0) x1 = x + 1;
                if (x == 2) x1 = x - 1;
                int y1 = y;
                if (y == 0) y1 = y + 1;
                if (y == 2) y1 = y - 1;

                int Xcount = 0;
                for (int i = -1; i <= 1; i++)
                {
                    if (board[x1 + i, y] == 'O')
                    {
                        Xcount++;
                    }
                }
                if (Xcount == 3) { return true; }

                //vertical

                int Ycount = 0;
                for (int i = -1; i <= 1; i++)
                {
                    if (board[x, y1 + i] == 'O')
                    {
                        Ycount++;
                    }
                }
                if (Ycount == 3) {  return true; }

                //diagonal

                int[] delX = { -1, 0, +1 };
                int[] delY = { -1, 0, +1 };

                int D1count = 0;
                for (int i = 0; i < 3; i++)
                {

                    if (board[x1 + delX[i], y1 + delY[i]] == 'O')
                    {
                        D1count++;
                    }
                }
                if (D1count == 3) { return true; }

                int[] delXI = { +1, 0, -1 };
                int[] delYI = { -1, 0, +1 };

                int D2count = 0;
                for (int i = 1; i < 3; i++)
                {
                    if (board[x1 + delX[i], y1 + delY[i]] == 'O')
                    {
                        D2count++;
                    }
                }
                if (D2count == 3) {  return true; }


                return false;
            }
            
        }

        public void printBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j]);
                    Console.Write(" ");

                }
            }
        }
        
        
    }
}
