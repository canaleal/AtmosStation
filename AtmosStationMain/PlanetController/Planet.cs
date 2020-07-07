using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmosStationMain.ItemController
{
    class Planet
    {
        public int planetID { get; set; }
        public string name { get; set; }
        public List<int> coord { get; set; }
        public Dictionary<string, List<string>> resources { get; set; }

        public Planet(int planetID, string name, int x, int y, Dictionary<string, List<string>> resources)
        {

            this.planetID = planetID;
            this.name = name;
          
            coord = new List<int>
            {
                x,
                y
            };

            this.resources = resources;
        }



       


    }
}