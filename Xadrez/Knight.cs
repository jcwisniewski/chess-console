using Tabuleiro;

namespace Xadrez
{
    class Knight : Piece
    {
        public Knight(Color color, Board board) : base(color, board)
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
            //upside right
            position.setValues(position.Row - 2, position.Column + 1);
            if (board.PositionValid(position) && CanMove(position))
            {
                movementMatrix[position.Row, position.Column] = true;
            }

            //upside left
            position.setValues(position.Row - 2, position.Column - 1);
            if (board.PositionValid(position) && CanMove(position))
            {
                movementMatrix[position.Row, position.Column] = true;
            }

            //right up
            position.setValues(position.Row - 1, position.Column + 2);
            if (board.PositionValid(position) && CanMove(position))
            {
                movementMatrix[position.Row, position.Column] = true;
            }

            //right down
            position.setValues(position.Row + 1, position.Column + 2);
            if (board.PositionValid(position) && CanMove(position))
            {
                movementMatrix[position.Row, position.Column] = true;
            }

            //down right
            position.setValues(position.Row + 2, position.Column + 1);
            if (board.PositionValid(position) && CanMove(position))
            {
                movementMatrix[position.Row, position.Column] = true;
            }

            //down left
            position.setValues(position.Row + 2, position.Column + 1);
            if (board.PositionValid(position) && CanMove(position))
            {
                movementMatrix[position.Row, position.Column] = true;
            }

            //left down
            position.setValues(position.Row + 1, position.Column - 2);
            if (board.PositionValid(position) && CanMove(position))
            {
                movementMatrix[position.Row, position.Column] = true;
            }

            //left up
            position.setValues(position.Row - 1, position.Column - 2);
            if (board.PositionValid(position) && CanMove(position))
            {
                movementMatrix[position.Row, position.Column] = true;
            }

            return movementMatrix;



        }

        public override string ToString()
        {
            return "N";
        }

    }
       

    
}
