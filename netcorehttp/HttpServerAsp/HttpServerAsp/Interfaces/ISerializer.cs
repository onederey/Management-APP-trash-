using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpServerAsp.Interfaces
{
	public interface ISerializer
	{
		string SerializeJson<T>(T disk);

		T DeserializeJson<T>(string disk);

		string SerializeXml<T>(T disk);

		T DeserializeXml<T>(string disk);
	}
}
