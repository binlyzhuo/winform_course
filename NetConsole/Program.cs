using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NetConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            GetData();
            Console.ReadLine();
        }

        private static async void GetData()
        {
            string url = "http://www.baidu.com";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = null;

            client.DefaultRequestHeaders.Add("Accept","application/json;odata=verbose");

            EnumeraterHeaders(client.DefaultRequestHeaders);
            Console.WriteLine();
            response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
                string responseBodyAsText = response.Content.ReadAsStringAsync().Result;
                int length = responseBodyAsText.Length;
                Console.WriteLine(length);
            }
        }

        private static void EnumeraterHeaders(HttpHeaders headers)
        {
            foreach (var header in headers)
            {
                string value = "";
                foreach (var val in header.Value)
                {
                    value = val + "";
                }

                Console.WriteLine("Header:"+header.Key+" Value:"+value);
            }
        }
    }
}
