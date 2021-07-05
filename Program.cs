using System;
using Tabuleiro;
using Xadrez;
using Exceptions;

namespace chess_console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {

                
                ChessMatch chessmatch = new ChessMatch();

                while (!chessmatch.finishedMatch)
                {
                    Console.Clear();
                    View.ShowBoardOnView(chessmatch.board);


                    Console.WriteLine("Turno: " + chessmatch.turn);

                    Console.WriteLine("Jogador: " + chessmatch.currentPlayer);

                    Console.WriteLine("Origem: ");
                    Position source = View.ReadPositionKey().toPosition();


                    bool[,] possibleMoves = chessmatch.board.piece(source).PossibleMoves();

                    Console.Clear();
                    View.ShowBoardOnView(chessmatch.board, possibleMoves);

                    Console.WriteLine();
                    Console.WriteLine("Destino: ");
                    Position destiny = View.ReadPositionKey().toPosition();

                    chessmatch.PerformPlay(source, destiny);
                }


                
            }catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
          
        }

    
    }
}
