using System;
using System.Collections.Generic;

using ProtoBuf;

using Rhyme.Common;

namespace Rb.Services.Protocol
{
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class MessageHeader
	{
		public string ProcessLabel;
		public string ServiceName;

		public string ToLogString()
		{
			return string.Format("[process_label={0}][service_name={1}]", ProcessLabel, ServiceName);
		}
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class Response
	{
		public ResultCode Result;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class InitSessionRequest
	{
		public bool CallbackChannel;
		public string AuthorizationKey;
		public uint ServiceId;
		public string ServiceLabel;
		public string[] ExposedInterfaces = new List<string>().ToArray();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class EntityId : ICloneable
	{
		public uint Type;
		public uint Value;

		public object Clone()
		{
			return new EntityId
			{
				Type = Type,
				Value = Value,
			};
		}

		public static bool operator ==(EntityId x, EntityId y)
		{
			if (ReferenceEquals(x, null))
				return ReferenceEquals(y, null);

			return x.Equals(y);
		}

		public static bool operator !=(EntityId x, EntityId y)
		{
			return !(x == y);
		}

		public int CompareTo(object obj)
		{
			if (obj == null)
				return 1;

			var rhs = obj as EntityId;
			if (rhs == null)
				throw new ArgumentException("Object is not a ServiceEntityId");

			// Compare Type first.
			if (Type > rhs.Type || Type < rhs.Type)
				return Type.CompareTo(rhs.Type);

			// The same type. Compare Value.
			return Value.CompareTo(rhs.Value);
		}

		public override bool Equals(Object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;
			if (ReferenceEquals(this, obj))
				return true;

			if (obj.GetType() != typeof(EntityId))
				return false;

			return Equals((EntityId)obj);
		}

		public bool Equals(EntityId other)
		{
			if (ReferenceEquals(null, other))
				return false;
			if (ReferenceEquals(this, other))
				return true;
			return other.Type == Type && other.Value == Value;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (Type.GetHashCode() * 397) ^ Value.GetHashCode();
			}
		}
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class PingResponse : Response
	{
	}
}