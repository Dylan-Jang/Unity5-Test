using System;
using System.Collections.Generic;
using System.Linq;

namespace SocketFramework.Network.PipesAndFilter
{
	public class Pipeline<TFilter>
	{
		private readonly List<IFilterOperation<TFilter>> _filterOperations = new List<IFilterOperation<TFilter>>();
		protected event Action<TFilter> PipeLineExecuteCompleted = null;

		public Pipeline<TFilter> Register(IFilterOperation<TFilter> filterOperation)
		{
			_filterOperations.Add(filterOperation);
			return this;
		}

		public virtual TFilter Execute(TFilter inputSource)
		{
			var result = inputSource;
			result = _filterOperations.Aggregate(result, (current, operation) => operation.Execute(current));

			if (PipeLineExecuteCompleted != null)
				PipeLineExecuteCompleted(result);

			return result;
		}
	}
}
