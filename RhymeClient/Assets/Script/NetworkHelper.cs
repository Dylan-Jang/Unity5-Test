using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Rhyme.Bot.Helper
{
	class NetworkHelper
	{
		public static IPAddress GetLocalIpAddress()
		{
			if (!NetworkInterface.GetIsNetworkAvailable())
				return null;

			var host = Dns.GetHostEntry(Dns.GetHostName());
			return host.AddressList.FirstOrDefault(ip =>
				ip.AddressFamily == AddressFamily.InterNetwork
					&& (IPAddress.IsLoopback(ip) == false));
		}

		public static string UintToIpAddress(uint ip)
		{
			return new IPAddress(BitConverter.GetBytes(ip)).ToString();
		}

		private static string _hardwareNumber;

		//public static async Task<string> CreateHardwareNumber()
		//{
		//	if (string.IsNullOrEmpty(_hardwareNumber))
		//		_hardwareNumber = await CreateHardwareNumberCore();

		//	return _hardwareNumber;
		//}

		//private static async Task<string> CreateHardwareNumberCore()
		//{
		//	var tcs = new TaskCompletionSource<string>();
		//	Task.Factory.StartNew(() =>
		//	{
		//		try
		//		{
		//			using (var processorInfos = new ManagementObjectSearcher("Select * From Win32_BaseBoard"))
		//			{
		//				var baseObject = processorInfos.Get().Cast<ManagementBaseObject>().FirstOrDefault(info => info["SerialNumber"] != null && String.IsNullOrEmpty(info["SerialNumber"].ToString()) == false);
		//				if (baseObject != null)
		//				{
		//					tcs.SetResult(baseObject["SerialNumber"].ToString().Trim());
		//					return;
		//				}

		//				Logger.Log(LogInfo.Warn, new
		//				{
		//					Event = "couldn't_get_hardware_serial_number",
		//				});

		//				tcs.SetResult(MD5Generate.Create(SystemInformation.ComputerName));
		//			}
		//		}
		//		catch (Exception e)
		//		{
		//			Logger.Log(LogInfo.Warn, new
		//			{
		//				Event = "couldn't_get_hardware_serial_number",
		//				exception = e.ToString()
		//			});

		//			tcs.SetResult(MD5Generate.Create(SystemInformation.ComputerName));
		//		}
		//	});

		//	return await tcs.Task;
		//}

		public static string GetMacAddress()
		{
			var nics = NetworkInterface.GetAllNetworkInterfaces();
			var macAddress = string.Empty;
			foreach (var adapter in nics)
			{
				if (macAddress == string.Empty)// only return MAC Address from first card
				{
					var properties = adapter.GetIPProperties();
					macAddress = adapter.GetPhysicalAddress().ToString();
				}
			}
			return macAddress;
		}
	}
}
