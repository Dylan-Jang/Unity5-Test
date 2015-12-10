using System;

using ProtoBuf;

namespace Rhyme.Common.Protocol.Session
{
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyParameter
	{
		public Guid UserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifySessionDisconnectParameter : NotifyParameter
	{
		public ResultCode Reason;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyNoticeParameter
	{
		public string Message;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TableWaitingNoticeParameter
	{
		public Guid TableId = Guid.Empty;
		public Func<string> Message;
		public bool IsShowMessage;
		public int Duration;
		public bool IsForever;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class RequestAddBuddyAcceptRequest
	{
		public Guid RequestUserId;
		public string RequestNickName;

		[ProtoIgnore]
		public Guid AcceptUserId;
		[ProtoIgnore]
		public string AcceptNickName;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableAlertParameter
	{
		public TableAlertMessageType TableAlertMessageType;
		public string TableAlertMessage;
	}
}