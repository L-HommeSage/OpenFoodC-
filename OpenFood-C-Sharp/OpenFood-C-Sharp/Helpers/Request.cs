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
            client.BaseAddress = new Uri("https://swapi.co/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage responseMessage = await client.GetAsync(path);
            if (responseMessage.IsSuccessStatusCode)
            {
                string data = await responseMessage.Content.ReadAsStringAsync();
                People people = JsonConvert.DeserializeObject<People>(data);
                Console.WriteLine(data);
                Console.WriteLine(people.name);


                return people;
            }
            else
            {
                return null;
            }
        }
        public static async Task RunAsync()
        {
            client.BaseAddress = new Uri("https://swapi.co/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            await GetResultAsync("people/1");
            }
    }
}
