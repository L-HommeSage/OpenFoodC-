using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using OpenFood_C_Sharp.Modele;
using Newtonsoft.Json;

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

        public static List<Vehicle> GetAllVehicle()
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp("https://swapi.co/api/vehicles/");
            string responseStreamReader;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    responseStreamReader = reader.ReadToEnd();
                }
            }
            return JsonConvert.DeserializeObject<List<Vehicle>>(responseStreamReader);

        }
    }
}
