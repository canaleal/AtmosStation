using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmosStationMain.ItemController
{
    class PlanetManager
    {

        //Array holding all the planets in the game
        private List<Planet> planetArray = new List<Planet>();
        
        public PlanetManager()
        {
            SetPlanet();
        }

        //Dictionary containg the planets
        public void SetPlanet()
        {
            

            planetArray.Add(new Planet(1, "Atmos", 5, 5, new Dictionary<string, List<string>>
            {
                { "Fuel", new List<string>{"15" } },
                { "Etril", new List<string>{"400", "This metal is dark gray in color and produces pale orange oxide.  It is very hard when solid and melts at 632 degrees Kelvin.  It is an average conductor of electricity and an excellent conductor of heat.", "Atmos" } },
                { "Gletine", new List<string>{"100", "This metal is a dark brownish-gray in color and does not oxidate.  It is somewhat hard when solid and melts at 792 degrees Kelvin.  It is a good conductor of electricity and an excellent conductor of heat.", "Ignis Colony Ship" } },
                { "Blothil", new List<string>{"200", "This metal is iridescent dark gray in color and does not oxidate.  It is quite hard when solid and melts at 2215 degrees Kelvin.  It is an excellent conductor of electricity and an average conductor of heat.", "Ignis Colony Ship" } },
                { "Zastalt", new List<string>{"400", "This metal is a bluish-gray in color and does not oxidate.  It is quite soft when solid and melts at 2297 degrees Kelvin.  It is an excellent conductor of electricity and an excellent conductor of heat.", "Atmos" } }
            }));
        
            planetArray.Add(new Planet(2, "Specter Docks", 7, 4, new Dictionary<string, List<string>>
            {
                { "Fuel", new List<string>{"10" } },
                { "Gestrine", new List<string>{"500" } },
                { "Meslium", new List<string>{"200" } },
                { "Blothil", new List<string>{"500" } },
                { "Zastalt", new List<string>{"800" } }
            }));
            planetArray.Add(new Planet(3, "Ignis Colony Ship", 11, 6, new Dictionary<string, List<string>>
            {
                { "Fuel", new List<string>{"25" } },
                { "Gletine", new List<string>{"100" } },
                { "Gestrine", new List<string>{"400" } },
                { "Griolium", new List<string>{"200" } },
                { "Etril", new List<string>{"500" } },
                { "Blothil", new List<string>{"100" } }
            }));
            planetArray.Add(new Planet(4, "Concord", 7, 3, new Dictionary<string, List<string>>
            {
                { "Fuel", new List<string>{"20" } },
                { "Gletine", new List<string>{"200" } },
                { "Gestrine", new List<string>{"300" } },
                { "Griolium", new List<string>{"200" } },
                { "Etril", new List<string>{"200" } },
                { "Blothil", new List<string>{"50" } },
                { "Meslium", new List<string>{"100" } },
                { "Zastalt", new List<string>{"500", "This metal is a bluish-gray in color and does not oxidate.  It is quite soft when solid and melts at 2297 degrees Kelvin.  It is an excellent conductor of electricity and an excellent conductor of heat.", "Atmos" } }
            }));



        }

        public Planet GetPlanet(int planetID)
        {
            return planetArray.FirstOrDefault(planetOBJ => planetOBJ.planetID == planetID);
        }

        public List<Planet> GetPlanets()
        {
            return planetArray;
        }

    }
}

