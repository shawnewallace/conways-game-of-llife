using Cgol.Core;

namespace Cgol.Domain.Infrastructure
{
	public interface INeighborCalculator
	{
		int Calc(ICell[,] board, int x, int y);
	}
}
