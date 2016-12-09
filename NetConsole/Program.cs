using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
                string responseBodyAsText = response.Content.ReadAsStringAsync().Result;
                int length = responseBodyAsText.Length;
                Console.WriteLine(length);
            }
        }
    }
}
