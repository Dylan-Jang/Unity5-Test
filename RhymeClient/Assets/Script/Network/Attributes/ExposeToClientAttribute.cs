using System;

namespace Rhyme.Common.Attributes
{
	public enum ExposeToClientType
	{
		None,
		Session,
		Table,
	}

	[AttributeUsage(AttributeTargets.Method)]
	public class ExposeToClientAttribute : Attribute
	{
		private ExposeToClientType _exposeToClientType;
		private bool _isCallback;
		private string _requestPrefix;
		private string _responsePrefix;

		public ExposeToClientAttribute(ExposeToClientType exposeToClientType, bool isCallback = false, string requestPrefix = "C", string responsePrefix = "C")
		{
			_exposeToClientType = exposeToClientType;
			_isCallback = isCallback;
			_requestPrefix = requestPrefix;
			_responsePrefix = responsePrefix;
		}
	}
}
