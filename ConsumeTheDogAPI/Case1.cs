using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;

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
            //JObject o = JObject.Parse(data);
            //JToken message = o["message"];

            //List<string[]> breeds = new List<string[]>();

            //for (int i = 0; i < o["message"].Count(); i++)
            //{
            //    string input = o["message"][i].ToString();
            //    breeds.Add(input);
            //}
            //foreach (string[] breed in breeds)
            //{
            //    Console.WriteLine(breed);
            //}

            //JObject jResults = JObject.Parse(jsonfeed);
            //JToken jResults_bank = jResults["bank"];

            //foreach (JObject bank in jResults_bank)
            //{
            //    JToken jResults_bank_endpoint = bank["endpoints"];
            //    foreach (JObject endpoint in jResults_bank_endpoint)
            //    {
            //        if (bank["epName"].ToString() == "FRED001")
            //        {
            //            MessageBow.Show(bank["epId"].ToString());
            //        }
            //    }
            //}

            //JObject jResults = JObject.Parse(data);
            //JToken jResults_message = jResults["message"];
            //List<Array> myList = new List<Array>();
            //foreach (JObject message in jResults_message)
            //{
            //    JToken jResults_message_breed = message;
            //    Console.WriteLine(message);
            //    //myList.Add(jResults_message_breed);
            //}

            //JObject o = JObject.Parse(data);
            //JObject message = o["message"];
            //Console.WriteLine(message.bulldog); 
            Console.WriteLine("");
            System.Threading.Thread.Sleep(400);
            Program.ShowList();
        }
    }
}
