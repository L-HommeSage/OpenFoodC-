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
using OpenFood_C_Sharp.ViewModel;
using System.Windows.Controls;
using OpenFood_C_Sharp.View;

namespace OpenFood_C_Sharp.Helpers
{
    class Helper
    {
        public static Frame GoBack(List<String> backUrl)
        {
            Frame frame = new Frame();
            string lastUrl = backUrl.Last();
            backUrl.Remove(lastUrl);
            switch (parseUrl(lastUrl))
            {
                case "planets":
                    PlanetPage planetPage = new PlanetPage(lastUrl, backUrl);
                    Frame planetFrame = new Frame();
                    frame.Content = planetPage;
                    break;
                case "species":
                    SpeciesPage speciesPage = new SpeciesPage(lastUrl, backUrl);
                    Frame speciesFrame = new Frame();
                    frame.Content = speciesPage;
                    break;
                case "vehicles":
                    VehiclePage vehiclePage = new VehiclePage(lastUrl, backUrl);
                    frame.Content = vehiclePage;
                    break;
                case "starships":
                    StarshipPage starshipPage = new StarshipPage(lastUrl, backUrl);
                    frame.Content = starshipPage;
                    break;
                case "people":
                    PeoplePage peoplePage = new PeoplePage(lastUrl, backUrl);
                    frame.Content = peoplePage;
                    break;
                case "films":
                    FilmPage filmPage = new FilmPage(lastUrl, backUrl);
                    frame.Content = filmPage;
                    break;
            }
            return frame;

        }
        private static String parseUrl(String url)
        {
            String baseUrl = "https://swapi.co/api/";
            String type = url.Replace(baseUrl, "");
            type = type.Split('/')[0];
            Console.WriteLine(type);
            return type;
        }
    }

}
