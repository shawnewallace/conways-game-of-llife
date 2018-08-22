using conways_game_of_life.core;
using conways_game_of_life.lib;
using Xunit;

namespace conways_game_of_life.tests
{
  public class GameCreatorCases : cgol_test
  {
    [Theory]
    [InlineData(3, 3, .5)]
    [InlineData(10, 10, .1)]
    [InlineData(7, 10, .1)]
    [InlineData(10, 7, .1)]
    public void CreateValues(int width, int height, double fillFactor)
    {
      var _creator= new GameCreator(new Game(new TestTicker()));
      
      _creator.Width = width;
      _creator.Height = height;
      _creator.FillFactor = 0;
      _creator.Generator = BoardGenerator.Random;

      var game = _creator.Execute();

      Assert.Equal(width, game.Width);
      Assert.Equal(height, game.Height);
    }
  }
}
