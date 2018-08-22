namespace conways_game_of_life.core
{
  public interface ILivingNeighborCalculator
  {
    int Calc(ICell[,] board, int x, int y);
  }
}