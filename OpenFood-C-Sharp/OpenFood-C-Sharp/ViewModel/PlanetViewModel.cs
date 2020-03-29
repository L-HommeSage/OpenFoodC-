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
    class PlanetViewModel
    {
        public static Planet GetPlanet(string url)
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
            return JsonConvert.DeserializeObject<Planet>(responseStreamReader);
        }
        
        public static List<Planet> GetAllPlanets()
        {
            JObject rss;
            string json = @"[]";
            JArray results = JArray.Parse(json);
            int page = 1;
            int planetsCount;

            do
            {
                // Requete http a la page "page"
                HttpWebRequest request = HttpWebRequest.CreateHttp("https://swapi.co/api/planets/?page=" + page);
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
                planetsCount = (int)rss["count"];
                results.Merge((JArray)rss["results"]);

                // Incrementationdu numero de page
                page++;
            } while (results.Count() != planetsCount);

            return JsonConvert.DeserializeObject<List<Planet>>(results.ToString());

        }
        public static Frame CallPlanet(object sender, MouseEventArgs e, ListBox l,String lastUrl)
        {
            Planet p = (Planet)l.SelectedItem;
            PlanetPage planetPage = new PlanetPage(p.url,lastUrl) ;
            TabItem tabItem = new TabItem();
            Frame tabFrame = new Frame();
            tabFrame.Content = planetPage;
            return tabFrame;

        }
    }
}

