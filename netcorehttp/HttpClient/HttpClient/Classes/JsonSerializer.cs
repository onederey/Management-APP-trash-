using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpClient.Classes
{
	public class JsonSerializer
	{
        public string SerializeJson<T>(T disk)
        {
            return JsonConvert.SerializeObject(disk);
        }

        public T DeserializeJson<T>(string disk)
        {
            return JsonConvert.DeserializeObject<T>(disk);
        }
    }
}
