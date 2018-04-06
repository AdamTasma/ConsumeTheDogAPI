using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ConsumeTheDogAPI
{
    class Case1 //Print all dog breeds
    {
        public static void Write()
        {
            Console.WriteLine("from case 1 write method.");
        }

        public static void PrintAllBreeds()
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://dog.ceo/api/breeds/list/all");
            request.UserAgent = @"User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            String data = rd.ReadToEnd();
            JObject o = JObject.Parse(data);
            //Console.WriteLine(o);
            JToken breedList = o["message"];

        }
    }
}
