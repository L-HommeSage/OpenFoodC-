using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenFood_C_Sharp.Modele
{
    class Film
    {
        public List<string> characters { get; set; }
        public string created { get; set; }
        public string director { get; set; }
        public string edited { get; set; }
        public string episode_id { get; set; }
        public string opening_crawl { get; set; }
        public List<string> planets { get; set; }
        public string producer { get; set; }
        public string release_date { get; set; }
        public List<string> species { get; set; }
        public List<string> starships { get; set; }
        public string title { get; set; }
        public List<string> vehicles { get; set; }
        public string url {get;set;}

        public Film()
        {

        }


        public override string ToString()
        {
            return title;
        }

    }
}
