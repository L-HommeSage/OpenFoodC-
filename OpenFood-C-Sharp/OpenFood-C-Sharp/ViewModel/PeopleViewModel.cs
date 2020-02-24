using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using OpenFood_C_Sharp.Modele;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OpenFood_C_Sharp.ViewModel
{
    class PeopleViewModel
    {
        public static People GetPeople(string url)
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp(url);
            string responseStreamReader;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    responseStreamReader = reader.ReadToEnd();
                }
            }
            return  JsonConvert.DeserializeObject<People>(responseStreamReader);
        }

        public static List<People> GetAllPeople()
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp("https://swapi.co/api/people/");
            string responseStreamReader;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    responseStreamReader = reader.ReadToEnd();
                }
            }

            JObject rss = JObject.Parse(responseStreamReader); 
            JArray results = (JArray)rss["results"];
            Console.WriteLine(results.ToString());
            return JsonConvert.DeserializeObject<List<People>>(results.ToString());

        }
        /*
        public static ObservableCollection<People> GetListOfPeople() 
        {
            ObservableCollection<People> ListePeople = new ObservableCollection<People>();

            List<People> A = GetAllPeople();

            for (int i = 0 ; i < A.Count ; i++)
            {
                ListePeople.Add(A[i]);
            }

            return ListePeople;
        }*/
    }
}
