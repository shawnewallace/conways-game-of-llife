using Xunit;
using Shouldly;
using Cgol.Tests.Infrastructure;
using Cgol.App;

namespace Cgol.Tests.AppTests.GameFactoryTests
{
	public class ExecuteTests : CgolTestBase
	{

		[Theory]
		[InlineData(3, 3, .5)]
		[InlineData(10, 10, .1)]
		[InlineData(7, 10, .3)]
		[InlineData(10, 7, .2)]
		public void CreateNewGameTests(int width, int height, double fillFactor)
		{
			var creator = new GameFactory(null);
			creator.Width = width;
			creator.Height = height;
			creator.FillFactor = fillFactor;

			var game = creator.Execute();

			game.Width.ShouldBe(width);
			game.Height.ShouldBe(height);
		}

		[Theory]
		[InlineData(3, 3)]
		[InlineData(10, 10)]
		[InlineData(7, 10)]
		[InlineData(10, 7)]
		public void all_cells_are_initially_dead_because_of_fill_factor_0(int width, int height)
		{
			var creator = new GameFactory(null);
			creator.Width = width;
			creator.Height = height;
			creator.FillFactor = 0;
			var result = creator.Execute();

			for (var i = 0; i < width; i++)
				for (var j = 0; j < height; j++)
					Assert.False(result.IsAliveAt(i, j));
		}

		[Theory]
		[InlineData(3, 3)]
		[InlineData(10, 10)]
		[InlineData(7, 10)]
		[InlineData(10, 7)]
		public void all_cells_are_initially_alive_because_of_fill_factor_1(int width, int height)
		{
			var creator = new GameFactory(null);
			creator.Width = width;
			creator.Height = height;
			creator.FillFactor = 1;
			var result = creator.Execute();

			for (var i = 0; i < width; i++)
				for (var j = 0; j < height; j++)
					Assert.True(result.IsAliveAt(i, j));
		}
	}
}