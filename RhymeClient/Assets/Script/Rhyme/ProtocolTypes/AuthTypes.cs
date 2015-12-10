using System;

using ProtoBuf;

using Rhyme.Common.Attributes;

namespace Rb.Services.Protocol.Auth
{
	/// <summary>
	/// Requst to CreateToken.
	/// </summary>
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CreateTokenRequest
	{
		/// <summary>
		/// Gets or sets the user id.
		/// </summary>
		/// <value>
		/// The user id (Set by server)
		/// </value>
		[SetByServer]
		public Guid UserId;

		public Guid TableId { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is platform issue required.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance is platform issue required;
		/// <c>false</c> otherwise;
		/// </value>
		public bool IsPlatformIssueRequired;
	}

	/// <summary>
	/// Response to CreateToken.
	/// </summary>
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CreateTokenResponse : Response
	{
		/// <summary>
		/// Gets or sets the token id.
		/// </summary>
		/// <value>
		/// The token id.
		/// </value>
		public string TokenId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class AuthByTokenRequest
	{
		public string TokenId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class AuthByTokenResponse : Response
	{
	}
}