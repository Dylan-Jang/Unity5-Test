using System;

namespace Rhyme.Common.Attributes
{
	public enum ExposeBranchType
	{
		Nsus,
		TwoAce,
	}

	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Field)]
	public class ExposeBranchAttribute : Attribute
	{
		private ExposeBranchType _exposeBranchType;

		public ExposeBranchAttribute()
		{
			_exposeBranchType = ExposeBranchType.Nsus;
		}

		public ExposeBranchAttribute(ExposeBranchType exposeBranchType)
		{
			_exposeBranchType = exposeBranchType;
		}
	}
}
