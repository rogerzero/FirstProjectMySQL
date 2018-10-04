using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace FirstProjectMySQL
{
    
    class DatabaseClass
    {
        protected string cnstring;
        protected MySqlConnection con;

        public void OpenCon()
        {
            cnstring = "";
        }
    }
}
