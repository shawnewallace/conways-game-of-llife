using conways_game_of_life.core;
using conways_game_of_life.lib;
using Xunit;

namespace conways_game_of_life.tests
{
  public class GameCreatorTest : cgol_test
  {
    private ICGolGameCreator _creator;
    private const int x = 3;
    private const int y = 4;

    public GameCreatorTest() {
      _creator= new GameCreator(new Game(new TestTicker()));
      
      _creator.Width = x;
      _creator.Height = y;
      _creator.FillFactor = 0;
      _creator.Generator = BoardGenerator.Random;
    }

    [Fact]
    public void game_has_width_x()
    {
      var result = _creator.Execute();

      Assert.Equal(x, _creator.Width);
    }

    [Fact]
    public void game_has_height_y()
    {
      var result = _creator.Execute();

      Assert.Equal(y, _creator.Height);
    }

    [Fact]
    public void all_cells_are_initially_dead_because_of_fill_factor_0() {
      var result = _creator.Execute();

      for(var i = 0; i < x; i++)
        for(var j = 0; j < y; j++)
          Assert.False(result.IsAliveAt(i, j));
    }

    [Fact]
    public void all_cells_are_initially_alive_because_of_fill_factor_1() {
      _creator.FillFactor = 1;
      var result = _creator.Execute();

      for(var i = 0; i < x; i++)
        for(var j = 0; j < y; j++)
          Assert.True(result.IsAliveAt(i, j));
    }
  }
}
