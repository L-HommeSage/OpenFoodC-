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
            JObject rss;
            string json = @"[]";
            JArray results = JArray.Parse(json);
            int page = 1;
            int peopleCount;

            do
            {
                // Requete http a la page "page"
                HttpWebRequest request = HttpWebRequest.CreateHttp("https://swapi.co/api/people/?page="+page);
                string responseStreamReader;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseStreamReader = reader.ReadToEnd();
                    }

                }
                // Concatenation du tab result du json
                rss = JObject.Parse(responseStreamReader);
                peopleCount = (int)rss["count"];
                results.Merge((JArray)rss["results"]);

                // Incrementationdu numero de page
                page++;
            } while (results.Count() != 10);

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
