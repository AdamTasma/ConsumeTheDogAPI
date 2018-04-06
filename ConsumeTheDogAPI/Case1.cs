using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ConsumeTheDogAPI
{
    class Case1
    {
        public static void PrintAllBreeds()
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://dog.ceo/api/breeds/list/all");
            request.UserAgent = @"User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            String data = rd.ReadToEnd();
            JObject o = JObject.Parse(data);
            JToken wholeFile = o["message"];
            Console.WriteLine(wholeFile);
            //JObject message = o["message"];

            var jarray = JsonConvert.DeserializeObject<List<object>>(data);

             



            Console.WriteLine("");
            System.Threading.Thread.Sleep(400);
            Program.ShowList();
        }
    }
}
