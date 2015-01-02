using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
	public interface IGameWinnerService
	{
		char Validate(char[,] gameBoard);
	}

    public class GameWinnerService : IGameWinnerService
    {
		private const char symbolForNoWinner = ' ';

		public char Validate(char[,] gameBoard)
		{
			var currentWinningSymbol = checkForThreeInARowInHorizontalRow(gameBoard);
			if (currentWinningSymbol != symbolForNoWinner)
				return currentWinningSymbol;
			currentWinningSymbol = checkForThreeInARowInVerticalColumn(gameBoard);
			if (currentWinningSymbol != symbolForNoWinner)
				return currentWinningSymbol;
			currentWinningSymbol = checkForThreeInARowDiagonally(gameBoard);
			return currentWinningSymbol;
		}

		private static char checkForThreeInARowDiagonally(char[,] gameBoard)
		{
			var cellOneChar = gameBoard[0, 0];
			var cellTwoChar = gameBoard[1, 1];
			var cellThreeChar = gameBoard[2, 2];
			if(cellOneChar == cellTwoChar &&
				cellTwoChar == cellThreeChar)
			{
				return cellOneChar;
			}
			return ' ';

		}

		private static char checkForThreeInARowInVerticalColumn(char[,] gameBoard)
		{
			var rowOneChar = gameBoard[0, 0];
			var rowTwoChar = gameBoard[1, 0];
			var rowThreeChar = gameBoard[2, 0];
			if (rowOneChar == rowTwoChar &&
				rowTwoChar == rowThreeChar)
			{
				return rowOneChar;
			}
			return ' ';
		}
		private static char checkForThreeInARowInHorizontalRow(char[,] gameBoard)
		{
			var columnOneChar = gameBoard[0, 0];
			var columnTwoChar = gameBoard[0, 1];
			var columnThreeChar = gameBoard[0, 2];
			if (columnOneChar == columnTwoChar &&
				columnTwoChar == columnThreeChar)
			{
				return columnOneChar;
			}
			return ' ';
		}
	}

}
