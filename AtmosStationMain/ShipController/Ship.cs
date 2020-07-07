using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmosStationMain.ShipController
{

    class Ship
    {
        public int ShipID { get; set; }
        public int Capacity { get; set; }
        public int Travel { get; set; }
        public int Crew { get; set; }
        public int TotalFuel { get; set; }
        public int Strength { get; set; }
        public double StrengthBonus { get; set; }
        
        public int DamageKenetic { get; set; }
        public int DamageShield { get; set; }

        public Ship(int shipID, int capacity, int travel, int crew, int totalFuel, int strength, double strengthBonus, int damageKenetic, int damageShield)
        {
            ShipID = shipID;
            Capacity = capacity;
            Travel = travel;
            Crew = crew;
            TotalFuel = totalFuel;
            Strength = strength;
            StrengthBonus = strengthBonus;
            DamageKenetic = damageKenetic;
            DamageShield = damageShield;
        }
    }
}
