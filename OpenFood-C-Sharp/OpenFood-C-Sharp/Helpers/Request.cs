using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using OpenFood_C_Sharp.Modele;
using System.Net.Http.Headers;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;



namespace OpenFood_C_Sharp.Helpers
{
    class Request
    {
        static HttpClient client = new HttpClient();

        public static async Task<People> GetResultAsync(string path)
        {
            
            HttpResponseMessage responseMessage = await client.GetAsync(path);
            if (responseMessage.IsSuccessStatusCode)
            {
                string data = await responseMessage.Content.ReadAsStringAsync();
                People people = JsonConvert.DeserializeObject<People>(data);
              
                return people;
            }
            else
            {
                return null;
            }
        }
        public static async Task<People> RunAsync(string path)
        {
            People people = null;
            client.BaseAddress = new Uri("https://swapi.co/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage responseMessage = await client.GetAsync(path);
            if (responseMessage.IsSuccessStatusCode)
            {
                string data = await responseMessage.Content.ReadAsStringAsync();
                people = JsonConvert.DeserializeObject<People>(data);
            }
            Console.WriteLine(people.name);
            return people;
            
        }
    }
}
