using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace AtmosStationMain.ImageController
{
    class ImageManager
    {

        public BitmapImage GetSpaceShip(int shipType)
        {
            return new BitmapImage(new Uri("ms-appx:///Assets/img-ships/Atmos-Ship-" + shipType.ToString() + ".png"));
        }

        public BitmapImage GetPlanet(int planetID)
        {
            return new BitmapImage(new Uri("ms-appx:///Assets/img-planets/Atmos-Planet-" + planetID.ToString() + ".png"));
        }

        public BitmapImage GetPlanetLand(int planetID)
        {
            return new BitmapImage(new Uri("ms-appx:///Assets/img-planets/Atmos-Planet-Land-" + planetID.ToString() + ".png"));
        }

    }
}
