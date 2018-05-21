using System;

public class CGolBoardTicker
{
  public Cell[,] Execute(Cell[,] oldState)
  {
    var xMax = oldState.GetLength(0);
    var yMax = oldState.GetLength(1);

    var result = new Cell[xMax, yMax];

    for (var i = 0; i < xMax; i++)
    {
      for (var j = 0; j < yMax; j++)
      {
        result[i, j] = IsAliveAfterTick(oldState, i, j);
      }
    }

    return result;
  }

  private Cell IsAliveAfterTick(Cell[,] board, int x, int y)
  {
    var isAliveNow = board[x, y].Alive;
    //var numLivingNeighbors = LivingNeighbors(board, x, y);
    var numLivingNeighbors = LivingNeighborsToroidal(board, x, y);

    // Any live cell with fewer than two live neighbours dies, as if caused by under-population.
    if (isAliveNow && numLivingNeighbors < 2) return new Cell() { Alive = false };
    // Any live cell with two or three live neighbours lives on to the next generation.
    if (isAliveNow && numLivingNeighbors == 2) return new Cell() { Alive = true };
    if (isAliveNow && numLivingNeighbors == 3) return new Cell() { Alive = true };
    // Any live cell with more than three live neighbours dies, as if by overcrowding.
    if (isAliveNow && numLivingNeighbors > 3) return new Cell() { Alive = false };
    // Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
    if (!isAliveNow && numLivingNeighbors == 3) return new Cell() { Alive = true };

    return new Cell() { Alive = false };
  }

  private int LivingNeighborsToroidal(Cell[,] board, int x, int y)
  {
    var xLength = board.GetLength(0);
    var yLength = board.GetLength(1);
    var numNeighbors = 0;


    for (var i = x - 1; i <= x + 1; i++)
    {
      for (var j = y - 1; j <= y + 1; j++)
      {
        if (i == x && j == y) continue;
        var xNext = GetNext(i, xLength);
        var yNext = GetNext(j, yLength);

        if (board[xNext, yNext].Alive) numNeighbors++;
      }
    }

    return numNeighbors;
  }

  private int LivingNeighbors(Cell[,] board, int x, int y)
  {
    var xMin = x - 1;
    var xMax = x + 1;
    var yMin = y - 1;
    var yMax = y + 1;

    if (xMin < board.GetLowerBound(0)) xMin = board.GetLowerBound(0);
    if (xMax > board.GetUpperBound(0)) xMax = board.GetUpperBound(0);
    if (yMin < board.GetLowerBound(1)) yMin = board.GetLowerBound(1);
    if (yMax > board.GetUpperBound(1)) yMax = board.GetUpperBound(1);


    var numNeighbors = 0;

    for (var i = xMin; i <= xMax; i++)
    {
      for (var j = yMin; j <= yMax; j++)
      {
        if (i == x && j == y) continue;

        if (board[i, j].Alive) numNeighbors++;
      }
    }

    return numNeighbors;
  }

  private static int GetNext(int index, int max)
  {
    if (index < 0) return max - 1;

    return index % max;
  }
}