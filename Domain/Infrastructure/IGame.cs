namespace Cgol.Domain.Infrastructure
{
	public interface IGame
	{
		int Height { get; }
		int Width { get; }
		ICell[,] Board { get; }
		ITicker Ticker { get; }
		bool IsAliveAt(int x, int y);
		void Tick();
	}
}
