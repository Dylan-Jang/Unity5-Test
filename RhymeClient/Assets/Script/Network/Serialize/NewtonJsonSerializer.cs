using System;
using System.Linq;
using System.Reflection;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using ProtoBuf;

using SocketFramework.Network.PipesAndFilter;

namespace SocketFramework.Network.Serialize
{
	public class NewtonJsonSerializer : ISerializer
	{
		private readonly Pipeline<byte[]> _serializeFileter = new Pipeline<byte[]>();
		private readonly Pipeline<byte[]> _deserializeFileter = new Pipeline<byte[]>();

		private JsonSerializerSettings _jsonSerializerSettings;

		public NewtonJsonSerializer()
		{
			_serializeFileter.Register(new ZipCompressFilter());
			// _serializeFileter.Register(new AesEncryptFilter());

			_deserializeFileter.Register(new ZipExtractFilter());
			// _deserializeFileter.Register(new AesDecryptFilter());

			_jsonSerializerSettings = new JsonSerializerSettings()
			{
				DateTimeZoneHandling = DateTimeZoneHandling.Utc,
				DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,

				NullValueHandling = NullValueHandling.Ignore,
				ContractResolver = new JsonSerializeContractResolver(),
			};
		}

		byte[] ISerializer.Serialize<T>(T instance)
		{
			// T -> string
			var serialized = JsonConvert.SerializeObject(instance, _jsonSerializerSettings);

			// string -> bytes[]
			var srcFilter = Encoding.UTF8.GetBytes(serialized);
			
			return _serializeFileter.Execute(srcFilter);
		}

		T ISerializer.Deserialize<T>(byte[] buffer)
		{
			return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(buffer));
		}

		object ISerializer.Deserialize(byte[] buffer, Type type)
		{
			var bytesFiltered = _deserializeFileter.Execute(buffer);
			var jsonString = Encoding.UTF8.GetString(bytesFiltered);
			return JsonConvert.DeserializeObject(jsonString, type);
		}
	}

	public class JsonSerializeContractResolver : DefaultContractResolver
	{
		protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
		{
			JsonProperty property = base.CreateProperty(member, memberSerialization);

			var attrs = member.GetCustomAttributes(typeof(ProtoIgnoreAttribute), true);
			if (attrs.Any())
				property.ShouldSerialize = i => false;
			else
				property.ShouldSerialize = i => true;

			return property;
		}
	}
}
