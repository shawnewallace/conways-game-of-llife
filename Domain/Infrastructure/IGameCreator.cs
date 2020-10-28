using Cgol.Core;

namespace Cgol.Domain.Infrastructure
{
	public interface IGameCreator : IExecute<IGame>
	{
		int Width { get; set; }
		int Height { get; set; }
		double FillFactor { get; set; }
	}
}
