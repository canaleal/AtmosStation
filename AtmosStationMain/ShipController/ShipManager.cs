using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmosStationMain.ShipController
{
    class ShipManager
    {
        private List<Ship> shipArray = new List<Ship>();

        public ShipManager()
        {
            SetShip();
        }


        //shipID, capacity, travel, crew, tot fuel, strength, strengthBonus, damageKenetic, damageShield

        //Dictionary containg the ships
        public void SetShip()
        {
            //Speed Upgrades
            shipArray.Add(new Ship(1, 30, 5, 2, 20, 50, 1, 20, 15));
            shipArray.Add(new Ship(2, 20, 6, 2, 30, 40, 1, 20, 15));
            shipArray.Add(new Ship(3, 30, 7, 3, 30, 40, 1, 15, 10));

            //Higher Capacity
            shipArray.Add(new Ship(4, 40, 4, 2, 30, 50, 1, 20, 15));
            shipArray.Add(new Ship(5, 50, 3, 4, 35, 60, 1.2, 20, 15));
            shipArray.Add(new Ship(6, 60, 3, 5, 45, 60, 1.2, 25, 10));

            //More strength
            shipArray.Add(new Ship(7, 40, 4, 3, 25, 60, 1.3, 20, 15));
            shipArray.Add(new Ship(8, 40, 4, 4, 20, 70, 1.4, 25, 15));
            shipArray.Add(new Ship(9, 40, 2, 5, 15, 80, 1.6, 25, 20 ));
        }

        public Ship GetShip(int shipID)
        {
            return shipArray.FirstOrDefault(shipOBJ => shipOBJ.ShipID == shipID);
        }
    }
}
