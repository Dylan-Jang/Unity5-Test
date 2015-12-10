using System;
using System.Collections.Generic;

using ProtoBuf;

using Rhyme.Common;

namespace Rb.Services.Protocol
{
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetUserRakeStatRequest
	{
		public DateTime StartTime;
		public DateTime EndTime;
		public TimeSpan StatInterval;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetUserRakeStatResponse : Response
	{
		public List<UserRakeStat> UserRakeStats = new List<UserRakeStat>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UserRakeStat
	{
		public DateTime StartTime;
		public DateTime EndTime;
		public string UserName;
		public long HandCount;
		public long RakedHandCount;
		public long RakeAmount;
		public int RakebackPercent;
		public long RakebackAmount;
		public long EarnedAmount;
		public string Currency;
		public long TourneyFee;
		public long SitAndGoFee;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetHandHistoryByIdRequest
	{
		public long HandHistoryId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetHandHistoryByIdResponse : Response
	{
		public HandHistory.HandHistory HandHistory;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetRawHandHistoryByIdRangeRequest
	{
		// returns all X, where StartHandHistoryId <= X <= EndHandHistoryId 

		public long StartHandHistoryId;
		public long EndHandHistoryId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetRawHandHistoryByIdRangeResponse : Response
	{
		// List returned will be in order of HandHistoryId 
		public List<RawHandHistory> RawHandHistories = new List<RawHandHistory>();

		// When ReturnedLast=true,
		// - Most recent hand history was returned in this response
		// - Platform does not need to call GetHandHistory again right away
		// ex) StartHandHistoryId=1, EndHandHistoryId=1000
		//     But only most recent HandHistoryId=500
		//
		// When ReturnedLast=false, there MAY BE more hand histories
		// - This response returned all hand histories as requested
		public bool ReturnedLast;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class RawHandHistory
	{
		public byte[] HandHistoryBinary = new List<byte>().ToArray();
		public DateTime Created;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetHandHistoryByIdRangeRequest
	{
		// returns all X, where StartHandHistoryId <= X <= EndHandHistoryId 

		public long StartHandHistoryId;
		public long EndHandHistoryId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetHandHistoryByIdRangeResponse : Response
	{
		// List returned will be in order of HandHistoryId 
		public List<HandHistory.HandHistory> HandHistories = new List<HandHistory.HandHistory>();

		// When ReturnedLast=true,
		// - Most recent hand history was returned in this response
		// - Platform does not need to call GetHandHistory again right away
		// ex) StartHandHistoryId=1, EndHandHistoryId=1000
		//     But only most recent HandHistoryId=500
		//
		// When ReturnedLast=false, there MAY BE more hand histories
		// - This response returned all hand histories as requested
		public bool ReturnedLast;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetHandHistoryRequest
	{
		public string UserName;
		public List<TableInformationType> PlayTypes = new List<TableInformationType>();
		public List<GameType> GameTypes = new List<GameType>();
		public long BigBlindMin;
		public long BigBlindMax;
		public long TotalPotMin;
		public long TotalPotMax;
		public DateTime Date;
		public uint PageSize;
		public uint PageNumber;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetHandHistoryResponse : Response
	{
		public List<HandHistory.HandHistory> HandHistories = new List<HandHistory.HandHistory>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class ChangeScreenNameRequest
	{
		// UserName
		public string AccountName;

		// NickName
		public string ScreenName;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class ChangeScreenNameResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UserBalance
	{
		public string UserName;
		public long Balance;
	}

	#region ForVault
	public class BackOfficeKickOutPlayerResponse
	{
		public uint ResultCode;
	}

	public class CheckOnlineRequest
	{
		public string UserName;
	}

	public class CheckOnlineResponse
	{
		public uint ResultCode;
		public bool IsOnline;
	}

	public class InPlayerChipsResponse
	{
		public uint ResultCode;
		public string UserName;
		public long Balance;
	}

	public class PlatformResponse
	{
		public uint ResultCode;
	}

	public class PlayerTicketListResponse
	{
		public uint ResultCode;
		public int CurrentPage;
		public int TotalItems;
		public int TotalPages;
		public List<PlayerTicketInfo> TicketInfos = new List<PlayerTicketInfo>();
	}

	public class PlayerTicketInfo
	{
		public Guid TicketId;
		public int TicketTemplateId;
		public string TicketName;
		public double ExpirationDate;
		public long Value;
		public bool Refundable;
		public bool Used;
	}
	#endregion

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class ServerCheckRequest
	{
		public string Command;
		public string Option = "";
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class ServerCheckResponse : Response
	{
		public string Output;
	}
}