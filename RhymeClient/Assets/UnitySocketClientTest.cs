using System;
using Rb.Services.Protocol;
using Rhyme.Client.Protocol.Enum;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
	public partial class UnitySocketClient
	{
		public GameObject ResultText;
		public void Protocol_Test()
		{
			Debug.Log("Start, Protocol_Test");
			Debug.Log("Serialize -> Server's response -> Deserialize");

			try
			{
				Protocol_TestInternal();
			}
			catch (Exception e)
			{
				Debug.Log(string.Format("Protocol_Test exception, {0}", e));
			}

			Debug.Log("Finish, Protocol_Test");
		}

		private void OnEmpty(object payload)
		{
			Debug.Log("Nothing, just dummy");
		}

		private void Protocol_TestInternal()
		{
			_socket.Send((int)RhymeClientSessionEnum.ProtocolTest, new ProtocolTestRequest());
		}

		private void SessionOnProtocolTestInternal(ProtocolTestResponse response)
		{
			Debug.Log(string.Format("Ping: Result={0}", response.Result));

			var textObj = ResultText.GetComponent<Text>();
			textObj.text = response.ToString();
		}
	}
}
