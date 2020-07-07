using AtmosStationMain.ShipController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AtmosStationMain.AccountController
{
    [DataContract]
    class AccountEntity
    {

        //User details
        [DataMember]
        public string UserID { get; set; }
        [DataMember]
        public string UserPassword { get; set; }

        //Player stats
        [DataMember]
        public int CurrentLevel { get; set; }
        [DataMember]
        public int ShipType { get; set; }
        [DataMember]
        public int TotalScore { get; set; }
        [DataMember]
        public int TotalCredits { get; set; }
        [DataMember]
        public int CurrentFuel { get; set; }

        //Planet
        [DataMember]
        public int CurrentPlanet { get; set; }

        //Give the spaceship
        public Ship SpaceShip { get; set; }

        [DataMember]
        public List<string> ShipData = new List<string>();

        //Resources will start as null
        [DataMember]
        public Dictionary<string, List<string>> ResourcesDict { get; set; }

        public ShipManager ShipManager;

        public AccountEntity(string userID, string userPassword)
        {

            //Set the initial Data
            UserID = userID;
            UserPassword = userPassword;

            CurrentLevel = 0;
            ShipType = 1;
            TotalScore = 0;
            TotalCredits = 500;
            CurrentFuel = 20;
            CurrentPlanet = 1;

            //Spaceship
            ShipManager = new ShipManager();
            SpaceShip = ShipManager.GetShip(ShipType);
        }


        public void SetSpaceship()
        {
            ShipManager = new ShipManager();
            SpaceShip = ShipManager.GetShip(ShipType);
            //capacity, travel, crew, tot fuel, strength, strengthBonus, damageKenetic, damageShield
            if (ShipData.Count() == 8)
            {
                SpaceShip.Capacity = int.Parse(ShipData[0]);
                SpaceShip.Travel = int.Parse(ShipData[1]);
                SpaceShip.Crew = int.Parse(ShipData[2]);
                SpaceShip.TotalFuel = int.Parse(ShipData[3]);
                SpaceShip.Strength = int.Parse(ShipData[4]);
                SpaceShip.StrengthBonus = double.Parse(ShipData[5]);
                SpaceShip.DamageKenetic = int.Parse(ShipData[6]);
                SpaceShip.DamageShield = int.Parse(ShipData[7]);
                
            }
        }

        public void UpgradeShip(int index, int value)
        {
            ShipData[index] = value.ToString();
        }

         
    }
}
