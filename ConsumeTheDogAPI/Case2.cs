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
    class Case2
    {
        public static void SaveRandomDogImage()
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://dog.ceo/api/breeds/image/random");
            request.UserAgent = @"User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            String data = rd.ReadToEnd();
            JObject o = JObject.Parse(data);

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

            Console.WriteLine("Image was saved at " + saveLocation);
            Console.WriteLine("");
            System.Diagnostics.Process.Start(saveLocation);
            System.Threading.Thread.Sleep(400);
            Program.ShowList();
        }
    }
}

