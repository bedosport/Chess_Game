using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalChessProject.BoardSettings;
namespace FinalChessProject.PiecesSettings
{
    public class Queen : Piece
    {
        

        private int[] queenMovement = { 1, 1, -1, -1, -1, 1, 1, -1, 0, -1, -1, 0, 0, 1, 1, 0 };
        public Queen(Tuple<int, int> piecePosition, pieceType type, pieceColor color) : base(piecePosition, type, color)
        {

        }
        public override void setPiecePosition(int row, int col)
        {
            this.piecePosition = Tuple.Create(row, col);
        }
        public override void firstMoveOccurred()
        {
            this.firstMove = true;
        }
        public override List<Move> getLegalMovesWithCheck(Board board)
        {
            List<Move> queenMoves = new List<Move>();
            pieceColor currentPieceColor = board.getBoardPieces()[this.getPiecePosition().Item1, this.getPiecePosition().Item2].getPieceColor();
            for (int i = 0; i < queenMovement.Length; i += 2)
            {
                int DestinationRow = this.getPiecePosition().Item1;
                int DestinationCol = this.getPiecePosition().Item2;
                while (Utility.isValidMove(DestinationRow, DestinationCol) )
                {
                    DestinationRow += queenMovement[i];
                    DestinationCol += queenMovement[i + 1];

                    if (Utility.isValidMove(DestinationRow, DestinationCol) &&
                        Utility.kingStillSafe(board, this.getPiecePosition(), Tuple.Create(DestinationRow, DestinationCol)))
                    {

                        if (board.isEmptyCell(DestinationRow, DestinationCol))
                        {
                            queenMoves.Add(new NormalMove(Tuple.Create(DestinationRow, DestinationCol)));
                        }
                        else
                        {
                            pieceColor destinationPieceColor = board.getBoardPieces()[DestinationRow, DestinationCol].getPieceColor();
                            if (currentPieceColor != destinationPieceColor)
                            {
                                queenMoves.Add(new AttackMove(Tuple.Create(DestinationRow, DestinationCol)));
                                break;
                            }
                            else
                                break;
                        }
                    }
                    else
                        break;
                }
            }
            return queenMoves;
        }
        public override List<Move> getLegalMovesWithoutCheck(Board board)
        {
            List<Move> queenMoves = new List<Move>();
            pieceColor currentPieceColor = board.getBoardPieces()[this.getPiecePosition().Item1, this.getPiecePosition().Item2].getPieceColor();
            for (int i = 0; i < queenMovement.Length; i += 2)
            {
                int DestinationRow = this.getPiecePosition().Item1;
                int DestinationCol = this.getPiecePosition().Item2;
                while (Utility.isValidMove(DestinationRow, DestinationCol))
                {
                    DestinationRow += queenMovement[i];
                    DestinationCol += queenMovement[i + 1];


                    if (Utility.isValidMove(DestinationRow, DestinationCol))
                    {

                        if (board.isEmptyCell(DestinationRow, DestinationCol))
                        {
                            queenMoves.Add(new NormalMove(Tuple.Create(DestinationRow, DestinationCol)));
                        }
                        else
                        {
                            pieceColor destinationPieceColor = board.getBoardPieces()[DestinationRow, DestinationCol].getPieceColor();
                            if (currentPieceColor != destinationPieceColor)
                            {
                                queenMoves.Add(new AttackMove(Tuple.Create(DestinationRow, DestinationCol)));
                                break;
                            }
                            else
                                break;
                        }
                    }
  
     
                }
            }
            return queenMoves;
        }

    }
}
