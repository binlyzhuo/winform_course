using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace CodeContractSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //http://blog.csdn.net/zj735539703/article/details/46486777
            List<int> list = new List<int>() { 1, 2, 3, 4, 4, 5, 6, 6 };
            var newList = list.Distinct().ToList();

            UploadFiles();

            Console.WriteLine();
            Console.ReadLine();
        }

        static void UploadFiles()
        {
            string[] files = new string[2];
            files[0] = @"D:\testfiles\1.doc";
            files[1] = @"D:\testfiles\2.doc";

            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("uid", "1");
            nvc.Add("upwd", "1");
            

            string url = "http://127.0.0.1";
            string rsp = UpLoadFile(url, nvc, files, "application/msword");
        }

        public static string UpLoadFile(string url,NameValueCollection formParams,string[] files, string contentType)
        {
            
            string result = string.Empty;
            if (files.Length <= 0) return result;

            
            //string url = "http://(serverip)/test/test.aspx";

            string boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.KeepAlive = true;
            //wr.Credentials = System.NET.CredentialCache.DefaultCredentials;


            Stream rs = wr.GetRequestStream();

            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            foreach (string key in formParams.Keys)
            {
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                string formitem = string.Format(formdataTemplate, key, formParams[key]);
                byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
            }
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");

            for (int k = 0, k2 = files.Length; k < k2; k++)
            {
                string fname = "uploadfile" + k.ToString();
                string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
                string header = string.Format(headerTemplate, fname, files[k], contentType);
                byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
                rs.Write(headerbytes, 0, headerbytes.Length);

                FileStream fileStream = new FileStream(files[k], FileMode.Open, FileAccess.Read);
                byte[] buffer = new byte[4096];
                int bytesRead = 0;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    rs.Write(buffer, 0, bytesRead);
                }
                fileStream.Close();
                if (k < k2 - 1) rs.Write(boundarybytes, 0, boundarybytes.Length);
            }
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();
            WebResponse wresp = null;
            try
            {
                wresp = wr.GetResponse();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);

                result = reader2.ReadToEnd();
            }
            catch (Exception ex)
            {
                if (wresp != null)
                {
                    wresp.Close();
                    wresp = null;
                }
                result = ex.Message;
            }
            finally
            {
                wr = null;
            }
            return result;
        }
    }
}
