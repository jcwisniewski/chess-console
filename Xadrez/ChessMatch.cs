using Tabuleiro;
using Exceptions;
using System.Collections.Generic;

namespace Xadrez
{
    class ChessMatch
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public  Color currentPlayer { get; private set; }
        public bool finishedMatch {get; private set;}

        private HashSet<Piece> pieces;

        private HashSet<Piece> captured;


        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finishedMatch = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            AddPiecesOnBoard();
        }

        public void ValidateSourcePosition(Position positions)
        {
            if(board.piece(positions) == null)
            {
                throw new BoardException("Não existe peça na posição de origem escolhida");
            }
            if(currentPlayer != board.piece(positions).color)
            {
                throw new BoardException("A peça de origem escolhida não é sua!");

            }
            if (!board.piece(positions).HasValidMoves())
            {
                throw new BoardException("Não existe movimentos validos para esta peça!");

            }
        }

        public void ValidateDestinyPosition(Position source, Position destiny)
        {
            if (!board.piece(source).CanMoveTo(destiny))
            {
                throw new BoardException("Esse destino não é valido para esta peça!");
            }
        }



        private void ChangePlayer()
        {
            if(currentPlayer == Color.White)
            {
                currentPlayer = Color.Black;
            }
            else
            {
                currentPlayer = Color.White;
            }
        }

        public void PerformMove(Position source, Position destiny)
        {
            Piece piece = board.RemovePiece(source);
            piece.MovementIncrementation();
            Piece capturedPiece = board.RemovePiece(destiny);
            board.AddPiece(piece, destiny);
            if( capturedPiece!= null)
            {
                captured.Add(capturedPiece);
            }
        }

        public  void PerformPlay(Position source, Position destiny)
        {
            PerformMove(source, destiny);
            turn++;
            ChangePlayer();
        }

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece pc in captured)
            {
                if(pc.color == color)
                {
                    aux.Add(pc);
                }
            }
            return aux;
        }

        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece pc in pieces)
            {
                if (pc.color == color)
                {
                    aux.Add(pc);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }


        public void InsertNewPiece(char column, int row, Piece piece)
        {
            board.AddPiece(piece, new ChessPosition(column, row).toPosition());
            pieces.Add(piece);
        }

        private void AddPiecesOnBoard()
        {

            InsertNewPiece('a', 1, new Rook(Color.White, board));
            InsertNewPiece('b', 1, new Knight(Color.White, board));
            InsertNewPiece('c', 1, new Bishop(Color.White, board));
            InsertNewPiece('d', 1, new Queen(Color.White, board));
            InsertNewPiece('e', 1, new King(Color.White, board));
            InsertNewPiece('f', 1, new Bishop(Color.White, board));
            InsertNewPiece('g', 1, new Knight(Color.White, board));
            InsertNewPiece('h', 1, new Rook(Color.White, board));
            //InsertNewPiece('a', 2, new Pawn(Color.White, board));
            //InsertNewPiece('b', 2, new Pawn(Color.White, board));
            //InsertNewPiece('c', 2, new Pawn(Color.White, board));
            //InsertNewPiece('d', 2, new Pawn(Color.White, board));
            //InsertNewPiece('e', 2, new Pawn(Color.White, board));
            //InsertNewPiece('f', 2, new Pawn(Color.White, board));
            //InsertNewPiece('g', 2, new Pawn(Color.White, board));
            //InsertNewPiece('h', 2, new Pawn(Color.White, board));

            InsertNewPiece('a', 8, new Rook(Color.Black, board));
            InsertNewPiece('b', 8, new Knight(Color.Black, board));
            InsertNewPiece('c', 8, new Bishop(Color.Black, board));
            InsertNewPiece('d', 8, new Queen(Color.Black, board));
            InsertNewPiece('e', 8, new King(Color.Black, board));
            InsertNewPiece('f', 8, new Bishop(Color.Black, board));
            InsertNewPiece('g', 8, new Knight(Color.Black, board));
            InsertNewPiece('h', 8, new Rook(Color.Black, board));
            //InsertNewPiece('a', 7, new Pawn(Color.Black, board));
            //InsertNewPiece('b', 7, new Pawn(Color.Black, board));
            //InsertNewPiece('c', 7, new Pawn(Color.Black, board));
            //InsertNewPiece('d', 7, new Pawn(Color.Black, board));
            //InsertNewPiece('e', 7, new Pawn(Color.Black, board));
            //InsertNewPiece('f', 7, new Pawn(Color.Black, board));
            //InsertNewPiece('g', 7, new Pawn(Color.Black, board));
            //InsertNewPiece('h', 7, new Pawn(Color.Black, board));



        }

    }
}
