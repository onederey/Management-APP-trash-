using HttpClientAsp.Classes;
using System;
using System.Threading;

namespace HttpClientAsp
{
	class Program
	{
		static void Main(string[] args)
		{
			var client = new HttpCustomClient("https://localhost:44306/server/");
			var serializer = new Serializer();
			var inputSet = new Input();
			var outSet = new Output();

			try
			{
				while(!client.PingServer())
				{
					Thread.Sleep(100);
				}
				Console.WriteLine("Connection established");

				var data = client.GetInputData();
				Console.WriteLine("Get data complete, sending answer...");

				outSet = data.Process();
				var result = client.WriteAnswer(outSet);

				Console.WriteLine($"Answer - {result}");

			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			Console.ReadLine();
		}
	}
}
