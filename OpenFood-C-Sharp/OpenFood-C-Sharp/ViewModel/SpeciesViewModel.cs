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
using System.Windows.Input;
using System.Windows.Controls;
using OpenFood_C_Sharp.View;

namespace OpenFood_C_Sharp.ViewModel
{
    class SpeciesViewModel
    {
        public static Species GetSpecies(string url)
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
            return JsonConvert.DeserializeObject<Species>(responseStreamReader);
        }

        public static List<Species> GetAllSpecies()
        {
            JObject rss;
            string json = @"[]";
            JArray results = JArray.Parse(json);
            int page = 1;
            int speciesCount;

            do
            {
                // Requete http a la page "page"
                HttpWebRequest request = HttpWebRequest.CreateHttp("https://swapi.co/api/species/?page=" + page);
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
                speciesCount = (int)rss["count"];
                results.Merge((JArray)rss["results"]);

                // Incrementationdu numero de page
                page++;
            } while (results.Count() != speciesCount);

            return JsonConvert.DeserializeObject<List<Species>>(results.ToString());

        }
        public static Frame CallSpecies(object sender, MouseEventArgs e, ListBox l,String lastUrl)
        {
            Species s = (Species)l.SelectedItem;
            SpeciesPage speciesPage = new SpeciesPage(s.url,lastUrl);
            TabItem tabItem = new TabItem();
            Frame tabFrame = new Frame();
            tabFrame.Content = speciesPage;
            return tabFrame;
        }
    }
}
