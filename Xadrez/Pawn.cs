using Tabuleiro;

namespace Xadrez
{
    class Pawn : Piece
    {
        public Pawn(Color color, Board board) : base(color, board)
        {

        }
        public bool CanMove(Position position)
        {
            Piece piece = board.piece(position);
            return piece == null || piece.color != this.color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] movementMatrix = new bool[board.rows, board.columns];
            Position positions = new Position(0, 0);
            //upside
            positions.setValues(position.Row - 1, position.Column);
            if (board.PositionValid(positions) && CanMove(positions))
            {
                movementMatrix[positions.Row, positions.Column] = true;
            }

            return movementMatrix;
        }
    public override string ToString()
        {
            return "P";
        }

    }
}
