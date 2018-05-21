namespace conways_game_of_life.lib
{
  public interface ILivingNeighborCalculator
  {
    int Calc(Cell[,] board, int x, int y);
  }
}