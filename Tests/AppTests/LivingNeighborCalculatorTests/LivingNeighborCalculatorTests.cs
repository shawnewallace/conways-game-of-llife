using Cgol.App;
using Cgol.Tests.Infrastructure;
using Xunit;

namespace Cgol.Tests.AppTests.NeighborCalculatorTests
{
	public class LivingNeighborCalculatorTests : CgolTestBase
	{
		[Theory]
		[InlineData(0)]
		[InlineData(1)]
		[InlineData(2)]
		[InlineData(3)]
		[InlineData(4)]
		[InlineData(5)]
		[InlineData(6)]
		[InlineData(7)]
		[InlineData(8)]
		public void calculates_the_proper_number(int numNeighbors)
		{
			var calc = new NeighborCalculator();
			CreateBoard(3, 3);
			SetNumberOfNeighborsBeforeTick(numNeighbors);
			var result = calc.Calc(_board, 1, 1);
			Assert.Equal(numNeighbors, result);
		}
	}
}