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

        public  bool check { get; private set; }

        private HashSet<Piece> pieces;

        private HashSet<Piece> captured;


        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finishedMatch = false;
            check = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            AddPiecesOnBoard();
        }

        private Color Opponent(Color color)
        {
            if(color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece king (Color color)
        {
            foreach(Piece pc in PiecesInGame(color))
            {
                if(pc is King)
                {
                    return pc;
                }
            }

            return null;
        }

        public bool IsCheck(Color color)
        {
            Piece R = king(color);
            if(R == null)
            {
                throw new BoardException("Não tem rei da cor " + color + " no tabuleiro");
            }
            foreach(Piece pc in PiecesInGame(Opponent(color)))
            {
                bool[,] matrix = pc.PossibleMoves();
                if(matrix[R.position.Row, R.position.Column])
                {
                    return true;
                }
            }
            return false;

        }

        public bool IsCheckMate(Color color)
        {
            if (!IsCheck(color))
            {
                return false;
            }
            foreach(Piece piece in PiecesInGame(color))
            {
                bool[,] matrix = piece.PossibleMoves();
                for(int i=0; i < board.rows ; i++)
                { 

                    for(int j=0; j < board.columns; j++)
                    {
                        if (matrix[i, j])
                        {
                            Position source = piece.position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = PerformMove(source, destiny);
                            bool testCheck = IsCheck(color);
                            DeformMove(source, destiny, capturedPiece);
                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
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

        public Piece PerformMove(Position source, Position destiny)
        {
            Piece piece = board.RemovePiece(source);
            piece.MovementIncrementation();
            Piece capturedPiece = board.RemovePiece(destiny);
            board.AddPiece(piece, destiny);
            if( capturedPiece!= null)
            {
                captured.Add(capturedPiece);
            }

            return capturedPiece;
        }

        public void DeformMove(Position source, Position destiny, Piece capturedPiece)
        {
            Piece piece = board.RemovePiece(destiny);
            piece.MovementDecrementation();
            
            if (capturedPiece != null)
            {
                board.AddPiece(capturedPiece, destiny);
                captured.Remove(capturedPiece);
            }

            board.AddPiece(piece, source);
        }

        public  void PerformPlay(Position source, Position destiny)
        {
            Piece capturedPiece = PerformMove(source, destiny);
            if (IsCheck(currentPlayer)){
                DeformMove(source, destiny, capturedPiece);
                throw new BoardException("Você não pode se colocar em cheque!");
            }
            if (IsCheck(Opponent(currentPlayer))){
                check = true;
            }
          
            else
            {
                check = false;
            }

            if (IsCheckMate(Opponent(currentPlayer)))
            {
                finishedMatch = true;
            }
            else
            {
                turn++;
                ChangePlayer();
            }
            
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

            InsertNewPiece('h', 1, new Rook(Color.White, board));
            //InsertNewPiece('b', 1, new Knight(Color.White, board));
            //InsertNewPiece('c', 1, new Bishop(Color.White, board));
            //InsertNewPiece('d', 1, new Queen(Color.White, board));
            InsertNewPiece('g', 1, new Rook(Color.White, board));
            //InsertNewPiece('f', 1, new Bishop(Color.White, board));
            //InsertNewPiece('g', 1, new Knight(Color.White, board));
            InsertNewPiece('a', 1, new King(Color.White, board));
            //InsertNewPiece('a', 2, new Pawn(Color.White, board));
            //InsertNewPiece('b', 2, new Pawn(Color.White, board));
            //InsertNewPiece('c', 2, new Pawn(Color.White, board));
            //InsertNewPiece('d', 2, new Pawn(Color.White, board));
            //InsertNewPiece('e', 2, new Pawn(Color.White, board));
            //InsertNewPiece('f', 2, new Pawn(Color.White, board));
            //InsertNewPiece('g', 2, new Pawn(Color.White, board));
            //InsertNewPiece('h', 2, new Pawn(Color.White, board));

            InsertNewPiece('a', 8, new King(Color.Black, board));
            //InsertNewPiece('b', 8, new Rook(Color.Black, board));
            //InsertNewPiece('c', 8, new Rook(Color.Black, board));
            //InsertNewPiece('d', 8, new Knight(Color.Black, board));
            //InsertNewPiece('e', 8, new Knight(Color.Black, board));
            //InsertNewPiece('f', 8, new Knight(Color.Black, board));
            //InsertNewPiece('g', 8, new Knight(Color.Black, board));
            //InsertNewPiece('h', 8, new Rook(Color.Black, board));
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
