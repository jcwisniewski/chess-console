using Tabuleiro;
using Xadrez;
using System.Collections.Generic;
using System;


namespace chess_console
{
     class View
    {

        public static void PrintChessMatch(ChessMatch chessmatch)
        {
            ShowBoardOnView(chessmatch.board);

            PrintCapturedPieces(chessmatch);

            Console.WriteLine("Turno: " + chessmatch.turn);
            if (!chessmatch.finishedMatch)
            {
                Console.WriteLine("Jogador: " + chessmatch.currentPlayer);

                if (chessmatch.check)
                {
                    Console.WriteLine("XEQUE!");
                }
            }
            else
            {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine("Vencedor: " + chessmatch.currentPlayer);
            }

          
        }

        public static void PrintCapturedPieces(ChessMatch chessmatch)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            PrintHashSet(chessmatch.CapturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintHashSet(chessmatch.CapturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();

        }
        

        public static void PrintHashSet(HashSet<Piece> hashset)
        {
            Console.Write("[");
            foreach(Piece pc in hashset)
            {
                Console.Write(pc + " ");
            }
            Console.Write("]");
        }
        

        
        public static void ShowBoardOnView(Board board)
        {
            for(int i=0; i < board.rows; i++)
            {
                Console.Write(8 - i + " ");
                for(int j=0; j < board.columns; j++)
                {
                        ShowPieceOnView((board.piece(i, j)));
                      
                }

                Console.WriteLine();
                
            }
            Console.WriteLine("  a b c d e f g h");
            
        }

        public static void ShowBoardOnView(Board board, bool [,] possibleMoves)
        {

            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor changedBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < board.rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    if (possibleMoves[i, j])
                    {
                        Console.BackgroundColor = changedBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    ShowPieceOnView((board.piece(i, j)));

                    Console.BackgroundColor = originalBackground;


                }
                Console.WriteLine();

            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }

        public static void ShowPieceOnView(Piece piece)
        {
            if(piece == null)
            {
                Console.Write("- ");

            }
            else
            {
                if (piece.color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor consoleColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = consoleColor;
                }
                Console.Write(" ");
            }
           
        }

        public  static ChessPosition ReadPositionKey()
        {
            string key = Console.ReadLine();
            char column = key[0];
            int row = int.Parse(key[1] + "");
            return new ChessPosition(column, row);
        }
    }
}
