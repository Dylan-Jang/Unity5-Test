using ProtoBuf;

using Rb.Services.Protocol;

namespace Rhyme.Common.ProtocolTypes
{
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class PortalIntegrationResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTourneyRegistrationInfoResponse : PortalIntegrationResponse
	{
		public string UserName;
		public string BuyInType;
	}
}
