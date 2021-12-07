using System;
using System.Collections.Generic;
using System.Text;

namespace HttpClientAsp.Classes
{
	public class HttpCustomClient : HttpClientBase
	{
		public HttpCustomClient(string url) : base(url) { }

		public bool PingServer() => MakeGetRequest<bool>("ping");

		public Input GetInputData() => MakeGetRequest<Input>("getinputdata");

		public string WriteAnswer(Output answer) => MakePostRequest("writeanswer", answer);
	}
}
