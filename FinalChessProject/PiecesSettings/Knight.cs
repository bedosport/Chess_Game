using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalChessProject.BoardSettings;
namespace FinalChessProject.PiecesSettings
{
    class Knight : Piece
    {

        private int[] knightMovment = { -1, -2, -2, -1, -2, 1, -1, 2, 1, 2, 2, 1, 2, -1, 1, -2 };
        public Knight(Tuple<int, int> piecePosition, pieceType type, pieceColor color) : base(piecePosition, type, color)
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

            List<Move> knightMoves = new List<Move>();
            pieceColor currentPieceColor = board.getBoardPieces()[this.getPiecePosition().Item1, this.getPiecePosition().Item2].getPieceColor();

            for (int i = 0; i < knightMovment.Length; i += 2)
            {
                int DestinationRow = this.getPiecePosition().Item1 + knightMovment[i];
                int DestinationCol = this.getPiecePosition().Item2 + knightMovment[i + 1];
         
                if (Utility.isValidMove(DestinationRow, DestinationCol) &&
                 Utility.kingStillSafe(board, this.getPiecePosition(), Tuple.Create(DestinationRow, DestinationCol)))
                {
                    if (board.isEmptyCell(DestinationRow, DestinationCol))
                    {
                        knightMoves.Add(new NormalMove(Tuple.Create(DestinationRow, DestinationCol)));
                    }
                    else
                    {
                        pieceColor destinationPieceColor = board.getBoardPieces()[DestinationRow, DestinationCol].getPieceColor();
                        if (currentPieceColor != destinationPieceColor)
                            knightMoves.Add(new AttackMove(Tuple.Create(DestinationRow, DestinationCol)));
                    }
                }
            }
            return knightMoves;
        }

        public override List<Move> getLegalMovesWithoutCheck(Board board)
        {

            List<Move> knightMoves = new List<Move>();
            pieceColor currentPieceColor = board.getBoardPieces()[this.getPiecePosition().Item1, this.getPiecePosition().Item2].getPieceColor();
            for (int i = 0; i < knightMovment.Length; i += 2)
            {
                int DestinationRow = this.getPiecePosition().Item1 + knightMovment[i];
                int DestinationCol = this.getPiecePosition().Item2 + knightMovment[i + 1];
         
                if (Utility.isValidMove(DestinationRow, DestinationCol))
                {
                    if (board.isEmptyCell(DestinationRow, DestinationCol))
                    {
                        knightMoves.Add(new NormalMove(Tuple.Create(DestinationRow, DestinationCol)));
                    }
                    else
                    {
                        pieceColor destinationPieceColor = board.getBoardPieces()[DestinationRow, DestinationCol].getPieceColor();
                        if (currentPieceColor != destinationPieceColor)
                            knightMoves.Add(new AttackMove(Tuple.Create(DestinationRow, DestinationCol)));
                    }
                }
            }
            return knightMoves;
        }
    }
}
