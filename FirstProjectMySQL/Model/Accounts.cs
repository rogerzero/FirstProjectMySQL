using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProjectMySQL.Model
{
    class Accounts : Base
    {
        public Accounts()
        {
            
        }

        public struct AccountData
        {
            public string id;
            public string username;
            public string password;
        }

        public override void LoadData()
        {
            this.table = db.DbQuery("SELECT * FROM tbl_accounts WHERE id > 1 ORDER BY username ASC", true);
        }

        public void AddAccountData(AccountData data)
        {
            db.AddParameter("username", data.username);
            db.AddParameter("password", data.password);
            db.AddParameter("created_date", DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss"));
            db.DbInsert("accounts");
        }
    }
}
