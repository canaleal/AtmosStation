using AtmosStationMain.JSONController;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmosStationMain.AccountController
{
    class AccountManager
    {

        internal List<AccountEntity> UserList { get; set; }
        private JSONManger handler = new JSONManger();

        //Load in the file
        public AccountManager()
        {
            UserList = new List<AccountEntity>();

            try
            {
                UserList = handler.Load();   
            }
            catch (FileNotFoundException)
            {
                
            }
        }

        /// <summary>
        /// Update the file
        /// </summary>
        public void UpdateAccount() => handler.Store(UserList);


        public bool CheckAccountExists(string userID, string userPassword)
        {
            return UserList.Any(accountOBJ => accountOBJ.UserID == userID && accountOBJ.UserPassword == userPassword) ? true : false;
        }

        public bool AddAccount(string userID, string userPassword)
        {
            //Check if the tile already exists
            if (UserList.Any(account => account.UserID == userID) == false)
            {
                UserList.Add(new AccountEntity(userID, userPassword));
                handler.Store(UserList);

                return true;
            }
            else
            {
                return false;
            }

        }

      
        public AccountEntity GetAccount(string userID, string userPassword)
        {
            return UserList.Any(accountOBJ => accountOBJ.UserID == userID && accountOBJ.UserPassword == userPassword) ? UserList.FirstOrDefault(accountOBJ => accountOBJ.UserID == userID && accountOBJ.UserPassword == userPassword) : null;
        }

    }
}

