using System;

namespace SocketFramework.Utils
{
	public abstract class SingletonBase<T> where T : class
	{
		private static readonly T _instance = CreateInstanceOfT();
		public static T Instance { get { return _instance; } }

		private static T CreateInstanceOfT()
		{
			return Activator.CreateInstance(typeof(T), true) as T;
		}
	}
}
