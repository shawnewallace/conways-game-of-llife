namespace conways_game_of_life.core
{
	public interface ITicker
  {
		ICell[,] Tick(ICell[,] board);
  }
}