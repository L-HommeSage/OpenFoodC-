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
using System.Windows.Controls;
using System.Windows.Input;
using OpenFood_C_Sharp.View;

namespace OpenFood_C_Sharp.ViewModel
{
    class VehicleViewModel
    {
        public static Vehicle GetVehicle(string url)
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
            return JsonConvert.DeserializeObject<Vehicle>(responseStreamReader);
        }

        public static List<Vehicle> GetAllVehicles()
        {
            JObject rss;
            string json = @"[]";
            JArray results = JArray.Parse(json);
            int page = 1;
            int vehiclesCount;

            do
            {
                // Requete http a la page "page"
                HttpWebRequest request = HttpWebRequest.CreateHttp("https://swapi.co/api/vehicles/?page=" + page);
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
                vehiclesCount = (int)rss["count"];
                results.Merge((JArray)rss["results"]);

                // Incrementationdu numero de page
                page++;
            } while (results.Count() != vehiclesCount);

            return JsonConvert.DeserializeObject<List<Vehicle>>(results.ToString());

        }
        public static Frame CallVehicule(object sender, MouseEventArgs e, ListBox l,String lastUrl)
        {
            Vehicle v = (Vehicle)l.SelectedItem;
            VehiclePage vehiclePage = new VehiclePage(v.url,lastUrl);
            TabItem tabItem = new TabItem();
            Frame tabFrame = new Frame();
            tabFrame.Content = vehiclePage;
            return tabFrame;
        }
    }
}
