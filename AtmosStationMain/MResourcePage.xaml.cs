using AtmosStationMain.AccountController;
using AtmosStationMain.ItemController;
using AtmosStationMain.MainController;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AtmosStationMain
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MResourcePage : Page
    {

        //This is the passed data and game controller
        PassDataController passedData;
        AccountManager accountManager;
        AccountEntity accountEntity;
       

        PlanetManager planetManager = new PlanetManager();


        public MResourcePage()
        {
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Set the data from the passed information
            passedData = e.Parameter as PassDataController;
            accountManager = passedData.AccountManager;
            accountEntity = passedData.AccountEntity;

            SetList();
        }

        
        public void SetList()
        {
            //Test
            //Planet planet = planetManager.GetPlanet(1);
            //accountEntity.ResourcesDict = planet.resources;
          
            bool flagData = false;
            if (accountEntity.ResourcesDict != null)
            {
                if (accountEntity.ResourcesDict.Count() != 0)
                {
                    //Not empty
                    foreach (KeyValuePair<string, List<string>> item in accountEntity.ResourcesDict)
                    {    
                        resources.Items.Add(item.Value[0] + ": " + item.Key);
                    }
                }
                else
                {
                    flagData = true;
                }
            }
            else
            {
                flagData = true;
            }
            


            if (flagData == true)
            {
                resources.Items.Add("WARNING: No Resources!");
            }    
        }


        private void ListView1_ItemClick(object sender, ItemClickEventArgs e)
        {
            

            if (accountEntity.ResourcesDict != null)
            {
                string key = e.ClickedItem.ToString().Split(' ')[1];
                titleMain.Text = key;
                List<string> value = accountEntity.ResourcesDict[key];
                if (value.Count > 1)
                {
                    creditLbl.Text = "Value: " + value[0] + " Cr";
                    descLbl.Text = "Description: " + value[1];
                    locationLbl.Text = "Found at: " + value[2];
                }
                else
                {
                    creditLbl.Text = "Value: " + value[0] + " Cr";
                    descLbl.Text = "Description: N/A";
                    locationLbl.Text = "Found at: N/A";
                }
            }
           
            
        }

        private void ButtonManager(object sender, TappedRoutedEventArgs e)
        {
            switch ((sender as Border).Name)
            {
                case "backBrd":
                    Frame.Navigate(typeof(GamePage), passedData);
                    break;
  
                default: break;
            }
        }
    }
}
