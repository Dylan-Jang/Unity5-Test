using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;

using ProtoBuf;

namespace Rhyme.Common
{
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class ServiceProviderInformation : ICloneable
	{
		[XmlAttribute("Name")]
		public string Name;
		[XmlAttribute("Guid")]
		public Guid Guid;
		[XmlAttribute("Country")]
		public string Country;
		[XmlAttribute("Currency")]
		public string Currency;
		[XmlAttribute("FlexibleNationality")]
		public bool FlexibleNationality;
		[XmlAttribute("CountryCode")]
		public string CountryCode;
		[XmlAttribute("AllowEnterTableOnSameAddress")]
		public bool AllowEnterTableOnSameAddress;
		[XmlAttribute("PlatformName")]
		public string PlatformName;
		[XmlAttribute("AllowBuddy")]
		public bool AllowBuddy;

		public List<string> BlockCountryCode = new List<string>();
		public List<string> IPWhiteList = new List<string>();

		public string PlatformEndPoint;
		public string PlatformCurrency;
		public bool UseUserNameAuth;

		public object Clone()
		{
			var exportedSPInfo = MemberwiseClone() as ServiceProviderInformation;
			Debug.Assert(exportedSPInfo != null);

			exportedSPInfo.Guid = Guid.Empty;

			return exportedSPInfo;
		}
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class PlatformInformation
	{
		[XmlAttribute("Name")]
		public string Name;
		[XmlAttribute("EndPoint")]
		public string EndPoint;
		[XmlAttribute("Currency")]
		public string Currency;
		[XmlAttribute("UseUserNameAuth")]
		public bool UseUserNameAuth;
		[XmlAttribute("AuthorizationKey")]
		public string AuthorizationKey;
	}
}
