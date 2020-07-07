using AtmosStationMain.AccountController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmosStationMain.MainController
{
    class PassDataController
    {
        public AccountManager AccountManager { get; set; }
        public AccountEntity AccountEntity { get; set; }

        //Vriables that will be changed later
        public string ParameterSTR { get; set; }
        public int ParameterINT { get; set; }
        public float ParameterFLT { get; set; }
    }
}
