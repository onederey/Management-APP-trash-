using HttpClient.Classes;
using System;
using System.Net;
using System.Threading;

namespace HttpClient
{
	class Program
	{
        public static Output Process(Input input)
        {
            Output output = new Output();
            output.SumResult = 0;
            output.SortedInputs = new decimal[input.Muls.Length + input.Sums.Length];
            int idx = 0;
            foreach (decimal i in input.Sums)
            {
                output.SortedInputs[idx] = i;
                idx++;
                output.SumResult += i;
            }

            output.SumResult *= input.K;
            output.MulResult = 1;

            foreach (int i in input.Muls)
            {
                output.SortedInputs[idx] = i;
                idx++;
                output.MulResult *= i;
            }

            Array.Sort(output.SortedInputs);
            return output;
        }

        static void Main(string[] args)
		{
            var httpBase = new BaseHttpClient();
            var jsonSerializer = new JsonSerializer();

            int port = int.Parse(Console.ReadLine());
            Input input;
            bool ready = false;

            while (!ready)
            {
                ready = httpBase.Ping(port) == HttpStatusCode.OK;
                Thread.Sleep(100);
            }

            string s2 = httpBase.GetInputData(port);

			try
			{
                input = jsonSerializer.DeserializeJson<Input>(s2);
			}
            catch(Exception ex)
			{
                throw ex;
			}

            Output output = Process(input);
            string s3 = jsonSerializer.SerializeJson<Output>(output);
            httpBase.WriteAnswer(port, s3);
        }
	}
}
