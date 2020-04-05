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

namespace OpenFood_C_Sharp.ViewModel
{
    public class FilmViewModel
    {
        public static Film GetFilm(string url)
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
            return JsonConvert.DeserializeObject<Film>(responseStreamReader);
        }

        public static List<Film> GetAllFilm()
        {
            JObject rss;
            string json = @"[]";
            JArray results = JArray.Parse(json);
            int filmCount;

            do
            {
                // Requete http a la page "page"
                HttpWebRequest request = HttpWebRequest.CreateHttp("https://swapi.co/api/films/");
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
                filmCount = (int)rss["count"];
                results.Merge((JArray)rss["results"]);

                // Incrementationdu numero de page
                
            } while (results.Count() != filmCount);

            return JsonConvert.DeserializeObject<List<Film>>(results.ToString());

        }
        public static Frame CallFilm(object sender, MouseEventArgs e, ListBox l,List<String> lastUrl)
        {
            Film f = (Film)l.SelectedItem;
            FilmPage filmPage = new FilmPage(f.url,lastUrl);
            TabItem tabItem = new TabItem();
            Frame tabFrame = new Frame();
            tabFrame.Content = filmPage;
            return tabFrame;

        }
    }
}
