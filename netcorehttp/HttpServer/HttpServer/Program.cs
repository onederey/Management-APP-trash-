using HttpServer.Classes;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace HttpServer
{
	class Program
	{
        static HttpListener server;
        static bool bStop = false;

        static string GetJson(string jsonString)
		{
            var start = jsonString.IndexOf("{");
            var end = jsonString.LastIndexOf("}");

            return jsonString.Substring(start, end - start + 1);
		}

        static Output Process(Input input)
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
            var json = new JsonSerializer();

            int port = int.Parse(Console.ReadLine());

            Input input = new Input();
            Output output = new Output();
            server = new HttpListener();

			#region prefixes
			server.Prefixes.Add(String.Format("http://127.0.0.1:{0}/Ping/", port));
            server.Prefixes.Add(String.Format("http://127.0.0.1:{0}/PostInputData/", port));
            server.Prefixes.Add(String.Format("http://127.0.0.1:{0}/GetAnswer/", port));
            server.Prefixes.Add(String.Format("http://127.0.0.1:{0}/Stop/", port));
			#endregion

			try
			{
                server.Start();

                Console.WriteLine($"Port = {port}");

                while (!bStop)
                {
                    HttpListenerContext context = server.GetContext();
                    HttpListenerRequest request = context.Request;
                    if (request.RawUrl.ToUpper().Contains("PING"))
                    {
                        Console.WriteLine("PING");

                        string responseString = "";
                        HttpListenerResponse response = context.Response;
                        response.ContentType = "text/plain; charset=UTF-8";
                        response.StatusCode = 200;
                        byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                        response.ContentLength64 = buffer.Length;
                        using (Stream o = response.OutputStream)
                        {
                            o.Write(buffer, 0, buffer.Length);
                        }
                    }
                    else if (request.RawUrl.ToUpper().Contains("STOP"))
                    {
                        Console.WriteLine("STOP");

                        string responseString = "";
                        HttpListenerResponse response = context.Response;
                        response.ContentType = "text/plain; charset=UTF-8";
                        response.StatusCode = 200;
                        byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                        response.ContentLength64 = buffer.Length;
                        using (Stream o = response.OutputStream)
                        {
                            o.Write(buffer, 0, buffer.Length);
                        }
                        bStop = true;
                    }
                    else if (request.RawUrl.ToUpper().Contains("POSTINPUTDATA"))
                    {
                        Console.WriteLine("POSTINPUTDATA");

                        string s2;
                        using (Stream body = request.InputStream)
                        {
                            using (StreamReader reader = new StreamReader(body))
                            {
                                s2 = reader.ReadToEnd();
                            }
                        }
                        s2 = GetJson(s2);

                        string responseString = string.Empty;
                        HttpListenerResponse response = context.Response;

                        try
                        {
                            input = json.DeserializeJson<Input>(s2);
                            output = Process(input);

                            responseString = "Complete";
                            response.ContentType = "text/plain; charset=UTF-8";
                            response.StatusCode = 200;
                        }
                        catch(Exception ex)
						{
                            responseString = ex.Message;
                            response.ContentType = "text/plain; charset=UTF-8";
                            response.StatusCode = 400;
                        }

                        byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                        response.ContentLength64 = buffer.Length;
                        using (Stream o = response.OutputStream)
                        {
                            o.Write(buffer, 0, buffer.Length);
                        }
                    }
                    else if (request.RawUrl.ToUpper().Contains("GETANSWER"))
                    {
                        Console.WriteLine("GETANSWER");

                        string responseString;
                        HttpListenerResponse response = context.Response;
                        response.ContentType = "text/plain; charset=UTF-8";

                        if (output != null)
                        {
                            responseString = json.SerializeJson(output);
                            response.StatusCode = 200;
                        }
                        else
                        {
                            responseString = "";
                            response.StatusCode = 400;
                        }

                        byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                        response.ContentLength64 = buffer.Length;
                        using (Stream o = response.OutputStream)
                        {
                            o.Write(buffer, 0, buffer.Length);
                        }
                    }
                }
                server.Stop();
            }
            catch(Exception ex)
			{
                Console.WriteLine(ex.Message);
                Console.ReadLine();
			}
        }
	}
}
