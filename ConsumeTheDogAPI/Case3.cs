using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace ConsumeTheDogAPI
{
    class Case3
    {
        public static void PrintSpecifiedSubBreeds()
        {
            Console.WriteLine("What breed would you like to find sub-breeds for? (i.e. retriever)");
            string userBreed = Console.ReadLine();
            Console.WriteLine("");

            HttpWebRequest request = WebRequest.CreateHttp("https://dog.ceo/api/breed/" + userBreed + "/list");
            request.UserAgent = @"User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            String data = rd.ReadToEnd();
            JObject o = JObject.Parse(data);

            if (o["status"].ToString() == "error")
            {
                Console.WriteLine(userBreed + " subreeds could not be found.");
                Console.WriteLine("1) Go back to main menu." +
                                "\n2) Enter a different breed");

                if(int.TryParse(Console.ReadLine(), out int userChoice))
                {
                    if (userChoice == 1)
                    {
                        Program.ShowList();
                    }
                    else if (userChoice == 2)
                    {
                        PrintSpecifiedSubBreeds();
                    }
                }       
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("This application did not understand your input. Taking you back to the main menu.");
                    Program.ShowList();
                }

            }

            List<string> subBreeds = new List<string>();
            for (int i = 0; i < o["message"].Count(); i++)
            {
                string input = o["message"][i].ToString();
                subBreeds.Add(input);
            }
            foreach (string breed in subBreeds)
            {
                Console.WriteLine(breed + " " + userBreed);
            }
            Console.WriteLine("");
            System.Threading.Thread.Sleep(400);
            Program.ShowList();
        }
    }
}
