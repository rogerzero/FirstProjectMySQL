using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProjectMySQL.Data
{
    class Connection
    {
        public static Database GetServerDatabaseInstances()
        {
            string dbport = string.Empty;
            if (Properties.Settings.Default.port != string.Empty)
                dbport = "," + Properties.Settings.Default.port;

            Database db = new Database(Database.ConnectionType.MySQL);
            db.ConnectionString = String.Format("Server={0}:{1};Database={3};Uid={4};Pwd={5};",
                Properties.Settings.Default.ipaddress,
                dbport,
                Properties.Settings.Default.schema,
                Properties.Settings.Default.user,
                Properties.Settings.Default.pwd);

            return db;
        }

        
    }
}
