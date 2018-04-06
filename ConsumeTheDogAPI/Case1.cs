using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
//using System.Web.Script.Serialization.JavaScriptSerializer;

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

            //converts the json file into an object
            dynamic obj = JsonConvert.DeserializeObject<dynamic>(data);
            //now we only concern ourselves with the message object
            var message = obj.message;
            //message comes in as variables and keys(the dynamic name), or subBreeds and Breed
            //assign the correct properties to the variables
            foreach (var breed in message)
            {
                var breedName = breed.Name;
                Console.WriteLine(breedName);
                var subBreeds = breed.Value;
                foreach (var subBreed in subBreeds)
                {

                    Console.WriteLine(subBreed.Value + " " + breedName);
                }
            }

            Console.WriteLine("");
            System.Threading.Thread.Sleep(400);
            Program.ShowList();
        }
    }
}
