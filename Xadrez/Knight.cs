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
         
            Position positions = new Position(0, 0);
            //upside right
            positions.setValues(position.Row - 2, position.Column + 1);
            if (board.PositionValid(positions) && CanMove(positions))
            {
                movementMatrix[positions.Row, positions.Column] = true;
            }

            //upside left
            positions.setValues(position.Row - 2, position.Column - 1);
            if (board.PositionValid(positions) && CanMove(positions))
            {
                movementMatrix[positions.Row, positions.Column] = true;
            }

            //right up
            positions.setValues(position.Row - 1, position.Column + 2);
            if (board.PositionValid(positions) && CanMove(positions))
            {
                movementMatrix[positions.Row, positions.Column] = true;
            }

            //right down
            positions.setValues(position.Row + 1, position.Column + 2);
            if (board.PositionValid(positions) && CanMove(positions))
            {
                movementMatrix[positions.Row, positions.Column] = true;
            }

            //down right
            positions.setValues(position.Row + 2, position.Column + 1);
            if (board.PositionValid(positions) && CanMove(positions))
            {
                movementMatrix[positions.Row, positions.Column] = true;
            }

            //down left
            positions.setValues(position.Row + 2, position.Column + 1);
            if (board.PositionValid(positions) && CanMove(positions))
            {
                movementMatrix[positions.Row, positions.Column] = true;
            }

            //left down
            positions.setValues(position.Row + 1, position.Column - 2);
            if (board.PositionValid(positions) && CanMove(positions))
            {
                movementMatrix[positions.Row, positions.Column] = true;
            }

            //left up
            positions.setValues(position.Row - 1, position.Column - 2);
            if (board.PositionValid(positions) && CanMove(positions))
            {
                movementMatrix[positions.Row, positions.Column] = true;
            }

            return movementMatrix;



        }

        public override string ToString()
        {
            return "N";
        }

    }
       

    
}
