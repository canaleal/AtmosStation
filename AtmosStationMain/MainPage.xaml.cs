using AtmosStationMain.AccountController;
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


namespace AtmosStationMain
{

    public sealed partial class MainPage : Page
    {
        //1 = Login, 2 = SignUp
        int setOption = 1;
        private AccountManager AccountManager = new AccountManager();
        private MessageManager MessageManager = new MessageManager();

        public MainPage()
        {
            InitializeComponent();
        }


        private void ButtonManager(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Name)
            {

                case "MainBtn":
                    SetupOption(setOption);
                    break;

                case "ShowBtn":
                    ChangeMenu();
                    break;

                default: break;
            }
        }

        private void ChangeMenu()
        {

            TextBlock txt = FindName("titleMain") as TextBlock;
            Button btn = FindName("MainBtn") as Button;
            if (setOption == 1)
            {
                txt.Text = "Sign Up";
                btn.Content = "Sign Up";
                ShowBtn.Content = "Login";
                setOption = 2;
            }
            else
            {
                txt.Text = "Login";
                btn.Content = "Login";
                ShowBtn.Content = "Sign Up";
                setOption = 1;
            }
        }

        private Tuple<string, string, bool> GetData()
        {
            return Tuple.Create(userIDTxt.Text, userPassTxt.Password, (string.IsNullOrEmpty(userIDTxt.Text) || string.IsNullOrEmpty(userPassTxt.Password)) ? false : true);
        }

        private void SetupOption(int Option)
        {
            Tuple<string, string, bool> data = GetData();

            Debug.WriteLine(data.Item1);
            if (data.Item3 == true)
            {
                if (Option == 1)
                {
                    if (AccountManager.CheckAccountExists(data.Item1, data.Item2) == true)
                    {
                        AccountEntity account = AccountManager.GetAccount(data.Item1, data.Item2);
                        account.SetSpaceship();
                        Frame.Navigate(typeof(GamePage), new PassDataController { AccountManager = AccountManager, AccountEntity = account });
                    }
                    else
                    {
                        MessageManager.GameDialog("Sorry, the account doesn't exist.");
                    }

                }
                else if (Option == 2)
                {
                    if (AccountManager.AddAccount(data.Item1, data.Item2) == false)
                    {
                        MessageManager.GameDialog("The User ID is already in use.");
                    }
                }

            }
            else
            {
                MessageManager.GameDialog("Missing inputs in the required fields.");
            }
        }


    }
}
