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
                Board bd = new Board(8, 8);

                bd.AddPiece(new Rook(Color.Black, bd), new Position(0, 0));
                bd.AddPiece(new Knight(Color.Black, bd), new Position(0, 1));
                bd.AddPiece(new Knight(Color.White, bd), new Position(0, 5));

                //bd.AddPiece(new Bishop(Color.Black, bd), new Position(0, 2));
                //bd.AddPiece(new Queen(Color.Black, bd), new Position(0, 3));
                //bd.AddPiece(new King(Color.Black, bd), new Position(0, 4));
                //bd.AddPiece(new Bishop(Color.Black, bd), new Position(0, 5));
                //bd.AddPiece(new Knight(Color.Black, bd), new Position(0, 6));
                //bd.AddPiece(new Rook(Color.Black, bd), new Position(0, 7));

                View.ShowBoardOnView(bd);
            }catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
          
        }

    
    }
}
