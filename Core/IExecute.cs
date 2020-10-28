namespace Cgol.Core
{
	public interface IExecute
	{
		void Execute();
	}

	public interface IExecute<T>
	{
		T Execute();
	}
}