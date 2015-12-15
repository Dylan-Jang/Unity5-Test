using Rb.Services.Protocol;
using SocketFramework.Network.Serialize;
using UnityEngine;

namespace Assets.Script.Network.Socket
{
	public class SocketCallbackBinder<TResponse> : ISocketCallbackBinder where TResponse : class
	{
		public delegate void CurrentDispatchFunctor(TResponse responseObject);

		public CurrentDispatchFunctor DispatchFunctor;
		public bool IsNotify;

		public void Dispatch(ref ISerializer serializer, byte[] payload)
		{
			var resObject = serializer.Deserialize(payload, typeof(TResponse)) as TResponse;
			if (resObject == null)
			{
				Debug.Log(string.Format("Deserialize failed: {0}", typeof(TResponse).Name));
				return;
			}

			if (IsNotify)
			{
				// Note: Notify message
			}
			else
			{
				// Note: Response message
				if (resObject is Response == false)
				{
					Debug.Log(string.Format("Type casting failed (Response): ResObject type: {0}, ResObject ToString(): {1}", resObject.GetType().Name, resObject));
					return;
				}
			}

			if (resObject.GetType() != typeof(TResponse))
			{
				Debug.Log(string.Format("Type casting failed: ResObject type: {0}, TResponse type: {1}", resObject.GetType().Name, typeof(TResponse)));
				return;
			}

			DispatchFunctor.Invoke(resObject);
		}
	}
}