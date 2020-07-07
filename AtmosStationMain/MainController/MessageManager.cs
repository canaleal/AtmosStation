using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace AtmosStationMain.MainController
{
    class MessageManager
    {
        public async void GameDialog(string message)
        {
            await new ContentDialog()
            {
                Title = message,
                CloseButtonText = "Ok"
            }.ShowAsync();
        }
    }
}
