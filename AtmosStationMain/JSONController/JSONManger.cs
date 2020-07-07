using AtmosStationMain.AccountController;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace AtmosStationMain.JSONController
{
    class JSONManger
    {


        private readonly string FileName = ApplicationData.Current.RoamingFolder.Path + "\\" + "AtmosAccounts.json";
        private DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<AccountEntity>));

        //Save all the accounts to the roaming folder
        public void Store(List<AccountEntity> userList)
        {
            try
            {
                using (FileStream fileStream = new FileStream(FileName, FileMode.Create))
                {
                    serializer.WriteObject(fileStream, userList);
                }
            }
            catch (FileNotFoundException)
            {
               
            }
        }

        //Load the accounts from the JSON file location. Either an empty list is returned or all the accounts.
        public List<AccountEntity> Load()
        {
            List<AccountEntity> accounts = null;
            try
            {
                using (FileStream fileStream = new FileStream(FileName, FileMode.Open))
                {
                    accounts = (List<AccountEntity>)serializer.ReadObject(fileStream);
                }
              
                return accounts;
            }
            catch (FileNotFoundException)
            {
                accounts = new List<AccountEntity>();
                return accounts;
            }
        }
    }
}
