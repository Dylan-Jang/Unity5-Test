using System;
using System.Collections.Generic;

using Assets.Script.Extension;

using ProtoBuf;

using Rb.Services.Protocol.Config;
using Rb.Services.Protocol.GameTable;
using Rb.Services.Protocol.HandHistory;

using Rhyme.Common;
using Rhyme.Common.Attributes;

namespace Rb.Services.Protocol.Account
{
	/*
	 * THIS IS SERIALIZED AND STORED IN DB:
	 * DO NOT CHANGE ANY VARIABLE NAMES OR ITS ORDER 
	 * 
	 * 20130826:
	 * Since hand history data saved in game DB is virtually useless (it does not stored any game turns),
	 * added CountryCode to Account data contract
	 */
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class Account
	{
		public Guid UserId;
		public Guid ServiceProviderId { get; set; }		// NOTE : MUST PROPERTY. Use by Rhyme.LoggingService.dll
		public string NickName;
		public bool IsNickNameExists;
		public string Username;
		public string GpId;
		public bool IsSuperUser;
		public int AvatarId;
		public string CountryCode;

		[ExposeBranch(ExposeBranchType.TwoAce)]
		public int PlayerLevel;
		[ExposeBranch(ExposeBranchType.TwoAce)]
		public long PlayerExp;
		[ExposeBranch(ExposeBranchType.TwoAce)]
		public bool Privilege;

		//public string LiveChatUrl;
		public bool IsAccountLocked;
		public bool IsImageLocked;
		public string AvatarType;
		public string ImageUrl;

		public override string ToString()
		{
			return string.Format("{0}:{1}:{2}", UserId, NickName, Username);
		}
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class AccountInfo
	{
		public Account Account;
		public UserRankInfo UserRankInfo;
		public RankInformation CurrentRankInformation;
		public UserOptionFlag UserOptionFlag;
		public long GGPoint;
		public long TourneyMoney;
		public string GGPGainRatio;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CreateAccountRequest
	{
		public string UserName;
		public string LoginName;
		public Guid ServiceProviderId;
		public string NickName;
		public string CountryCode;
		public decimal? GGPGainRatio;
		public string GpId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CreateAccountResponse : Response
	{
		public Guid? UserId;
	}

	/// <summary>
	/// Request to Login
	/// </summary>
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class LoginRequest
	{
		/// <summary>
		/// Gets or sets the name of the service provider.
		/// </summary>
		/// <value>
		/// The name of the service provider.
		/// </value>
		public string ServiceProviderName;

		/// <summary>
		/// Gets or sets the token.
		/// </summary>
		/// <value>
		/// Used for login token
		/// </value>
		public string Token;

		/// <summary>
		/// Gets or sets the protocol version.
		/// </summary>
		/// <value>
		/// The player's protocol version.
		/// </value>
		public string ProtocolVersion;

		/// <summary>
		/// Gets or sets the hardware serial number.
		/// </summary>
		/// <value>
		/// The player's hardware serial number.
		/// </value>
		public string HardwareSerialNumber;

		/// <summary>
		/// Gets or sets the mac address.
		/// </summary>
		/// <value>
		/// The player's mac address.
		/// </value>
		public string MacAddress;

		/// <summary>
		/// Gets or sets the hardware type.
		/// </summary>
		/// <value>
		/// The player's hardware type.
		/// </value>
		public DeviceType UserDeviceType;


		/// <summary>
		/// Gets or sets the os type.
		/// </summary>
		/// <value>
		/// The player's os type.
		/// </value>
		public OSType UserOsType;

		public string BrandId;

		/// <summary>
		/// Gets or sets the username. Set by server(ClientProxy)
		/// </summary>
		/// <value>
		/// The username.
		/// </value>
		[SetByServer]
		public string Username;

		/// <summary>
		/// Gets or sets the nickname. (ClientProxy)
		/// </summary>
		/// <value>
		/// The player's nickname.
		/// </value>
		[SetByServer]
		public string Nickname;

		/// <summary>
		/// Avatars is owned by the player. Set by server(ClientProxy)
		/// </summary>
		[SetByServer]
		public string[] Avatars = new List<string>().ToArray();

		/// <summary>
		/// Gets or sets a value indicating whether this instance is super user can talk who do not have access permissions. Set by server(ClientProxy).
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance is super user; 
		/// <c>false</c> otherwise; 
		/// </value>
		[SetByServer]
		public bool IsSuperUser;

		/// <summary>
		/// Gets or sets the country code.
		/// </summary>
		/// <value>
		/// The country code.
		/// </value>
		[SetByServer]
		public string CountryCode;

		/// <summary>
		/// Gets or sets a value indicating whether this instance is, if there is no information from the platform serviceProviderinformation brings value of default.
		/// </summary>
		/// <value>
		/// the ggp gain ratio
		/// </value>
		[SetByServer]
		public string GGPGainRatio;

		public string GpId;

		[SetByServer]
		public string ImageUrl;

		[SetByServer]
		public string AvatarType;

		[SetByServer]
		public int AvatarId;

		[SetByServer]
		public string ClientAddress;

		[SetByServer] 
		public string LoginName;

		[SetByServer]
		public Guid GuestId;
	}

	/// <summary>
	/// Response to Login
	/// </summary>
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class LoginResponse : Response
	{
		/// <summary>
		/// Gets or sets the account information.
		/// </summary>
		/// <value>
		/// The account information.
		/// </value>
		public AccountInfo AccountInfo;

		/// <summary>
		/// The avatars is owned by the player.
		/// </summary>
		public string[] Avatars = new List<string>().ToArray();

		/// <summary>
		/// Current Server UTC Time
		/// </summary>
		public DateTime CurrentServerTime;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class LogoutRequest
	{
		public Guid UserId;
		public string ServiceProviderId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class LogoutResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetLogoInfoRequest
	{
		public string LabelId { get; set; }
		public string ServiceProviderName { get; set; }
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetLogoInfoResponse : Response
	{
		public string LogoUrl { get; set; }
		public string IconUrl { get; set; }
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetAccountRequest
	{
		public Guid UserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetAccountResponse : Response
	{
		public AccountInfo AccountInfo;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetAccountByUserNameRequest
	{
		public string UserName;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetAccountByUserNameResponse : Response
	{
		public AccountInfo AccountInfo;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetAccountByGpIdRequest
	{
		public string GpId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetAccountByGpIdResponse : Response
	{
		public AccountInfo AccountInfo;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetBalanceRequest
	{
		public Guid UserId;
		public string UserName;

		// set by account service
		[SetByServer]
		public Guid ServiceProviderId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetBalanceResponse : Response
	{
		public long Balance;
		public UserRankInfo RankInfo;
		public long GGPoint;
		public long TourneyBalance;

		// for Mobile and Web
		public string Currency { get; set; }
		public double CurrencyAmount { get; set; }
		public double ExchangeRate { get; set; }
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SetAccountRakebackPercentRequest
	{
		public Guid UserId;
		public int RakebackPercent;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SetAccountRakebackPercentResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class PrepareBuyInRequest
	{
		public Guid UserId;
		public string UserName;
		public Guid TableId;
		public long RequestId;
		public long TablePlayerId;
		public long Amount;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class PrepareDebitGGPRequest
	{
		public Guid UserId;
		public string UserName;
		public Guid TournamentId;
		public long RequestId;
		public long GGPAmount;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetJackpotHandHistoryRequest
	{
		[SetByServer]
		public Guid UserId;

		public long JackpotHandId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetJackpotHandHistoryResponse : Response
	{
		public HandHistoryInformation HandHistory;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetAvailableAvatarListRequest
	{
		public Guid UserId;

		// 사용가능한 스페셜 아바타의 아이디만 받을지 여부
		// 추가 옵션을 주고싶은 경우 enum으로 변경을 추천합니다
		public bool GetOnlyAvailableSpecialAvatarId;

		// set by session service
		[SetByServer]
		public Guid ServiceProviderId;

		// set by session service
		[SetByServer]
		public string GpId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetAvailableAvatarListResponse : Response
	{
		public List<AvatarInfo> Avatars = new List<AvatarInfo>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetDefaultAvatarListResponse : Response
	{
		public List<AvatarInfo> Avatars = new List<AvatarInfo>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetSpecialAvatarListResponse : Response
	{
		public List<AvatarInfo> Avatars = new List<AvatarInfo>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class AvatarInfo
	{
		public int AvatarId;
		public string Name;
		public string Url;
		public AvatarType Type;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class PrepareBuyInResponse : Response
	{
		public long TransactionId;

		// In case is of already completed buyin, return platform result
		public string PlatformResult;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class PrepareDebitGGPResponse : Response
	{
		public long TransactionId;
		public string PlatformResult;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CompleteBuyInRequest
	{
		public long TransactionId;
		public string PlatformResult;
		public long UserSessionId;
		public long RequestId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CompleteDebitGGPRequest
	{
		public long TransactionId;
		public string PlatformResult;
		public long RequestId;
	}


	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CompleteBuyInResponse : Response
	{
		public string PreviousPlatformResult;
		public DateTime? PreviousPlatformResultDate;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CompleteDebitGGPResponse : Response
	{
		public string PreviousPlatformResult;
		public DateTime? PreviousPlatformResultDate;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class RequestNotifyRecentHandHistoriesRequest
	{
		public List<HandHistoryInformation> Histories = new List<HandHistoryInformation>();
		public Guid UserId;
		public Guid TableId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class RecentHandHistoryResponse : Response
	{
		public List<HandHistory.HandHistory> HandHistories = new List<HandHistory.HandHistory>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class PrepareCashOutRequest
	{
		public Guid UserId;
		public string UserName;
		public Guid TableId;
		public long RequestId;
		public long UserSessionId;
		public long Amount;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class PrepareCreditGGPRequest
	{
		public Guid UserId;
		public string UserName;
		public Guid TournamentId;
		public long RequestId;
		public long GGPAmount;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class PrepareDeductionRequest
	{
		public Guid UserId;
		public string UserName;
		public Guid TableId;
		public long RequestId;
		public long UserSessionId;
		public long DeductionAmount;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class PrepareDeductionResponse : Response
	{
		public long TransactionId;

		// In case is of already completed cashout, return platform result
		public string PlatformResult;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class PrepareCashOutResponse : Response
	{
		public long TransactionId;

		// In case is of already completed cashout, return platform result
		public string PlatformResult;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class PrepareCreditGGPResponse : Response
	{
		public long TransactionId;

		// In case is of already completed cashout, return platform result
		public string PlatformResult;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CompleteCashOutRequest
	{
		public long TransactionId;
		public string PlatformResult;
		public long UserSessionId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CompleteCreditGGPRequest
	{
		public long TransactionId;
		public string PlatformResult;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CompleteCashOutResponse : Response
	{
		public string PreviousPlatformResult;
		public DateTime? PreviousPlatformResultDate;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CompleteCreditGGPResponse : Response
	{
		public string PreviousPlatformResult;
		public DateTime? PreviousPlatformResultDate;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CompleteDeductionRequest
	{
		public long TransactionId;
		public string PlatformResult;
		public long UserSessionId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CompleteDeductionResponse : Response
	{
		public string PreviousPlatformResult;
		public DateTime? PreviousPlatformResultDate;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetIncompleteBalanceTransactionsRequest
	{
		public Guid UserId;

		// Only interested in pending balance list before Time
		public DateTime Time;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetIncompleteBalanceTransactionsResponse : Response
	{
		public List<IncompleteBalanceTransaction> IncompleteBalanceTransactions = new List<IncompleteBalanceTransaction>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class IncompleteBalanceTransaction
	{
		public Guid UserId;
		public string UserName;
		public long TransactionId;
		public TransactionType TransactionType;
		public Guid TableId;
		public long TablePlayerId;
		public long RequestId;
		public long Amount;
		public string Currency;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum TransactionType
	{
		BuyIn,
		CashOut,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetOutstandingTableBalancesRequest
	{
		public Guid UserId;

		// Only interested in pending balance list before Time
		public DateTime Time;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetOutstandingTableBalancesResponse : Response
	{
		public List<OutstandingTableBalance> OutstandingTableBalances = new List<OutstandingTableBalance>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class OutstandingTableBalance
	{
		public Guid UserId;
		public string UserName;
		public Guid TableId;
		public long TablePlayerId;
		public long ReservedRequestId;
		public long Amount;
		public string Currency;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyRelevantRankParameter : NotifyTableParameter
	{
		public Guid UserId;
		public NotifyRankInfoType NotifyType;
		public int Rank;
		public long RewardBalance;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetRankInfoRequest
	{
		public Guid UserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetRankInfoResponse : Response
	{
		public List<RankInformation> RankInformations = new List<RankInformation>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetUserOptionRequest
	{
		public Guid UserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetUserOptionResponse : Response
	{
		public UserOptionFlag UserOptionFlag;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UpdateUserOptionRequest
	{
		public Guid UserId;
		public UserOptionFlag UserOptionFlag;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UpdateUserOptionResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SaveWhisperRequest
	{
		public Guid Sender;
		public string SenderUserName;
		public string SenderNickName;
		public Guid Receiver;
		public string ReceiverUserName;
		public string ReceiverNickName;
		public string Message;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SaveWhisperResponse : Response
	{
		public long WhisperId;
		public DateTime SentUtcTime;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SaveTableChatRequest
	{
		public Guid TableId;
		public Guid TourneyId;
		public string TableName;
		public Guid Speaker;
		public string UserName;
		public string NickName;
		public string Message;
		public List<string> ListenerNickNames = new List<string>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SaveTableChatResponse : Response
	{
		public long MessageId;
		public DateTime SentUtcTime;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class StoreTokenRequest
	{
		public Guid TokenId;
		public Guid UserId;
		public Guid TableId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class StoreTokenResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class ConsumeTokenRequest
	{
		public Guid TokenId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class ConsumeTokenResponse : Response
	{
		public Guid UserId;
		public Guid TableId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class AuthorizeWithPlatformTokenRequest
	{
		public Guid ServiceProviderId;
		public string PlatformToken;
		public string CountryCode;
		public string ClientIPAddress;
		public string GpId;
		public string BrandId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class AuthorizeWithPlatformTokenResponse : Response
	{
		public string UserName;
		public string GpId;
		public string NickName;
		public string[] Avatars = new List<string>().ToArray();
		public string CountryCode;
		public bool IsSuperUser;
		public decimal? GGPGainRatio;
		public string AvatarType;
		public string ImageUrl;
		public int AvatarId;
		public string LoginName;

		[ExposeBranch(ExposeBranchType.TwoAce)]
		public bool Privilege;		// NOTE : added.
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CreatePlatformTokenRequest
	{
		public Guid ServiceProviderId;
		public string UserName;
		[SetByServer]
		public string GpId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class Ticket
	{
		public Guid Id;
		public int TicketTemplateId;
		public string Name { get; set; }
		public Guid UserId;
		public long Value;
		public bool Used;
		public DateTime ExpirationTime;
		public int[] TourneyTemplateIdList = new List<int>().ToArray();
		public bool Refundable;

		// Optional,
		public TicketTemplate Template;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TicketTemplate
	{
		public int Id;
		public string Name;
		public long Value;
		public TableInformationType PlayType;
		public DateTime ExpirationTime;
		public int[] TourneyTemplateIdList = new List<int>().ToArray();
		public bool Refundable;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CreateTicketRequest
	{
		public Guid UserId;
		public int TicketTemplateId;
		public Guid TicketGuid;
		public TableInformationType PlayType;

		// set by account service from ticket template cache
		public string Name;
		public long Value;
		public DateTime ExpirationTime;
		public int[] TourneyTemplateIdList = new List<int>().ToArray();
		public bool Refundable;

		// set by account service for mango integration
		public Guid ServiceProviderId;
		public String UserName;

		public TicketIssueReason TicketIssueReason;
	}

	// 티켓 발급 사유
	// 주의 : CRM의 TicketIssueReason enum과 값이 항상 같아야 합니다
	[ProtoContract]
	public enum TicketIssueReason
	{
		[ProtoEnum]
		Unknown,

		/// <summary>
		/// 잭팟 터진 테이블 보상
		/// </summary>
		[ProtoEnum]
		Jackpot,

		/// <summary>
		/// 토너 우승
		/// </summary>
		[ProtoEnum]
		Tourney,

		/// <summary>
		/// 프로모션으로 인한 CRM에서 지급
		/// </summary>
		[ProtoEnum]
		Promotion,

		/// <summary>
		/// 직접 구매
		/// </summary>
		[ProtoEnum]
		Purchase,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic, ImplicitFirstTag = 11)]
	public class CreateTicketResponse : Response
	{
		public Ticket Ticket;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class DeleteTicketRequest
	{
		public Guid UserId;
		public Guid TicketGuid;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class DeleteTicketResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UseTicketRequest
	{
		public Guid UserId;
		public Guid TicketId;

		// set by account service for mango integration
		public Guid ServiceProviderId;
		public String UserName;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UseTicketResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CancelUseTicketRequest
	{
		public Guid UserId;
		public Guid TicketId;

		// set by account service for mango integration
		public Guid ServiceProviderId;
		public String UserName;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CancelUseTicketResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class RefundTicketRequest
	{
		public Guid UserId;
		public Guid TicketId;

		// set by client proxy service for mango integration
		[SetByServer]
		public Guid ServiceProviderId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class RefundTicketResponse : Response
	{
		public long TourneyMoney;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTourneyMoneyRequest
	{
		public Guid UserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTourneyMoneyResponse : Response
	{
		public long TourneyMoney;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class DebitTourneyMoneyRequest
	{
		public Guid UserId;
		public long Amount;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class DebitTourneyMoneyResponse : Response
	{
		public long TourneyMoney;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CreditTourneyMoneyRequest
	{
		public Guid UserId;
		public long Amount;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CreditTourneyMoneyResponse : Response
	{
		public long TourneyMoney;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTourneyCompletedTimeRequest
	{
		public Guid TourneyId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTourneyCompletedTimeResponse : Response
	{
		public DateTime CompletedTime;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTourneyCanceledTimeRequest
	{
		public Guid TourneyId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTourneyCanceledTimeResponse : Response
	{
		public DateTime CanceledTime;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTicketsRequest
	{
		public Guid UserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTicketsResponse : Response
	{
		public Guid UserId;
		public List<Ticket> Tickets = new List<Ticket>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetFilteredTicketsRequest
	{
		public Guid UserId;
		public bool IncludeTicketTemplate;
		public TableInformationType TicketPlayType;
		public long TicketValue;
		//public string Predicate;
		//public List<string> Argument = new List<string>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetFilteredTicketsResponse : Response
	{
		public Guid UserId;
		public List<Ticket> Tickets = new List<Ticket>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CreatePlatformTokenResponse : Response
	{
		public string Token;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTransferFundParameter : NotifyTableParameter
	{
		public Guid RecipientUserId;
		public Guid SenderUserId;
		public string SenderUserName;
		public string SenderNickName;
		public long Amount;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SetNickNameRequest
	{
		public Guid UserId;
		public string NickName;
		public int AvatarId;
		public string AvatarType;
		public byte[] Image = new List<byte>().ToArray();

		[SetByServer]
		public string UserName;
		[SetByServer]
		public string GpId;
		[SetByServer]
		public Guid ServiceProviderId;

		[ProtoBeforeSerialization]
		public void OnBeforeSerialization()
		{
			AvatarType type = (AvatarType)Enum.Parse(typeof(AvatarType), AvatarType);
			/*if (Enum.TryParse(AvatarType, out type) == false)
				return;*/

			if (type.Equals(Rhyme.Common.AvatarType.CUSTOM))
				return;

			Image = null;
		}
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SetNickNameResponse : Response
	{
		public string NickName;
		public string AvatarUrl;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class ReserveNickNameRequest
	{
		public Guid UserId;
		public string UserName;
		public string NickName;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class ReserveNickNameResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyPlayerKickOutParameter : NotifyTableParameter
	{
		public string UserName;
		public RBCommandType CommandType;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SaveTourneyFeeRequest
	{
		public Guid TourneyId;
		public Guid UserId;
		public long Amount;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SaveTourneyFeeResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class DeleteTourneyFeeForUserRequest
	{
		public Guid TourneyId;
		public Guid UserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class DeleteTourneyFeeForUserResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class DeleteTourneyFeeForTourneyRequest
	{
		public Guid TourneyId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class DeleteTourneyFeeForTourneyResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetLeaderBoardRequest
	{
		/*
		 * type1 : lobby rank info
		 * type2 : leader board rank info
		 * type3 : user rank info
		 */
		public int LeaderBoardGetType;
		public Guid UserId;
		public string NickName;
		public int Year;
		public int Month;
		public long BuyInPlusEntranceFee;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetLeaderBoardResponse : Response
	{
		public List<LeaderBoardEntry> Entries = new List<LeaderBoardEntry>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class LeaderBoardPlace
	{
		public int CreateDate;
		public int Place;
		public string UserName;
		public int AvatarId;
		public int PlayerId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class LeaderBoardEntry : LeaderBoardPlace
	{
		public long BuyInPlusEntranceFee;
		public string NickName;
		public int Point;
		public DateTime RefreshDate;
		public long Prize;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetLeaderBoardRewardResponse : Response
	{
		public List<LeaderBoardPlace> Results = new List<LeaderBoardPlace>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UpdateGGPointRequest
	{
		public long SequenceId;
		public List<GGPInformation> GGPInformation = new List<GGPInformation>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GGPInformation
	{
		public Guid UserId;
		public long EarnedGGPoint;
		public long SpentGGPoint;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UpdateGGPointResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class DebitGGPointRequest
	{
		public Guid UserId;
		public Guid SpId;
		public string UserName;
		public long GGPAmount;
		public Guid TournamentId;
		public long TransactionId;
		public long RequestId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class DebitGGPointResponse : Response
	{
		public Guid UserId;
		public long AfterGGPAmount;
		public long TransactionId;
		public string PlatformResult;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CreditGGPointRequest
	{
		public Guid UserId;
		public Guid SpId;
		public string UserName;
		public long GGPAmount;
		public Guid TournamentId;
		public long TransactionId;
		public long RequestId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CreditGGPointResponse : Response
	{
		public Guid UserId;
		public long AfterGGPAmount;
		public long TransactionId;
		public string PlatformResult;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class PurchaseTourneyMoneyRequest
	{
		public Guid UserId;
		public long DebitGGPoint;
		public long CreditTourneyMoney;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class PurchaseTourneyMoneyResponse : Response
	{
		public long NewGGPoint;
		public long NewTourneyMoney;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetAccountLockInfoRequest
	{
		public Guid UserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetAccountLockInfoResponse : Response
	{
		public bool IsAccountLocked;
		public bool IsImageLocked;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyAskingForRITTParameter : NotifyTableParameter
	{
		public Guid[] ParticipantsId = new List<Guid>().ToArray();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyRITTDecidedParameter : NotifyTableParameter
	{
		public Guid DecidedUserId;
		public bool IsOnRITT;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTourneyInTheMoneyParameter : NotifyTableParameter
	{
		public List<Guid> InTheMoneyUsers = new List<Guid>();
		public bool NeedWaitingInTheMoneyAnimation;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyCashOutResult : NotifyTableParameter
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetBuddyListRequest
	{
		[SetByServer]
		public Guid UserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class BuddyInformation
	{
		public Guid UserId;
		public string NickName;

		// use only db,account service for check allow buddy
		public Guid ServiceProviderId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetBuddyListResponse : Response
	{
		public List<BuddyInformation> BuddyList = new List<BuddyInformation>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UpdateBuddyListRequest
	{
		public Guid UserId;
		public string NickName;
		public Guid BuddyId;
		public string BuddyNickName;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UpdateBuddyListResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class DeleteBuddyListRequest
	{
		public Guid UserId;
		public Guid BuddyId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class DeleteBuddyListResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class FetchLeaderBoardDataRequest
	{
		public DateTime CRMRefreshDate;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class FetchLeaderBoardDataResponse : Response
	{
		public List<LeaderBoardEntry> Entries = new List<LeaderBoardEntry>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyUpdateBuddyParameter
	{
		public Guid UserId;
		public Guid BuddyId;
		public string BuddyNickName;
		public ResultCode Result;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyDeleteBuddyParameter
	{
		public Guid UserId;
		public Guid BuddyId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyChangeSuperUserFlag
	{
		public Guid UserId;
		public bool IsSuperUser;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyUpdateUserOptionParameter
	{
		public Guid UserId;
		public UserOptionFlag UserOptionFlag;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTicketInfoRequest
	{
		public Guid UserId;
		public Guid TicketId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTicketInfoResponse : Response
	{
		public int TicketTemplateId;
		public long TicketValue;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetJackpotAmountRequest
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetJackpotAmountResponse : Response
	{
		public long JackpotAmount;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GiveJackpotAmountRequest
	{
		public Guid TableId;
		public long HandHistoryId;
		public long SmallBlind;
		public long BigBlind;
		public TableName TableName;
		public GameType GameType;
		public long TotalJackpotAmount;
		public List<JackpotRecipientInfo> RecipientInfos = new List<JackpotRecipientInfo>();
		public List<JackpotTicketRecipientInfo> TicketRecipients = new List<JackpotTicketRecipientInfo>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GiveJackpotAmountResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class ModifyJackpotInfoRequest
	{
		public RBCommandType CommandType;
		public List<int> ModifyValues = new List<int>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class ModifyJackpotInfoResponse : Response
	{
	}

	#region Jackpot History

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class JackpotHistoryResult
	{
		public Guid JackpotHistoryId;
		public DateTime CreatedDate;
		public Guid TableId;
		public long HandHistoryId;
		public Stake Stakes;
		public GameType GameType;
		public string UserName;
		public string NickName;
		public decimal JackpotAmount;
		public int[] JackpotHand = new List<int>().ToArray();
		public int[] PlayerHands = new List<int>().ToArray();
		public int[] CommunityCards = new List<int>().ToArray();
		public decimal TotalEarnedAmountIncludedRake;
		public List<JackpotTicketRecipientInfo> TicketRecipients = new List<JackpotTicketRecipientInfo>();

		// Omaha AOF 잭팟용 핸드 정보
		// 상대 플레이어의 핸드
		public int[] NextTopRankOpponentPlayerHands = new List<int>().ToArray();

		[SetByServer]
		public Guid UserId;
		[SetByServer]
		public int AvatarId;
		[SetByServer]
		public string AvatarType;
		[SetByServer]
		public string ImageUrl;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class JackpotHistoryRequest
	{
		public int Page;
		public int GetHistoryCount;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class JackpotHistoryResponse : Response
	{
		public List<JackpotHistoryResult> WeeklyTopPlayers = new List<JackpotHistoryResult>();
		public List<JackpotHistoryResult> JackpotHistoryResult = new List<JackpotHistoryResult>();
		public int TotalItems;
		public int TotalPages;
		public List<JackpotPrize> JackpotPrizeTable = new List<JackpotPrize>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class JackpotPrize
	{
		public long TotalPotSize;
		public double PrizeRatio;
		public long Cap;
	}

	#endregion

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UpdateUserFlagsRequest
	{
		public string UserName;
		public bool IsAccountLocked;
		public bool IsImageLocked;
		public bool IsSuperUser;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UpdateUserFlagsResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyForceTourneyCompleteRequest
	{
		public Guid TourneyId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TableBalanceSnapshot
	{
		public Guid TableId;
		public Guid UserId;
		public long Balance;
		public DateTime RecordDateTime;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SaveTableBalanceSnapshotRequest
	{
		public List<TableBalanceSnapshot> TableBlanceList = new List<TableBalanceSnapshot>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SaveTableBalanceSnapshotResponse : Response
	{

	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class JackpotPrizeInfo
	{
		public Guid UserId;
		public int OrderNumber;
		public double PrizePercent;
		public long Cap;

		// set by AccountService
		public long JackpotAmount;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetJackpotPrizeRequest
	{
		// Account Service 에서 CashOut(기록용)해주기 위해 추가
		public Guid TableId;
		public string GameName;
		public PlatformGameType GameType;

		public int TicketTemplateId;
		public List<Tuple<Guid/*UserID*/, long/*UserSessionId*/>> TicketRecipients = new List<Tuple<Guid, long>>();
		public List<JackpotPrizeInfo> JackpotPlayerLists = new List<JackpotPrizeInfo>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetJackpotPrizeResponse : Response
	{
		public long TotalJackpotAmount;
		public int TicketTemplateId;
		public long TicketValue;
		public List<JackpotPrizeInfo> JackpotPlayerLists = new List<JackpotPrizeInfo>();
		public List<Guid/*UserId*/> TicketRecipientPlayerLists = new List<Guid>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class KickOutPlayerFromVaultRequest
	{
		public string UserName;

		// sitting out or leave table
		public RBCommandType CommandType;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class KickOutPlayerFromVaultResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class KickOutPlayerFromGPRequest
	{
		public string GpId;

		// sitting out or leave table
		public RBCommandType CommandType;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class KickOutPlayerFromGPResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyUpdatePlayerAvatarIdParameter
	{
		public Guid UserId;
		public int AvatarId;
		public string AvatarType;
		public string ImageUrl;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class AnnounceTransferFundForVaultRequest
	{
		public string RecipientUserName;
		public string SenderUserName;
		public long Amount;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class AnnounceTransferFundForVaultResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyRankInfoForVaultRequest
	{
		public string UserName;
		public NotifyRankInfoType NotifyType;
		public int Rank;
		public long RewardGGPoint;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyRankInfoForVaultResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetPlayerTicketListForVaultRequest
	{
		public uint AccountId;
		public int Rpp;
		public int Page;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetPlayerTicketListForVaultResponse : Response
	{
		public List<PlayerTicketInfoForVault> PlayerTicketInfos = new List<PlayerTicketInfoForVault>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class PlayerTicketInfoForVault
	{
		public Guid TicketId;
		public int TicketTemplateId;
		public string TicketName;
		public DateTime ExpirationDate;
		public long Value;
		public bool Refundable;
		public bool Used;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GiveUserSpecialAvatarRequest
	{
		public Guid ServiceProviderId;
		public string GpId;
		public int AvatarId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GiveUserSpecialAvatarResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetAvatarInfoRequest
	{
		public Guid UserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetAvatarInfoResponse : Response
	{
		public string AvatarType;
		public int AvatarId;
		public string ImageUrl;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyUpdateNickNameForGPRequest
	{
		// set by account service
		public Guid UserId;

		public string GpId;
		public string NewNickName;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyUpdateAvatarForGPRequest
	{
		// set by account service
		public Guid UserId;

		public string GpId;
		public int AvatarId;
		public string AvatarType;
		public string AvatarName;
		public bool IsEnabled;
		public string Url;
	}

	public class Dummy
	{
		public int IntVal = 1;
		public string StrVal = "2";
		public double DoubleVal = 3;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	//[CollectionDataContract( Name = "List<Dummy>")]
	public class BigSizePakcet
	{
		public int[] _bigArrayInts = new int[100];
		public List<Dummy> duumyList = new List<Dummy>();

		public void FillDatas()
		{
			Random rand = new Random();
			for (int i = 0; i < _bigArrayInts.Length; ++i)
			{
				_bigArrayInts[i] = rand.Next(int.MaxValue);
			}


			for (int i = 0; i < 100; ++i)
			{
				duumyList.Add(new Dummy() { IntVal = i, StrVal = "123", DoubleVal = (double)i });
			}
		}
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class ClientConnectionInfo
	{
		public string ClientAddress;
	}

}