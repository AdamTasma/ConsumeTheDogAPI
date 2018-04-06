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
    class Case4
    {
        public static void SaveSpecifiedBreedImage()
        {
            Console.WriteLine("From which breed would you like to download an image.");
            string userBreed = Console.ReadLine();

            HttpWebRequest request = WebRequest.CreateHttp("https://dog.ceo/api/breed/" + userBreed + "/images/random");
            request.UserAgent = @"User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            String data = rd.ReadToEnd();
            JObject o = JObject.Parse(data);

            if (o["status"].ToString() == "error")
            {
                Console.WriteLine(userBreed + " wasn't found in the database.");
                Console.WriteLine("1) Go back to main menu." +
                                "\n2) Enter a different breed");

                if (int.TryParse(Console.ReadLine(), out int userChoice))
                {
                    if (userChoice == 1)
                    {
                        Program.ShowList();
                    }
                    else if (userChoice == 2)
                    {
                        SaveSpecifiedBreedImage();
                    }
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("This application did not understand your input. Taking you back to the main menu.");
                    Program.ShowList();
                }
            }

            string imageUrl = o["message"].ToString();
            string[] words = imageUrl.Split('/');
            string imageName = words.Last();
            string myPictures = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            string saveLocation = myPictures + @"\dogPics\" + imageName;

            if (!Directory.Exists(myPictures + @"\dogPics"))
            {
                Directory.CreateDirectory(myPictures + @"\dogPics");
            }

            byte[] imageBytes;
            HttpWebRequest imageRequest = (HttpWebRequest)WebRequest.Create(imageUrl);
            WebResponse imageResponse = imageRequest.GetResponse();
            Stream responseStream = imageResponse.GetResponseStream();

            using (BinaryReader br = new BinaryReader(responseStream))
            {
                imageBytes = br.ReadBytes(500000);
                br.Close();
            }
            responseStream.Close();
            imageResponse.Close();

            FileStream fs = new FileStream(saveLocation, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            try
            {
                bw.Write(imageBytes);
            }
            finally
            {
                fs.Close();
                bw.Close();
            }
            Console.WriteLine("");
            Console.WriteLine("Image was saved at " + saveLocation);
            Console.WriteLine("");
            System.Diagnostics.Process.Start(saveLocation);
            System.Threading.Thread.Sleep(400);
            Program.ShowList();
        }
    }
}
