using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace FirstProjectMySQL.Model
{
    public abstract class Base
    {
        protected Database db;
        protected DataTable table;

        public Base()
        {
            db = Data.Connection.GetServerDatabaseInstances();

        }

        public DataTable GetList()
        {
            return this.GetList(null);
        }

        public DataTable GetList(string filter)
        {
            if (filter != null)
            {
                System.Data.DataView view = new System.Data.DataView(this.table);
                view.RowFilter = filter;
                return view.ToTable();
            }
            else
            {
                return this.table;
            }
        }
        public abstract void LoadData();
    }
}
