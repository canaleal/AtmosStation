using AtmosStationMain.AccountController;
using AtmosStationMain.ImageController;
using AtmosStationMain.ItemController;
using AtmosStationMain.MainController;
using AtmosStationMain.ShipController;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace AtmosStationMain
{

    public sealed partial class MGalaxyPage : Page
    {

        //This is the passed data and game controller
        PassDataController passedData;
        AccountManager accountManager;
        AccountEntity accountEntity;

        //Planet
        PlanetManager planetManager = new PlanetManager();
        int selectedPlanet = 0;
        int multiplier;

        public MGalaxyPage()
        {
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Set the data from the passed information
            passedData = e.Parameter as PassDataController;
            accountManager = passedData.AccountManager;
            accountEntity = passedData.AccountEntity;

            playerFuelLbl.Text = "Fuel : " + accountEntity.CurrentFuel.ToString();
            SetList();
        }


        public void SetList()
        {
            List<Planet> planets = planetManager.GetPlanets();
            foreach (Planet planet in planets)
            {
                planetLs.Items.Add(planet.planetID.ToString() + " : " + planet.name);
            }

        }


        private void ButtonManager(object sender, TappedRoutedEventArgs e)
        {

            switch ((sender as Border).Name)
            {
                case "backBrd":
                    Frame.Navigate(typeof(GamePage), passedData);
                    break;

                case "nextBrd":
                    Travel();
                    break;

                default: break;
            }

        }

        private void ListView1_ItemClick(object sender, ItemClickEventArgs e)
        {
            string key = e.ClickedItem.ToString().Split(':')[0];
            int keyTemp = int.Parse(key.Replace(" ", ""));

            if (keyTemp != selectedPlanet & keyTemp !=0)
            {
                brdL.Margin = new Thickness(0, 0, 0, 0);
                brdT.Margin = new Thickness(0, 0, 0, 0);
                AnimationCaller(keyTemp);
            }

            selectedPlanet = keyTemp;  
        }

        private void Travel()
        {
            if (selectedPlanet != 0)
            {
               
                if (multiplier <= accountEntity.CurrentFuel)
                {
                    accountEntity.CurrentFuel -= multiplier;
                    accountEntity.CurrentPlanet = selectedPlanet;
                    Frame.Navigate(typeof(GamePage), passedData);
                }    
            }
        }

        private async void AnimationCaller(int key, int v = 1)
        {
            Planet planet1 = planetManager.GetPlanet(accountEntity.CurrentPlanet);
            Planet planet2 = planetManager.GetPlanet(key);   
            multiplier = Convert.ToInt32(Math.Sqrt(Math.Abs(planet1.coord[0] - planet2.coord[0]) * 2 + Math.Abs(planet1.coord[1] - planet2.coord[1]) * 2));
            fuelLbl.Text = "Fuel Cost : " + multiplier.ToString();
            AnimationFrd(brdL, planet2.coord[0], 0);
            AnimationFrd(brdT, planet2.coord[1], 1);
            await Task.Delay(TimeSpan.FromSeconds(2));
        }

        private async void AnimationFrd(Border brd, int v, int xy)
        {  
            for (int i = 0; i < v; i++)
            {
                if (xy == 0)
                {
                    brd.Margin = new Thickness( i * 100, 0, 0, 0);
                }
                else
                {
                    brd.Margin = new Thickness(0, i * 100, 0, 0);
                }               
                await Task.Delay(TimeSpan.FromSeconds(0.005));
            }
            await Task.Delay(TimeSpan.FromSeconds(1));
        } 
    }
}
