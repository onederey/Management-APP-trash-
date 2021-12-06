using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace HttpClient.Classes
{
	public class BaseHttpClient
	{
        #region headers
        string useragent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.113 Safari/537.36";
        string accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
        string AcceptCharset = "Accept-Charset=windows-1251,utf-8;q=0.7,*;q=0.7";
        string AcceptLanguage = "ru-ru,ru;q=0.8,en-us;q=0.5,en;q=0.3";
        #endregion

        private string Send(string url, string method, string contenttype, byte[] content, out HttpStatusCode code)
        {
            string txt = "";
            try
            {
                Uri uri = new Uri(url);
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);

                req.ContentType = @"text/html; charset=utf-8";
                req.AllowAutoRedirect = true;
                req.UserAgent = useragent;
                req.Accept = accept;
                req.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                req.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                req.Headers.Add(HttpRequestHeader.AcceptLanguage, AcceptLanguage);
                req.Headers.Add(HttpRequestHeader.AcceptCharset, AcceptCharset);

                if (method == "POST")
                {
                    req.Method = method;
                    req.ContentType = contenttype;
                    req.ContentLength = content.Length;
                    req.GetRequestStream().Write(content, 0, content.Length);
                }
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

                StreamReader reader = new StreamReader(resp.GetResponseStream(), Encoding.Default);
                txt = reader.ReadToEnd();
                reader.Close();
                code = resp.StatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                code = HttpStatusCode.InternalServerError;
            }
            return txt;
        }

        public string Get(string url, out HttpStatusCode code)
        {
            return Send(url, "GET", "", new byte[0], out code);
        }

        public string Post(string url, string postdata, out HttpStatusCode code)
        {
            byte[] ByteArr = Encoding.GetEncoding("UTF-8").GetBytes(postdata);
            return Send(url, "POST", "application/x-www-form-urlencoded", ByteArr, out code);
        }
        
        public HttpStatusCode Ping(int port)
        {
			string url = String.Format("http://127.0.0.1:{0}/Ping", port);
			Get(url, out HttpStatusCode status);
            return status;
        }
        
        public string GetInputData(int port)
        {
			string url = String.Format("http://127.0.0.1:{0}/GetInputData", port);
			return Get(url, out HttpStatusCode r);
        }
        
        public HttpStatusCode WriteAnswer(int port, string data)
        {
			string url = String.Format("http://127.0.0.1:{0}/WriteAnswer", port);
			Post(url, data, out HttpStatusCode status);
            return status;
        }
    }
}
