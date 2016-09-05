using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;


namespace DataAccess
{
    public class DataProvider
    {
        private string _ConnectionString = ConfigurationManager.AppSettings["Connectionstring"].ToString();

        public string ConnectionString
        {
            get { return _ConnectionString; }
            set { _ConnectionString = value; }
        }

        protected int ExecuteNonQuery(DbCommand Command)
        {
            return Command.ExecuteNonQuery();
        }

        protected DbDataReader ExecuteReader(DbCommand Command)
        {
            return Command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        protected object ExecuteScalar(DbCommand Command)
        {
            return Command.ExecuteScalar();
        }
    }
}
