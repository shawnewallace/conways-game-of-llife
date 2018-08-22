using conways_game_of_life.lib;
using Xunit;

namespace conways_game_of_life.tests
{
  public class LivingNeighborCalculatorTests : cgol_test
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
      var calc = new LivingNeighborCalculator();
      CreateBoard(3, 3);
      SetNumberOfNeighborsBeforeTick(numNeighbors);
      var result = calc.Calc(_board, 1, 1);
      Assert.Equal(numNeighbors, result);
    }
  }
}
