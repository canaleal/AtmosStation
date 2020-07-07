using AtmosStationMain.AccountController;
using AtmosStationMain.ImageController;
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

    
    public sealed partial class GamePage : Page
    {
        //This is the passed data and game controller
        PassDataController passedData;
        AccountManager accountManager;
        AccountEntity accountEntity;

        //Controll all the pictues
        ImageManager imageManager;

        //Used to check clickable
        bool isClick = true;

        public GamePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Set the data from the passed information
            passedData = e.Parameter as PassDataController;
            accountManager = passedData.AccountManager;
            accountEntity = passedData.AccountEntity;

            //Set user data
            SetLabels();

            //Set the game images such as spaceship and planet
            SetImages();

        }

        public void SetLabels()
        {
        
            userLvlLbl.Text = "Level: " + accountEntity.CurrentLevel.ToString();
            creditsLbl.Text = accountEntity.TotalCredits.ToString() + " Cr";
        }

        public void SetImages()
        {
            //Create a new instance
            imageManager = new ImageManager();

            //Set the images for both elements
            int shipT = accountEntity.ShipType;
            //int shipT = 10;
            if (shipT < 5)
            {
                SetShipImage(75, 75);
            }
            else if(shipT < 8)
            {
                SetShipImage(112, 112);
            }
            else if(shipT<10)
            {
                SetShipImage(225, 225);
            }
            else
            {
                SetShipImage(300, 300);             
            }


            shipImg.Source = imageManager.GetSpaceShip(shipT);
            planetImg.Source = imageManager.GetPlanet(accountEntity.CurrentPlanet);

        }

        private void SetShipImage(int x, int y)
        {
            shipImg.Height = x;
            shipImg.Width = y;
        }



        private void ButtonManager(object sender, TappedRoutedEventArgs e)
        {
            if(isClick == true)
            {
                switch ((sender as Border).Name)
                {
                    case "resourceBrd":
                        Frame.Navigate(typeof(MResourcePage), passedData);
                        break;

                    case "navigateBrd":
                        Frame.Navigate(typeof(MGalaxyPage), passedData);
                        break;

                    case "landBrd":
                        LandAnimationAsync();
                        break;

                    case "leaveBrd":
                        accountManager.UpdateAccount();
                        Application.Current.Exit();
                        break;

                    default: break;
                }
            }        
        }


        private async void LandAnimationAsync()
        {
            isClick = false;
            for(int i=0; i<70; i++)
            {
                shipImg.Margin = new Thickness(0, 0, 0, i*10);
                await Task.Delay(TimeSpan.FromSeconds(0.001));
            }
            isClick = true;
            
            Frame.Navigate(typeof(MResourcePage), passedData);
        }
    }


}
