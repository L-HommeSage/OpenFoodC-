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
using OpenFood_C_Sharp.View;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Controls;
using System.Windows.Input;



namespace OpenFood_C_Sharp.Helpers
{
    class Request
    {
        public static List<People> MakeSearch(string category, string search)
        {
            JObject rss;
            string json = @"[]";
            JArray results = JArray.Parse(json);
            int ElementsCount;
            int page = 1;
            string url = "https://swapi.co/api/" + category + "/?page="+page+"&search=" + search;
            Console.WriteLine(url);
            do
            {
                // Requete http a la page "page"
                HttpWebRequest request = HttpWebRequest.CreateHttp("https://swapi.co/api/" + category + "/?page=" + page + "&search=" + search);
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
                ElementsCount = (int)rss["count"];
                results.Merge((JArray)rss["results"]);

                // Incrementationdu numero de page
                page++;
            } while (results.Count() != ElementsCount);
            
            return JsonConvert.DeserializeObject<List<People>>(results.ToString());

        }
    }
    
}


