using System;
using System.Collections.Generic;

using ProtoBuf;

using Rb.Services.Protocol.GameTable;

using Rhyme.Common;
using Rhyme.Common.Attributes;

namespace Rb.Services.Protocol
{
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class LobbyPlayer : ICloneable
	{
		public Guid UserId;
		public string NickName;
		public int Rank;
		public Guid ServiceProviderId;
		public string CountryCode;
		public string IPAddress;
		public string HardwareSerialNumber;
		public string MacAddress;
		public DeviceType UserDeviceType;
		public OSType UserOsType;
		public int AvatarId;
		// define in ServiceConfigration.cs
		// Domestic sp { "GG","GGREGULAR","GGNETPRO","HAHA","ONGATE" } is true
		public bool IsDomestic;

		/// <summary>
		/// Hash에 Guid.Empty가 들어있는 경우 해당 블라인드의 테이블엔 참여하지 않고 블라인드를 클릭만 한 상태를 의미
		/// </summary>
		public HashSet<Guid/*tableid*/> ParticipationTableList = new HashSet<Guid>();
		public string AvatarType;
		public string ImageUrl;

		public object Clone()
		{
			var cloned = new LobbyPlayer()
			{
				UserId = UserId,
				NickName = NickName,
				Rank = Rank,
				ServiceProviderId = ServiceProviderId,
				CountryCode = CountryCode,
				IPAddress = IPAddress,
				HardwareSerialNumber = HardwareSerialNumber,
				AvatarId = AvatarId,
				IsDomestic = IsDomestic,
				ParticipationTableList = new HashSet<Guid>(ParticipationTableList),
				AvatarType = AvatarType,
				ImageUrl = ImageUrl,
				MacAddress = MacAddress,
				UserDeviceType = UserDeviceType,
				UserOsType = UserOsType
			};

			return cloned;
		}
	}

	/// <summary>
	/// Request to EnterLobby
	/// </summary>
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class EnterLobbyRequest
	{
		/// <summary>
		/// Gets or sets the user's id.
		/// </summary>
		/// <value>
		/// The user's id.
		/// </value>
		public Guid UserId;

		/// <summary>
		/// Gets or sets the player attempts to enter the lobby. Set by server.
		/// </summary>
		/// <value>
		/// The lobbyPlayer.
		/// </value>
		[SetByServer]
		public LobbyPlayer Player;
	}

	/// <summary>
	/// Response to EnterLobby
	/// </summary>
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class EnterLobbyResponse : Response
	{
		/// <summary>
		/// Gets or sets the service provider's information.
		/// </summary>
		/// <value>
		/// Current service provider's information
		/// </value>
		public ServiceProviderInformation ServiceProviderInformation;


		/// <summary>
		/// 몇번 서비스에 접속 했는지 확인 하기 위한 디버그 용도
		/// </summary>
		public uint ServiceId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class LeaveLobbyRequest
	{
		public Guid UserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class EnterGameLobbyRequest
	{
		public Guid UserId;
		public uint TableTypeId;
		//set by session service (server only)
		public Guid TableId = Guid.Empty;
		//set by session service (server only)
		public LobbyPlayer Player;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class EnterGameLobbyResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class LeaveGameLobbyRequest
	{
		public Guid UserId;
		public Guid TableId = Guid.Empty;
		public uint TableTypeId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetLobbyPlayersRequest
	{
		[SetByServer]
		public Guid ServiceProviderId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetLobbyPlayersResponse : Response
	{
		public List<LobbyPlayer> LobbyPlayers = new List<LobbyPlayer>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetGameLobbyPlayersRequest
	{
		public uint TableTypeId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetGameLobbyPlayersResponse : Response
	{
		public List<LobbyPlayer> GameLobbyPlayers = new List<LobbyPlayer>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetGameLobbyPlayerCountsResponse : Response
	{
		public Dictionary<uint/*tabletypeid*/, int/*playercount*/> GameLobbyPlayerCounts = new Dictionary<uint, int>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyEnterLobbyParameter
	{
		public Guid UserId;
		public List<LobbyPlayer> Players = new List<LobbyPlayer>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyLeaveLobbyParameter
	{
		public Guid UserId;
		public LobbyPlayer Player;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyEnterGameLobbyParameter
	{
		public Guid UserId;
		public uint TableTypeId;
		public int CurrentGameLobbyPlayerCount;
		public List<LobbyPlayer> Players = new List<LobbyPlayer>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyLeaveGameLobbyParameter
	{
		public uint TableTypeId;
		public int CurrentGameLobbyPlayerCount;
		public LobbyPlayer Player;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class WhisperEntity
	{
		public Guid Id;
		public string NickName;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SendWhisperRequest
	{
		public WhisperEntity Sender;
		public Guid Receiver;
		public string Text;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SendWhisperResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyWhisperReceivedParameter
	{
		[SetByServer]
		public Guid UserId;
		[SetByServer]
		public WhisperEntity Sender;
		[SetByServer]
		public string Text;

		public NotifyWhisperReceivedParameter()
		{
			
		}

		public NotifyWhisperReceivedParameter(SendWhisperRequest request)
		{
			UserId = request.Receiver;
			Sender = request.Sender;
			Text = request.Text;
		}
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class RequestAddBuddyRequest
	{
		public uint BuddyPlayerId;

		[SetByServer]
		public Guid RequestUserId;
		[SetByServer]
		public string RequestNickName;
		[SetByServer]
		public Guid BuddyId;
		[SetByServer]
		public string BuddyNickName;
		[SetByServer]
		public string RequestMessage;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class RequestAddBuddyResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class RequestAddBuddyDeclineRequest
	{
		public Guid RequestUserId;
		public Guid DeclineUserId;
		public string DeclineNickName;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyRequestAddBuddyParameter
	{
		public Guid RequestUserId;
		public string RequestNickName;
		public string ReceiverNickName;

		[SetByServer]
		public Guid ReceiverUserId;

		public NotifyRequestAddBuddyParameter()
		{
		}

		public NotifyRequestAddBuddyParameter(RequestAddBuddyRequest request)
		{
			RequestUserId = request.RequestUserId;
			RequestNickName = request.RequestNickName;
			ReceiverUserId = request.BuddyId;
			ReceiverNickName = request.BuddyNickName;
		}
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyRequestAddBuddyDeclineParameter
	{
		public Guid RequestUserId;
		public Guid DeclineUserId;
		public string DeclineNickName;

		public NotifyRequestAddBuddyDeclineParameter()
		{
			
		}

		public NotifyRequestAddBuddyDeclineParameter(RequestAddBuddyDeclineRequest request)
		{
			RequestUserId = request.RequestUserId;
			DeclineUserId = request.DeclineUserId;
			DeclineNickName = request.DeclineNickName;
		}
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyJackpotAnnounceParameter
	{
		public TableName TableName;
		public long SmallBlind;
		public long BigBlind;
		public long JackpotHandId;
		public long JackpotAmount;
		public GameType GameType;
		public List<JackpotRecipientInfo> JackpotRecipientInfos = new List<JackpotRecipientInfo>();
		public List<JackpotTicketRecipientInfo> JackpotTicketRecipients = new List<JackpotTicketRecipientInfo>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CheckOnlineFromVaultRequest
	{
		public Guid UserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CheckOnlineFromVaultResponse : Response
	{
		public bool IsOnline;
	}
}