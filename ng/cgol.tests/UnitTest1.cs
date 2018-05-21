using System;
using Xunit;

namespace cgol.tests
{
  public class UnitTest1 : IDisposable
  {
    private Cell[,] _board;
    private CGolBoardTicker _ticker;

    public UnitTest1()
    {
      _ticker = new CGolBoardTicker();
      _board = CreateBoard(3, 3);
    }

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
      _board[1, 1].Alive = livingBeforeTick;
      SetNeighbors(numNeighborsBeforeTick);

      var newBoard = _ticker.Execute(_board);
      Assert.Equal(livingAfterTick, newBoard[1, 1].Alive);
    }

    private void SetNeighbors(int numNeighborsBeforeTick)
    {
      if (numNeighborsBeforeTick == 0) return;
      if (numNeighborsBeforeTick >= 1) _board[0, 0].Alive = true;
      if (numNeighborsBeforeTick >= 2) _board[1, 0].Alive = true;
      if (numNeighborsBeforeTick >= 3) _board[2, 0].Alive = true;
      if (numNeighborsBeforeTick >= 4) _board[0, 1].Alive = true;
      if (numNeighborsBeforeTick >= 5) _board[2, 1].Alive = true;
      if (numNeighborsBeforeTick >= 6) _board[0, 2].Alive = true;
      if (numNeighborsBeforeTick >= 7) _board[1, 2].Alive = true;
      if (numNeighborsBeforeTick == 8) _board[2, 2].Alive = true;
    }

    protected Cell[,] CreateBoard(int width, int height)
    {
      var result = new Cell[width, height];

      for (var i = 0; i < width; i++)
        for (var j = 0; j < height; j++)
          result[i, j] = new Cell() { Alive = false };

      return result;
    }

    public void Dispose()
    {
      _board = null;
      _ticker = null;
    }
  }
}
