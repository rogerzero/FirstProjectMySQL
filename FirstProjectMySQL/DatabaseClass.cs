using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace FirstProjectMySQL
{
    
    public class DatabaseClass
    {
        protected static string srvlink;
        protected static MySqlConnection srvconnection;
        protected static MySqlCommand sqlcommand;
        protected static MySqlDataReader sqldata;
        protected static MySqlDataAdapter sqladapter;


        public static void OpenCon()
        {
            srvlink = "Server=127.0.0.1;Port=3306;Database=mysqlproject;Uid=root;Pwd=root123;";
            srvconnection = new MySqlConnection(srvlink);
            srvconnection.Open();
        }

        public static void CloseCon()
        {
            srvconnection.Close();
            srvlink = string.Empty;
        }

        public static string ExecSQL(string column, string table, string condition) 
        {
            OpenCon();
            string sql = "SELECT " + column + " FROM " + table + " WHERE " + condition + "";
            sqlcommand = new MySqlCommand(sql, srvconnection);
            string username = (string)sqlcommand.ExecuteScalar();
            return username;
        }

        public static void InsertSQL(string table, string column, string data)
        {
            
            OpenCon();
            string sql = "INSERT INTO " + table + " (" + column + ") VALUES (" + data + ")";
            sqlcommand = new MySqlCommand(sql , srvconnection);
            sqladapter = new MySqlDataAdapter();
            sqladapter.InsertCommand = sqlcommand;
            sqladapter.InsertCommand.ExecuteNonQuery();
            sqlcommand.Dispose();
            CloseCon();

        }
        
    }
}
