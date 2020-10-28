namespace Cgol.Domain.Infrastructure
{
	public interface IGame
	{
		int Height { get; }
		int Width { get; }
		ICell[,] Board { get; }
		bool IsAliveAt(int x, int y);
		void Tick();
	}
}
