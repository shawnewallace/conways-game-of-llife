using Xunit;
using Shouldly;
using Cgol.Tests.Infrastructure;
using Cgol.App;

namespace Cgol.Tests.AppTests.GameCreatorTests
{
	public class ExecuteTests : CgolTestBase
	{

		[Theory]
		[InlineData(3, 3, .5)]
		[InlineData(10, 10, .1)]
		[InlineData(7, 10, .1)]
		[InlineData(10, 7, .1)]
		public void CreateNewGameTests(int width, int height, double fillFactor)
		{
			var creator = new GameCreator();
			creator.Width = width;
			creator.Height = height;
			creator.FillFactor = fillFactor;

			var game = creator.Execute();

			game.Width.ShouldBe(width);
			game.Height.ShouldBe(height);
			game.FillFactor.ShouldBe(fillFactor);
		}
	}
}