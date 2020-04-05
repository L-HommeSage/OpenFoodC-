using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenFood_C_Sharp.Modele
{
    class Planet
    {
        public string climate { get; set; }
        public string created { get; set; }
        public string diameter { get; set; }
        public string edited { get; set; }
        public List<string> films { get; set; }
        public string gravity { get; set; }
        public string name { get; set; }
        public string orbital_period { get; set; }
        public string population { get; set; }
        public List<string> residents { get; set; }
        public string rotation_period { get; set; }
        public string surface_water { get; set; }
        public string terrain { get; set; }
        public string url {get;set;}

        public override string ToString()
        {
            return name;
        }
    }
}
