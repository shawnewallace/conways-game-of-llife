using Cgol.Core;

namespace Cgol.Domain.Infrastructure
{
	public interface IGameFactory : IExecute<IGame>
	{
		int Width { get; set; }
		int Height { get; set; }
		double FillFactor { get; set; }
	}
}
