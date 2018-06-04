using System;
using conways_game_of_life.lib;
using Xunit;

namespace conways_game_of_life.tests
{
  public class ToroidalLivingNeighborCalculatorTests : cgol_test
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
    public void other_tests_still_pass(int numNeighbors)
    {
      var calc = new LivingNeighborCalculator_Toroidal();
      CreateBoard(3, 3);
      SetNumberOfNeighborsBeforeTick(numNeighbors);
      var result = calc.Calc(_board, 1, 1);
      Assert.Equal(numNeighbors, result);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    public void the_left_side_is_a_neighbor_to_right_side(int numNeighbors)
    {
      var calc = new LivingNeighborCalculator_Toroidal();
      CreateBoard(3, 3);

      for (var i = 0; i < numNeighbors; i++)
      {
        _board[0, i].Alive = true;
      }

      var result = calc.Calc(_board, 2, 1);
      Assert.Equal(numNeighbors, result);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    public void the_right_side_is_a_neighbor_to_left_side(int numNeighbors)
    {
      var calc = new LivingNeighborCalculator_Toroidal();
      CreateBoard(3, 3);

      for (var i = 0; i < numNeighbors; i++)
      {
        _board[2, i].Alive = true;
      }

      var result = calc.Calc(_board, 0, 1);
      Assert.Equal(numNeighbors, result);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    public void the_top_is_a_neighbor_to_bottom(int numNeighbors)
    {
      var calc = new LivingNeighborCalculator_Toroidal();
      CreateBoard(3, 3);

      for (var i = 0; i < numNeighbors; i++)
      {
        _board[i, 2].Alive = true;
      }

      var result = calc.Calc(_board, 1, 0);
      Assert.Equal(numNeighbors, result);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    public void the_bottom_is_a_neighbor_to_top(int numNeighbors)
    {
      var calc = new LivingNeighborCalculator_Toroidal();
      CreateBoard(3, 3);

      for (var i = 0; i < numNeighbors; i++)
      {
        _board[i, 0].Alive = true;
      }

      var result = calc.Calc(_board, 1, 2);
      Assert.Equal(numNeighbors, result);
    }

    [Fact]
    public void the_corners_are_neighbors()
    {
      var calc = new LivingNeighborCalculator_Toroidal();
      CreateBoard(3, 3);

      _board[0, 0].Alive = true;
      _board[0, 2].Alive = true;
      _board[2, 0].Alive = true;

      var result = calc.Calc(_board, 2, 2);
      Assert.Equal(3, result);
    }
  }
}
