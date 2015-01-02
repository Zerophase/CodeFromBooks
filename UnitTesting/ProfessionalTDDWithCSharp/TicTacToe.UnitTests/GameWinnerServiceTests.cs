using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TicTacToe;

namespace TicTacToe.UnitTests
{
	[TestFixture]
    public class GameWinnerServiceTests
    {
		private IGameWinnerService gameWinnerService;
		private char[,] gameBoard;

		private GameWinnerService makeGameWinnerService()
		{
			return new GameWinnerService();
		}

		private char[,] makeGameBoard()
		{
			return new char[3, 3] 
							{
								{' ', ' ', ' '},
								{' ', ' ', ' '},
								{' ', ' ', ' '}
							};
		}

		[Test]
		public void Validate_NeitherPlayerHasThreeInARow_ReturnsEmptyChar()
		{
			gameWinnerService = makeGameWinnerService();
			gameBoard = makeGameBoard();

			const char expected = ' ';
			var actual = gameWinnerService.Validate(gameBoard);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Validate_PlayerWithAllSpacesInTopRowIsWinner_ReturnsCharX()
		{
			gameWinnerService = makeGameWinnerService();
			gameBoard = makeGameBoard();

			const char expected = 'X';
			for (var rowIndex = 0; rowIndex < 3; rowIndex++)
			{
				gameBoard[0, rowIndex] = expected;
			}
			var actual = gameWinnerService.Validate(gameBoard);

			Assert.AreEqual(expected.ToString(), actual.ToString());
		}

		[Test]
		public void Validate_PlayerWithAllSpacesInFirstColumnIWinner_ReturnsCharX()
		{
			gameWinnerService = makeGameWinnerService();
			gameBoard = makeGameBoard();

			const char expected = 'X';
			for (var columnIndex = 0; columnIndex < 3; columnIndex++)
			{
				gameBoard[columnIndex, 0] = expected;
			}
			var actual = gameWinnerService.Validate(gameBoard);

			Assert.AreEqual(expected.ToString(), actual.ToString());
		}

		[Test]
		public void Validate_PlayerWithThreeInArowDiagonallyDownAndToRightIsWInner_ReturnsCharX()
		{
			gameWinnerService = makeGameWinnerService();
			gameBoard = makeGameBoard();

			const char expected = 'X';
			for (var cellIndex = 0; cellIndex < 3; cellIndex++)
			{
				gameBoard[cellIndex, cellIndex] = expected;
			}
			var actual = gameWinnerService.Validate(gameBoard);

			Assert.AreEqual(expected.ToString(), actual.ToString());
		}
    }
}
