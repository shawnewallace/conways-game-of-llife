namespace Cgol.Domain.Infrastructure
{
	public interface IGame
	{
		double FillFactor { get; private set; }
		int Height { get; }
		int Width { get; }
		ICell[,] Board { get; set; }
		bool IsAliveAt(int x, int y);
		void Tick();
	}
}
