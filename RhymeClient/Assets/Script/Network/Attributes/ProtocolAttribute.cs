using System;

namespace Rhyme.Common.Attributes
{
	public class ProtocolAttribute : Attribute
	{
		private int _protocolNumber;

		public ProtocolAttribute(int protocolNumber)
		{
			_protocolNumber = protocolNumber;
		}
	}
}
