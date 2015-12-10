using Rhyme.Common;

namespace Rb.Services.Protocol.GP
{
	public enum GPErrorCode
	{
		NONE,

		// description : Server failed to complete the request due to unexpected error.
		// http status code : 500 Internal Server Error
		INTERNAL_ERROR,

		// description : Merchant does not exist.
		// http status code : 404 Not Found
		MERCHANT_NOT_FOUND,

		// description : Requesting server has no access to this URI.
		// http status code : 401 Unauthrized
		ACCESS_DENIED,

		// description : Request body has invalid syntax.
		// http status code : 400 Bad Request
		INVALID_REQUEST,

		// description : Nickname must be 4-20 characters.
		// http status code : 422 Unprocessable Entity
		INVALID_NICKNAME,

		// description : Nickname is already being used.
		// http status code : 409 Conflict
		NICKNAME_ALREADY_EXISTS,

		// description : Nickname has already been set.
		// http status code : 403 Forbidden
		NICKNAME_ALREADY_SET,

		// description : Account does not exist.
		// http status code : 404 Not Found
		ACCOUNT_NOT_FOUND,

		// description : Nickname is not being used.
		// http status code : 404 Not Found
		NICKNAME_NOT_FOUND,

		// description : Launch token is not found.
		// http status code : 404 Not Found
		LAUNCH_TOKEN_NOT_FOUND,

		// description : Launch token has expired.
		// http status code : 401 Unauthorized
		LAUNCH_TOKEN_EXPIRED,

		// description : Try again later as this API is being throttled.
		// http status code : 429 Too Many Requests
		SYSTEM_BUSY,

		// description : Request failed due to insufficient account balance.
		// http status code : 422 Unprocessable Entity
		INSUFFICIENT_BALANCE,

		// description : Transaction already exists.
		// http status code : 409 Conflict
		TRANSACTION_ALREADY_EXISTS,

		// description : Transaction has already been cancelled.
		// http status code : 410 Gone
		TRANSACTION_ALREADY_CANCELLED,

		TRANSACTION_NOT_FOUND,

		// description : Avatar does not exist.
		// http status code : 404 Not Found
		AVATAR_NOT_FOUND,

		// description : Image must be 100x100 pixel PNG/JPG of size 512KB or less.
		// http status code : 422 Unprocessable Entity
		UNSUPPORTED_IMAGE,

		// description : Only special avatar can be given to an account.
		// http status code : 422 Unprocessable Entity
		INVALID_AVATAR_TYPE,

		// description : Avatar {avatarId} is suspended.
		// http status code : 422 Unprocessable Entity
		AVATAR_SUSPENDED,

		// description : Avatar {avatarId} is already owned by the account {gpId}.
		// http status code : 409 Conflict
		AVATAR_ALREADY_OWNED,

		// description : Merchant encountered an internal error.
		// http status code : 500 Internal Server Error
		MERCHANT_INTERNAL_ERROR,

		// description : Response to request timed out.
		// http status code : 500 Internal Server Error
		MERCHANT_TIMEOUT,

		INVALID_TRANSACTION_TYPE,

		// description : Label {labelId} does not exist.
		// http status code : 404 Not Found
		LABEL_NOT_FOUND,

		// description : Merchant wallet server responded with invalid currency value.
		// http status code : 500 Internal Server Error
		INVALID_CURRENCY_VALUE,

		// description : Currency AAA does not exist.
		// http status code : 404 Not Found
		CURRENCY_NOT_FOUND,

		USER_ALREADY_OFFLINE,

		BRAND_INTERNAL_ERROR,
	}

	/*
	 * 
	 * 
	 * RestSharp.RestClient searching for a matching property in your class. not field !
	 * 
	 * 
	 * */

	public class GPResponse
	{
		public string Code { get; set; }
		public string Message { get; set; }
	}

	public class GPDebitRequest
	{
		public string requestId { get; set; }
		public long amount { get; set; }
		public long value { get; set; }
		public string transactionTag { get; set; }
		public long userSessionId { get; set; }
		public string gameType { get; set; }
		public string gameId { get; set; }
		public string gameName { get; set; }
		public string ticketId { get; set; }
		public string userIp { get; set; }
	}

	public class GPCreditRequest
	{
		public string requestId { get; set; }
		public long amount { get; set; }
		public long value { get; set; }
		public string transactionTag { get; set; }
		public long userSessionId { get; set; }
		public string gameType { get; set; }
		public string gameId { get; set; }
		public string gameName { get; set; }
		public string ticketId { get; set; }
		public long tournamentOverlay { get; set; }
		public long rakedHands { get; set; }
		public long rakeOrFee { get; set; }
		public string userIp { get; set; }
	}

	public class GPLoginTokensResponse : GPResponse
	{
		public string GpId { get; set; }
		public string CountryCode { get; set; }
	}

	public class GPGetBalanceResponse : GPResponse
	{
		public string GpId { get; set; }
		public long Amount { get; set; }
		public string CurrencyId { get; set; }
		public double CurrencyAmount { get; set; }
		public double ExchangeRate { get; set; }
	}

	public class GPGetAccessTokenResponse : GPResponse
	{
		public string Token { get; set; }
	}

	public class GPCancelRequest
	{
		public string requestId { get; set; }
		public long userSessionId { get; set; }
		public long amount { get; set; }
	}

	public class GPSetUserAvatarIdRequest
	{
		public int avatarId { get; set; }
	}

	public class GPDefaultAvatar
	{
		public string merchantId { get; set; }
		public int avatarId { get; set; }
		public string name { get; set; }
		public string url { get; set; }
		public AvatarType type { get; set; }
	}

	public class GPSpecialAvatar
	{
		public int avatarId { get; set; }
		public string url { get; set; }
	}

	public class GPGetAccountInformation : GPResponse
	{
		public string GpId { get; set; }
		public string NickName { get; set; }
		public string LoginName { get; set; }
		public int AvatarId { get; set; }
		public AvatarInformation Avatar { get; set; }
	}

	public class AvatarInformation
	{
		public int AvatarId { get; set; }
		public string Type { get; set; }
		public string Name { get; set; }
		public string Status { get; set; }
		public string Url { get; set; }
	}

	public class GPSettingUserAvatarResponse : GPResponse
	{
		public int AvatarId { get; set; }
		public string BrandId { get; set; }
		public string CreatedAt { get; set; }
		public bool IsEnabled { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public string UpdatedAt { get; set; }
		public string Url { get; set; }
	}

	public class GPLogoResponse : GPResponse
	{
		public string LabelId { get; set; }
		public string MerchantId { get; set; }
		public bool IsDefault { get; set; }
		public string LogoUrl { get; set; }
		public string IconUrl { get; set; }
		public string Language { get; set; }
		public string CreateAt { get; set; }
		public string UpdateAt { get; set; }
	}
}
