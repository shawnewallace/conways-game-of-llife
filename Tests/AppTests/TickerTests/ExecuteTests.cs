using Xunit;
using Shouldly;
using Cgol.Tests.Infrastructure;
using Cgol.App;
using Moq;
using Cgol.Domain.Infrastructure;
using Cgol.App.Models;

namespace Cgol.Tests.AppTests.TickerTests
{
	public class ExecuteTests : CgolTestBase
	{
		[Theory]
		// Any live cell with fewer than two live neighbours dies, as if caused by under-population.
		[InlineData(0, true, false)]
		[InlineData(1, true, false)]
		// Any live cell with two or three live neighbours lives on to the next generation.
		[InlineData(2, true, true)]
		[InlineData(3, true, true)]
		// Any live cell with more than three live neighbours dies, as if by overcrowding.
		[InlineData(4, true, false)]
		[InlineData(5, true, false)]
		[InlineData(6, true, false)]
		[InlineData(7, true, false)]
		[InlineData(8, true, false)]
		// Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
		[InlineData(0, false, false)]
		[InlineData(1, false, false)]
		[InlineData(2, false, false)]
		[InlineData(3, false, true)]
		[InlineData(4, false, false)]
		[InlineData(5, false, false)]
		[InlineData(6, false, false)]
		[InlineData(7, false, false)]
		[InlineData(8, false, false)]
		public void is_alive_or_dead(int numNeighborsBeforeTick, bool livingBeforeTick, bool livingAfterTick)
		{
			var mockCalc = new Mock<INeighborCalculator>();
			mockCalc
				.Setup(n => n.Calc(It.IsAny<Cell[,]>(), 1, 1))
				.Returns(numNeighborsBeforeTick);

			var ticker = new Ticker(mockCalc.Object);

			CreateBoard(3, 3);
			_board[1, 1].Alive = livingBeforeTick;
			SetNumberOfNeighborsBeforeTick(numNeighborsBeforeTick);

			var newBoard = ticker.Execute(_board);
			Assert.Equal(livingAfterTick, newBoard[1, 1].Alive);
		}
	}
}