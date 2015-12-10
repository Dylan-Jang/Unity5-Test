namespace SocketFramework.Network.PipesAndFilter
{
	public interface IFilterOperation<T>
	{
		T Execute(T input);
	}
}