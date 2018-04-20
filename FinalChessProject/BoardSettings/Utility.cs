using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalChessProject.PiecesSettings;
using FinalChessProject.BoardSettings;

using FinalChessProject.PlayersSettings;


namespace FinalChessProject.BoardSettings
{

    public static class Utility
    {

        public static bool isValidMove(int row, int col)
        {
            return row >= 0 && col >= 0 && row <= 7 && col <= 7;
        }

        public static List<Move> getPlayerLegalMove(Board board ,pieceColor color)
        {
            List<Move> legalMoves = new List<Move>();
            for (int i = 0; i < 8; ++i)
                for (int j = 0; j < 8; ++j)
                    if (!board.isEmptyCell(i, j) && board.getBoardPieces()[i, j].getPieceColor() == color)
                        legalMoves.AddRange(board.getBoardPieces()[i, j].getLegalMovesWithoutCheck(board));
            return legalMoves;
        }

        public  static bool kingStillSafe(Board board, Tuple<int, int> currentPosition, Tuple<int, int> destinationPosition)
        {

            if (board.getBoardPieces()[currentPosition.Item1, currentPosition.Item2].getPieceColor() == pieceColor.White)
            {

                Board tmpBoard = new Board(board);
                Piece tmpPiece = tmpBoard.getBoardPieces()[currentPosition.Item1, currentPosition.Item2];
                tmpPiece.setPiecePosition(destinationPosition.Item1, destinationPosition.Item2);
                tmpBoard.getBoardPieces()[destinationPosition.Item1, destinationPosition.Item2] = tmpPiece;
                tmpBoard.getBoardPieces()[currentPosition.Item1, currentPosition.Item2] = null;
                Tuple<int, int> activePlayerKingPosition = tmpBoard.getPlayerKingPosition(pieceColor.White);
                List<Move> opponentLegalMoves =  getPlayerLegalMove(tmpBoard, pieceColor.BLack);
                foreach (Move m in opponentLegalMoves)
                {
                    if (m.getMovePosition().Item1 == activePlayerKingPosition.Item1 &&
                        m.getMovePosition().Item2 == activePlayerKingPosition.Item2)
                        return false;
                }
            }
            else if (board.getBoardPieces()[currentPosition.Item1, currentPosition.Item2].getPieceColor() == pieceColor.BLack)
            {

                Board tmpBoard = new Board(board);
                Piece tmpPiece = tmpBoard.getBoardPieces()[currentPosition.Item1, currentPosition.Item2];
                tmpPiece.setPiecePosition(destinationPosition.Item1, destinationPosition.Item2);
                tmpBoard.getBoardPieces()[destinationPosition.Item1, destinationPosition.Item2] = tmpPiece;
                tmpBoard.getBoardPieces()[currentPosition.Item1, currentPosition.Item2] = null;
                Tuple<int, int> activePlayerKingPosition = tmpBoard.getPlayerKingPosition(pieceColor.BLack);
                List<Move> opponentLegalMoves = getPlayerLegalMove(tmpBoard, pieceColor.White);
                foreach (Move m in opponentLegalMoves)
                {
                    if (m.getMovePosition().Item1 == activePlayerKingPosition.Item1 &&
                        m.getMovePosition().Item2 == activePlayerKingPosition.Item2)
                        return false;
                }
            }
            return true;
        }
    }
}
