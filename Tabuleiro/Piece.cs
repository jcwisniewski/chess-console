
namespace Tabuleiro
{
     abstract class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int movementQuantity { get; protected set; }
        public Board board { get; protected set; }


        public Piece( Color color, Board board)
        {
            this.position = null;
            this.color = color;
            this.board = board;
            this.movementQuantity = 0;
        }

        public void MovementIncrementation()
        {
            movementQuantity++;
        }

        public void MovementDecrementation()
        {
            movementQuantity--;
        }

        public bool HasValidMoves()
        {
            bool[,] matrix = PossibleMoves();
            for(int i=0; i < board.rows; i++)
            {
                for(int j=0; j < board.columns; j++)
                {
                    if (matrix[i, j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CanMoveTo(Position position)
        {
            return PossibleMoves()[position.Row, position.Column];
        }

        public abstract bool[,] PossibleMoves(); 
    } 


}
