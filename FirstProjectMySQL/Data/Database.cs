using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace FirstProjectMySQL
{
    public class Database
    {
        ConnectionType type;

        DbProviderFactory factory;

        DbConnection _connection;

        List<DbParameter> _parameter = new List<DbParameter>();

        List<DbParameter> _where = new List<DbParameter>();

        string sql_select = string.Empty;
        string sql_from = string.Empty;
        string sql_where = string.Empty;
        string sql_join = string.Empty;
        string sql_other = string.Empty;

        bool start_select = false;
        bool start_from = false;
        bool start_where = false;

        public enum ConnectionType
        {
            SQLClient,
            ODBC,
            MySQL
        }

        public Database(ConnectionType type) : this(type, null)
        {

        }

        public Database(ConnectionType type, string connectionstring)
        {
            this.type = type;
            if (type == ConnectionType.SQLClient)
            {
                factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            }
            else if (type == ConnectionType.ODBC)
            {
                factory = DbProviderFactories.GetFactory("System.Data.ODBC");
            }
            else if (type == ConnectionType.MySQL)
            {
                factory = DbProviderFactories.GetFactory("MySQL.Data");
            }

            if ((connectionstring != null))
            {
                this.ConnectionString = connectionstring;
            }
        }

        public string ConnectionString
        {
            get { return this._connection.ConnectionString; }
            set
            {
                this._connection = this.factory.CreateConnection();
                this._connection.ConnectionString = value;
            }
        }

        public DbConnection Connection
        {
            get { return this._connection; }
        }

        public DbCommand Command
        {
            get { return factory.CreateCommand(); }
        }

        public DataTable DbQuery(string commandtext)
        {
            return this.DbQuery(commandtext, false);
        }

        public DataTable DbQuery(string commandtext, bool returnresult)
        {
            DataTable dt = null;
            DbCommand command = this.Command;
            command.Connection = this.Connection;
            command.CommandText = commandtext;

            if (this._parameter.Count > 0)
            {
                command.Parameters.AddRange(this._parameter.ToArray());
            }
            if (this._where.Count > 0)
            {
                command.Parameters.AddRange(this._where.ToArray());
            }

            try
            {
                if (!returnresult)
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
                else
                {
                    dt = new DataTable();
                    DbDataAdapter da = factory.CreateDataAdapter();
                    da.SelectCommand = command;
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                if (command.Connection.State == ConnectionState.Open)
                {
                    command.Connection.Close();
                }
                this.ResetSQL();
                throw new Exception("Database Error" + ex.Message);
            }
            this.ResetSQL();
            return dt;

        }

        public void DbInsert(string table)
        {
            if (this._parameter.Count == 0)
                throw new Exception("No Paramater is given");

            string columns = string.Empty;
            string values = string.Empty;

            foreach (DbParameter parameter in _parameter)
            {
                if (columns != string.Empty)
                {
                    columns += ",";
                    values += ",";
                }

                columns += parameter.ParameterName.Substring(1);
                values += parameter.ParameterName;
            }
            DbCommand command = this.Command;
            command.Connection = this.Connection;
            command.CommandText = "INSERT INTO " + table + "(" + columns + ") VALUES (" + values + ")";
            command.Parameters.AddRange(_parameter.ToArray());

            try
            {
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
            catch (Exception ex)
            {
                if (command.Connection.State == ConnectionState.Open)
                    command.Connection.Close();

                this.ResetSQL();
                throw new Exception("Database error: " + ex.Message);
            }

            this.ResetSQL();

        }

        public void DBUpdate(string table)
        {
            if (this._parameter.Count == 0)
                throw new Exception("No parameter is given");

            string sets = string.Empty;

            // Prepare columns and values
            foreach (DbParameter param in _parameter)
            {
                if (sets != string.Empty) sets += ", ";

                string param_name = param.ParameterName;

                sets += (param_name.Substring(1) + "=" + param_name);
            }

            DbCommand command = this.Command;
            command.Connection = this.Connection;
            command.CommandText = "UPDATE " + table + " SET " + sets + sql_where;
            command.Parameters.AddRange(_parameter.ToArray());
            if (this._where.Count > 0)
                command.Parameters.AddRange(_where.ToArray());

            try
            {
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
            catch (Exception ex)
            {
                if (command.Connection.State == ConnectionState.Open)
                    command.Connection.Close();

                this.ResetSQL();
                throw new Exception("Database error: " + ex.Message);
            }

            this.ResetSQL();
        }

        public void DBDelete(string table)
        {
            DbCommand command = this.Command;
            command.Connection = this.Connection;
            command.CommandText = "DELETE FROM " + table + sql_where;
            if (this._where.Count > 0)
                command.Parameters.AddRange(_where.ToArray());

            try
            {
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
            catch (Exception ex)
            {
                if (command.Connection.State == ConnectionState.Open)
                    command.Connection.Close();

                this.ResetSQL();
                throw new Exception("Database error: " + ex.Message);
            }

            this.ResetSQL();
        }

        public void AddParameter(string column, object value)
        {
            DbParameter param = factory.CreateParameter();
            param.ParameterName = "@" + column;
            param.Value = value;
            this._parameter.Add(param);
        }

        public DataTable GetResult()
        {
            return DbQuery(this.SQL, true);
        }

        public string SQL
        {
            get { return sql_select + sql_from + sql_join + sql_where + sql_other; }
        }

        public void InsertSelect(string column)
        {
            if (this.sql_select == string.Empty)
            {
                this.sql_select += "SELECT ";
            }

            if (this.start_select)
            {
                this.sql_select += ", ";
            }

            this.sql_select += column;

            start_select = true;

        }

        public void InsertFrom(string table)
        {
            if (this.sql_from == string.Empty)
            {
                this.sql_from += " FROM ";
            }

            if (this.start_from)
            {
                this.sql_from += ", ";
            }

            this.sql_from += table;

            start_from = true;
        }

        private void CheckWhere()
        {
            if (this.sql_where == string.Empty)
            {
                this.sql_where += " WHERE ";
            }

            if (this.start_where)
            {
                this.sql_where += " AND ";
            }
        }

        public void InsertWhere(string constraint, string op, object value)
        {
            CheckWhere();

            string param_name;
            if (constraint.IndexOf('.') != -1)
            {
                param_name = constraint.Replace('.', '_');
                this.sql_where += (constraint + op + " @" + param_name);
            }
            else
            {
                param_name = constraint;
                this.sql_where += ("[" + constraint + "] " + op + " @" + param_name);
            }

            DbParameter param = factory.CreateParameter();
            param.ParameterName = "@" + param_name;
            param.Value = value;
            this._where.Add(param);

            start_where = true;
        }

        public void insertJoin(string table, string joinOn)
        {
            this.sql_join += (" INNER JOIN " + table + " ON " + joinOn);
        }

        public void insertOther(string text)
        {
            this.sql_other += (" " + text);
        }

        public void ResetSQL()
        {
            this.sql_select = string.Empty;
            this.sql_from = string.Empty;
            this.sql_where = string.Empty;
            this.sql_join = string.Empty;
            this.sql_other = string.Empty;

            this.start_select = false;
            this.start_from = false;
            this.start_where = false;

            this._parameter.Clear();
            this._where.Clear();
        }
    }
}
