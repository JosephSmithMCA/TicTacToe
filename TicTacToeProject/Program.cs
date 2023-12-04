using System.Data.SqlTypes;
using System.Drawing;
using System.Runtime.InteropServices;

namespace TicTacToe {
    internal class TicTacToe {
        static void Main(string[] args) {
            const char player1 = 'X';
            const char player2 = 'O';
            char[,] board = new char[3, 3];
            string player1Turn = "";
            string player2Turn = "";
            int player1Wins = 0;
            int player2Wins = 0;
            bool playerTurn = true;
            bool playGame = true;
            int win = 0;

            DrawBoard();

            do {
                Console.SetCursorPosition(20, 10);
                Console.WriteLine($"Player 1 Wins: {player1Wins} Player 2 Wins: {player2Wins}");
                win = 0;
                do {



                    if (playerTurn) {
                        do {
                            Console.SetCursorPosition(20, 1);
                            Console.Write(new string(' ', Console.WindowWidth - 20));
                            
                            Console.SetCursorPosition(20, 0);
                            player1Turn = Input("Player 1 Please Pick A Location: ");

                            if (InputAcceptable(player1Turn) == false) {
                                Console.SetCursorPosition(20, 2);
                                Output("Please enter a valid board location!");
                                Console.SetCursorPosition(20, 0);
                                Console.Write(new string(' ', Console.WindowWidth - 52));
                            }//end if
                        } while (InputAcceptable(player1Turn) == false);
                        Console.SetCursorPosition(20, 2);
                        Console.Write(new string(' ', Console.WindowWidth - 20));
                        for (int y = 0; y < board.GetLength(1); y++) {
                            for (int x = 0; x < board.GetLength(0); x++) {
                                if (player1Turn == $"{x} {y}") {
                                    if (PlaceMarker(board, player1, x, y)) {
                                        board[x, y] = player1;
                                        playerTurn = false;
                                    } else if (!PlaceMarker(board, player1, x, y)) {
                                        playerTurn = true;
                                        Console.SetCursorPosition(20, 1);
                                        Console.WriteLine("SPOT IS TAKEN!");
                                    }//end else if
                                }//end if
                            }//end for
                        }//end for
                        Console.SetCursorPosition(20, 0);
                        Console.Write(new string(' ', Console.WindowWidth - 20));
                        DrawSymbols(board);
                        win = WinCheck(board);
                        if (win == 1) {
                            player1Wins += win;
                            Console.SetCursorPosition(20, 1);
                            Output("Player 1 Wins");

                        } else if (win == 2) {
                            Console.SetCursorPosition(20, 1);
                            Output("it's a tie");
                            Console.SetCursorPosition(20, 8);
                            playGame = InputYesNo("Play Again ");
                            Console.SetCursorPosition(20, 8);
                            Console.Write(new string(' ', Console.WindowWidth - 20));
                            if (playGame) {
                                playerTurn = true;
                            }//end if
                        }//end else if

                    } else if (!playerTurn) {

                        do {
                            Console.SetCursorPosition(20, 4);
                            Console.Write(new string(' ', Console.WindowWidth - 20));
                            Console.SetCursorPosition(20, 3);
                            player2Turn = Input("Player 2 Please Pick A Location: ");

                            if (InputAcceptable(player2Turn) == false) {
                                Console.SetCursorPosition(20, 5);
                                Output("Please enter a valid board location!");
                                Console.SetCursorPosition(20, 3);
                                Console.Write(new string(' ', Console.WindowWidth - 52));
                            }
                        } while (InputAcceptable(player2Turn) == false);
                        Console.SetCursorPosition(20, 5);
                        Console.Write(new string(' ', Console.WindowWidth - 20));
                        for (int y = 0; y < board.GetLength(1); y++) {
                            for (int x = 0; x < board.GetLength(0); x++) {
                                if (player2Turn == $"{x} {y}") {
                                    if (PlaceMarker(board, player1, x, y) == true) {
                                        board[x, y] = player2;
                                        playerTurn = true;
                                    } else if (!PlaceMarker(board, player1, x, y)) {
                                        playerTurn = false;
                                        Console.SetCursorPosition(20, 4);
                                        Console.WriteLine("SPOT IS TAKEN!");
                                    }//END ELSE IF
                                }//END IF
                            }//end for
                        }//end for
                        Console.SetCursorPosition(20, 3);
                        Console.Write(new string(' ', Console.WindowWidth - 20));

                        DrawSymbols(board);
                        win = WinCheck(board);
                        if (win == 1) {
                            Console.SetCursorPosition(20, 4);
                            player2Wins += win;
                            Output("Player 2 Wins");
                        } else if (win == 2) {
                            Output("it's a tie");
                            Console.SetCursorPosition(20, 8);
                            playGame = InputYesNo("Play Again ");
                            Console.SetCursorPosition(20, 8);
                            Console.Write(new string(' ', Console.WindowWidth - 20));
                            if (playGame) {
                                playerTurn = true;
                            }//END IF
                        }//END ELSE IF

                    }//end if

                } while (win < 1); // END WHILE LOOP

                Console.SetCursorPosition(20, 8);
                playGame = InputYesNo("Play Again ");
                Console.SetCursorPosition(20, 8);
                Console.Write(new string(' ', Console.WindowWidth - 20));

                if (playGame) {
                    playerTurn = true;
                    board = new char[3, 3];
                    DrawSymbols(board);
                }// END IF




            } while (playGame); //END WHILE LOOP




            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

        }//END MAIN
        static void DrawBoard() {

            byte[] boardColor = { 255, 255, 255 };
            int xPosition = 0;
            int yPosition = 0;
            for (int i = 0; i < 17; i++) {
                ConsoleSetBlock(5, yPosition, boardColor);
                yPosition += 1;
            }//END FOR
            yPosition = 0;
            for (int i = 0; i < 17; i++) {
                ConsoleSetBlock(11, yPosition, boardColor);
                yPosition += 1;
            }//END FOR
            for (int i = 0; i < 17; i++) {
                ConsoleSetBlock(xPosition, 5, boardColor);
                xPosition += 1;
            }//END FOR
            xPosition = 0;
            for (int i = 0; i < 17; i++) {
                ConsoleSetBlock(xPosition, 11, boardColor);
                xPosition += 1;
            }//END FOR

            Console.SetCursorPosition(1, 0);
            Console.Write("0 0");
            Console.SetCursorPosition(7, 0);
            Console.Write("1 0");
            Console.SetCursorPosition(13, 0);
            Console.Write("2 0");
            Console.SetCursorPosition(1, 6);
            Console.Write("0 1");
            Console.SetCursorPosition(7, 6);
            Console.Write("1 1");
            Console.SetCursorPosition(13, 6);
            Console.Write("2 1");
            Console.SetCursorPosition(1, 12);
            Console.Write("0 2");
            Console.SetCursorPosition(7, 12);
            Console.Write("1 2");
            Console.SetCursorPosition(13, 12);
            Console.Write("2 2");




        }//END FUNCTION

        static void DrawSymbols(char[,] board) {



            for (int y = 0; y < board.GetLength(1); y++) {
                for (int x = 0; x < board.GetLength(0); x++) {
                    char currentSymbol = board[x, y];
                    byte[] colorBlack = { 0, 0, 0 };

                    if (x == 0 && y == 0) {
                        DrawMarker(currentSymbol, 1, 1);

                    } else if (x == 1 && y == 0) {
                        DrawMarker(currentSymbol, 7, 1);
                    } else if (x == 2 && y == 0) {
                        DrawMarker(currentSymbol, 13, 1);
                    } else if (x == 0 && y == 1) {
                        DrawMarker(currentSymbol, 1, 7);
                    } else if (x == 1 && y == 1) {
                        DrawMarker(currentSymbol, 7, 7);
                    } else if (x == 2 && y == 1) {
                        DrawMarker(currentSymbol, 13, 7);
                    } else if (x == 0 && y == 2) {
                        DrawMarker(currentSymbol, 1, 13);
                    } else if (x == 1 && y == 2) {
                        DrawMarker(currentSymbol, 7, 13);
                    } else if (x == 2 && y == 2) {
                        DrawMarker(currentSymbol, 13, 13);
                    }//end else if



                }//END NESTED FOR
            }//END FOR
        }//END FUNCTION

        static void DrawMarker(char symbol, int xStart, int yStart) {
            byte[] colorBlack = { 0, 0, 0 };
            byte[] xColor = { 0, 255, 0 };
            byte[] oColor = { 255, 255, 0 };
            if (symbol == 'X') {
                for (int y = yStart; y < (yStart + 3); y++) {
                    for (int x = xStart; x < (xStart + 3); x++) {

                        if (x == xStart + 1 && y == yStart) {
                            ConsoleSetBlock(xStart + 1, yStart, colorBlack);
                        }//END IF
                        else if (x == xStart && y == yStart + 1) {
                            ConsoleSetBlock(xStart, yStart + 1, colorBlack);
                        }//END IF
                        else if (x == xStart + 2 && y == yStart + 1) {
                            ConsoleSetBlock(xStart + 2, yStart + 1, colorBlack);
                        }//END IF
                        else if (x == xStart + 1 && y == yStart + 2) {
                            ConsoleSetBlock(xStart + 1, yStart + 2, colorBlack);
                        } else {
                            ConsoleSetBlock(x, y, xColor);

                        }//END IF


                    }//END FOR
                }//END FOR                
            } else if (symbol == 'O') {
                for (int y = yStart; y < (yStart + 3); y++) {
                    for (int x = xStart; x < (xStart + 3); x++) {
                        if (x == xStart + 1 && y == yStart + 1) {
                            ConsoleSetBlock(xStart + 1, yStart + 1, colorBlack);
                        } else {
                            ConsoleSetBlock(x, y, oColor);
                        }//end if
                    }//END FOR
                }//END FOR      

            } else {
                for (int y = yStart; y < (yStart + 3); y++) {
                    for (int x = xStart; x < (xStart + 3); x++) {
                        ConsoleSetBlock(x, y, colorBlack);



                    }//END FOR
                }//END FOR      
            }//end if
        }//END FUNCTION

        static bool PlaceMarker(char[,] board, char symbol, int xSlot, int ySlot) {
            if (board[xSlot, ySlot] == 'X' || board[xSlot, ySlot] == 'O') {
                return false;

            } else {
                return true;
            }//END ELSE IF

        }// END FUNCTION

        static int WinCheck(char[,] board) {

            bool isTie = false;


            //Win Condition 1
            if (board[0, 0] == 'X' && board[1, 0] == 'X' && board[2, 0] == 'X') {
                return +1;
            } else if (board[0, 0] == 'O' && board[1, 0] == 'O' && board[2, 0] == 'O') {
                return +1;
            }
            if (board[0, 1] == 'X' && board[1, 1] == 'X' && board[2, 1] == 'X') {
                return +1;
            } else if (board[0, 1] == 'O' && board[1, 1] == 'O' && board[2, 1] == 'O') {
                return +1;
            }
            if (board[0, 2] == 'X' && board[1, 2] == 'X' && board[2, 2] == 'X') {
                return +1;
            } else if (board[0, 2] == 'O' && board[1, 2] == 'O' && board[2, 2] == 'O') {
                return +1;
            }
            //win condition 2
            if (board[0, 0] == 'X' && board[0, 1] == 'X' && board[0, 2] == 'X') {
                return +1;
            } else if (board[0, 0] == 'O' && board[0, 1] == 'O' && board[0, 2] == 'O') {
                return +1;
            }
            if (board[1, 0] == 'X' && board[1, 1] == 'X' && board[1, 2] == 'X') {
                return +1;
            } else if (board[1, 0] == 'O' && board[1, 1] == 'O' && board[1, 2] == 'O') {
                return +1;
            }
            if (board[2, 0] == 'X' && board[2, 1] == 'X' && board[2, 2] == 'X') {
                return +1;
            } else if (board[2, 0] == 'O' && board[2, 1] == 'O' && board[2, 2] == 'O') {
                return +1;
            }
            if (board[0, 0] == 'X' && board[1, 1] == 'X' && board[2, 2] == 'X') {
                return +1;
            } else if (board[0, 0] == 'O' && board[1, 1] == 'O' && board[2, 2] == 'O') {
                return +1;
            }
            if (board[2, 0] == 'X' && board[1, 1] == 'X' && board[0, 2] == 'X') {
                return +1;
            } else if (board[2, 0] == 'O' && board[1, 1] == 'O' && board[0, 2] == 'O') {
                return +1;
            } else if (isTie == false) {

                int markerCount = 0;

                for (int y = 0; y < board.GetLength(1); y++) {
                    for (int x = 0; x < board.GetLength(0); x++) {
                        if (board[x, y] == 'X' || board[x, y] == 'O') {
                            markerCount++;
                        }

                        if (markerCount == 9) {
                            isTie = true;
                        } else {
                            isTie = false;
                        }
                    }//END NESTED FOR
                }//END FOR
                if (isTie == true) {
                    return 2;
                } //END IF
            }//end else if
            return 0;

        }//END FUNCTION


        static bool InputAcceptable(string input) {
            char[] chars = input.ToCharArray();
            if(input == string.Empty || input.Length < 3) {
                return false; 
               
            }else if (chars[0] >= '0' && chars[0] <= '2' && chars[2] >= '0' && chars[2] <= '2' && (chars[1] == ' ')) {
                 return true;
            }else {
                return false;
             }
        }//END FUNCTION
        #region HELPER DRAWING FUNCTIONS 
        static void ConsoleSetForeColor(byte red, byte grn, byte blu) {
            Console.Write($"\x1b[38;2;{red};{grn};{blu}m");
        }//end function

        static void ConsoleSetBackColor(byte red, byte grn, byte blu) {
            Console.Write($"\x1b[48;2;{red};{grn};{blu}m");
        }//end function

        static void ConsoleSetBlock(int xPos, int yPos, byte[] color) {
            //STORE OLD COLORS
            ConsoleColor origForeground = Console.ForegroundColor;
            ConsoleColor origBackground = Console.BackgroundColor;

            //SET BLOCK COLOR
            byte red = color[0];
            byte grn = color[1];
            byte blu = color[2];

            ConsoleSetForeColor(red, grn, blu);
            ConsoleSetBackColor(red, grn, blu);

            //MOVE CURSOR TO POSITION
            Console.SetCursorPosition(xPos, yPos);

            //DRAW BLOCK
            Console.Write(" ");

            //CHANGE COLORS BACK
            Console.ForegroundColor = origForeground;
            Console.BackgroundColor = origBackground;
        }//end function

        #endregion
        #region Helpers
        static string Input(string message) {
            Console.Write(message);
            return Console.ReadLine();
        }//END FUNCTION

        static void Output(string message) {
            Console.WriteLine(message);
        }//END FUNCTION

        static decimal InputDecimal(string message) {
            decimal parsedValue = 0;
            bool parsed = false;

            do {
                parsed = decimal.TryParse(Input(message), out parsedValue);
                if (parsed == false) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("please enter a numeric value.");
                    Console.ResetColor();
                }//END IF
            } while (parsed == false);
            return parsedValue;
        }//END FUNCTION

        static double InputDouble(string message) {
            double parsedValue = 0;
            bool parsed = false;

            do {
                parsed = double.TryParse(Input(message), out parsedValue);
                if (parsed == false) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("please enter a numeric value.");
                    Console.ResetColor();
                }//END IF
            } while (parsed == false);
            return parsedValue;
        }//END FUNCTION

        static int InputInt(string message) {
            int parsedValue = 0;
            bool parsed = false;

            do {
                parsed = int.TryParse(Input(message), out parsedValue);
                if (parsed == false) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("please enter a numeric value.");
                    Console.ResetColor();
                }//END IF
            } while (parsed == false);
            return parsedValue;
        }//END FUNCTION

        static bool InputYesNo(string message) {
            //WRITE MESSAGE TO CONSOLE
            Console.Write(message);

            //GET THE NEXT KEY PRESSED
            char keyPressed = Console.ReadKey().KeyChar;

            //FORCE A NEW LINE
            Console.WriteLine();

            //CONVERT TO LOWER CASE
            char lowerCaseKey = char.ToLower(keyPressed);

            //COMAPRE
            bool pressedYes = lowerCaseKey == 'y';

            return pressedYes;
        }//end function
        #endregion
    }//END PROGRAM

}// END NAMESPACE