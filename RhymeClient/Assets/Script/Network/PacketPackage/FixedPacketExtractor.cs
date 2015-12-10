using System;
using System.Net.Sockets;

using Assets.Script.Network.PacketPackage;

namespace SocketFramework.Network.Sockets
{
	public class FixedPacketExtractor : IPacketExtractor
	{
		private byte[] _byteArrayBuffer;
		private int _fixedBufferLength;

		private int _currentReceivedPacketOffset;	// 현재 읽고 있는 버퍼의 Offset
		private int _receivedBytesDoneCount;		// 이미 처리 한 패킷수
		private int _receivedBytesDoneThisOp;		// 현재 처리 된 패킷수
		private int _currentSocketBufferOffSet;		// 현재 Saea ReadBuffer에서 읽어 들인 buffer offset

		public bool IsDone
		{
			get { return _receivedBytesDoneCount == _fixedBufferLength; }
		}

		public FixedPacketExtractor(int fixedSize)
		{
			Reset(fixedSize);
		}

		public int Process(byte[] buffer, int remainingBytes)
		{
			if (_receivedBytesDoneCount == 0)
			{
				_byteArrayBuffer = new byte[_fixedBufferLength];
			}

			if (remainingBytes >= _fixedBufferLength - _receivedBytesDoneCount)
			{
				Buffer.BlockCopy(
					buffer,
					_currentSocketBufferOffSet + _currentReceivedPacketOffset - _fixedBufferLength + _receivedBytesDoneCount,
					_byteArrayBuffer,
					_receivedBytesDoneCount,
					_fixedBufferLength - _receivedBytesDoneCount);

				remainingBytes = remainingBytes - _fixedBufferLength + _receivedBytesDoneCount;
				_receivedBytesDoneThisOp = _fixedBufferLength - _receivedBytesDoneCount;
				_receivedBytesDoneCount = _fixedBufferLength;
			}
			else
			{
				Buffer.BlockCopy(
					buffer,
					_currentSocketBufferOffSet + _currentReceivedPacketOffset - _fixedBufferLength + _receivedBytesDoneCount,
					_byteArrayBuffer,
					_receivedBytesDoneCount,
					remainingBytes);

				_receivedBytesDoneThisOp = remainingBytes;
				_receivedBytesDoneCount += remainingBytes;

				remainingBytes = 0;
			}

			if (remainingBytes == 0)
			{
				_currentReceivedPacketOffset = _currentReceivedPacketOffset - _receivedBytesDoneThisOp;
				_receivedBytesDoneThisOp = 0;
			}

			// reset
			_currentSocketBufferOffSet = 0;

			return remainingBytes;
		}

		public byte[] GetBuffer()
		{
			return new ArraySegment<byte>(_byteArrayBuffer, 0, _fixedBufferLength).Array;
		}

		public void Reset(int fixedExtractSize, bool isClearBuffer = false)
		{
			_receivedBytesDoneCount = 0;
			_currentSocketBufferOffSet = 0;

			_fixedBufferLength = fixedExtractSize;
			_currentReceivedPacketOffset = _fixedBufferLength;

			if (isClearBuffer)
				_byteArrayBuffer = null;
		}

		public void CurrentSocketBufferOffSet(int offset)
		{
			_currentSocketBufferOffSet = offset;
		}
	}
}