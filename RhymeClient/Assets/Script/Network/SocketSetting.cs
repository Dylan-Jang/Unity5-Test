namespace Assets.Script.Network
{
	public class SocketSetting
	{
		private const int MegaBytes = 1024 * 1024;

		public const int SaeaBlockSize = 8 * 1024;
		public const int MaxConnectionAllow = 1024 * 3;

		// 1 Mega byte. (1024 Kilo byte, 1,048,576 byte)
		public const int MaxAllowBlockSize = SaeaBlockSize * 1024 * 1;

		// Protocol id is must 1 ~ 4999. (not start 0)
		public const int MinAllowProtocolId = 1;
		public const int MaxAllowProtocolId = 11000;

		public const bool LogDispatcher = true;
		
		// 요청이 너무 잦으면 끊어내는 설정
		// CountSecond동안 RequestThreshold 이상 요청 보내면 접속 끊김
		public const bool DisconnectTooFrequency = true;
		public const int CountSecond = 5;
		public const int RequestThreshold = 100;

		public const int DefaultRecvBuffSize = 8 * MegaBytes;
		public const int DefaultSendBuffSize = 8 * MegaBytes;
	}
}