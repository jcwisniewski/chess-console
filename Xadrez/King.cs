using Tabuleiro;

namespace Xadrez
{
    class King : Piece
    {
        public King(Color color, Board board) : base(color, board)
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
            Position position = new Position(0, 0);
            //upside
            position.setValues(position.Row - 1, position.Column);
                if(board.PositionValid(position) && CanMove(position))
            {
                movementMatrix[position.Row, position.Column] = true;
            }

            //ne
            position.setValues(position.Row - 1, position.Column + 1);
            if (board.PositionValid(position) && CanMove(position))
            {
                movementMatrix[position.Row, position.Column] = true;
            }

            //right
            position.setValues(position.Row, position.Column + 1);
            if (board.PositionValid(position) && CanMove(position))
            {
                movementMatrix[position.Row, position.Column] = true;
            }

            //se
            position.setValues(position.Row + 1, position.Column + 1);
            if (board.PositionValid(position) && CanMove(position))
            {
                movementMatrix[position.Row, position.Column] = true;
            }

            //downside
            position.setValues(position.Row + 1, position.Column);
            if (board.PositionValid(position) && CanMove(position))
            {
                movementMatrix[position.Row, position.Column] = true;
            }

            //sl
            position.setValues(position.Row + 1, position.Column - 1);
            if (board.PositionValid(position) && CanMove(position))
            {
                movementMatrix[position.Row, position.Column] = true;
            }

            //left
            position.setValues(position.Row, position.Column - 1);
            if (board.PositionValid(position) && CanMove(position))
            {
                movementMatrix[position.Row, position.Column] = true;
            }

            //nl
            position.setValues(position.Row - 1, position.Column - 1);
            if (board.PositionValid(position) && CanMove(position))
            {
                movementMatrix[position.Row, position.Column] = true;
            }

            return movementMatrix;



        }
        public override string ToString()
        {
            return "K";
        }

    }
}
