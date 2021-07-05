using Exceptions;

namespace Tabuleiro
{
     class Board
    {
        public int rows { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            pieces = new Piece[rows, columns];  
        }

        public Piece piece(int row, int column)
        {
            return pieces[row, column];
        }

        public Piece piece(Position position)
        {
            return pieces[position.Row, position.Column];
        }

        public bool PieceExists(Position position)
        {
            ValidatePosition(position);
            return piece(position) != null;
        }

        public void AddPiece(Piece piece, Position position)
        {
            if (PieceExists(position))
            {
                throw new BoardException("There is a piece on this position!");
            }
            pieces[position.Row, position.Column] = piece;
            piece.position = position;
        }

        public Piece RemovePiece (Position position)
        {
            if(piece(position) == null)
            {
                return null;
            }

            Piece aux = piece(position);
            pieces[position.Row, position.Column] = null;
            return aux;
        }

        public bool PositionValid(Position position)
        {
            if(position.Row < 0 || position.Row >= rows || position.Column < 0 || position.Column >= columns)
            {
                return false;
            }

            return true;
        }

        public void ValidatePosition(Position position)
        {
            if (!PositionValid(position))
            {
                throw new BoardException("Invalid position!");
            }
        }
    }
}
