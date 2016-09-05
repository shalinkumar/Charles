using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DataAccess
{
    public class UserDataProvider: DataProvider
    {
        private static UserDataProvider _Instance;

        public static UserDataProvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = (UserDataProvider)Activator.CreateInstance(typeof(UserDataProvider));
                }
                return _Instance;
            }
        }


        #region User

   
        public List<UserModel> GetAllUser()
        {


            using (SqlConnection Connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand Command = new SqlCommand("Usp_writeyours", Connection);
                Command.CommandType = CommandType.StoredProcedure;
                Connection.Open();
                return GetUserCollectionFromReader(Command.ExecuteReader());
            }

        }

        public bool ValidateUser(UserModel myObject)
        {
            object Result;
            bool Res = false;

            using (SqlConnection Connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand Command = new SqlCommand("Usp_writeyours", Connection);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Add("@UserName", SqlDbType.Char).Value = myObject.UserName;
                Command.Parameters.Add("@Password", SqlDbType.Char).Value = myObject.Password;
                Connection.Open();
                Result = Command.ExecuteScalar();
                if (Convert.ToInt32(Result) == 1)
                {
                    Res = true;
                }
                else
                {
                    Res = false;
                }
            }

            return Res;
        }

        public List<UserModel> GetUserById(UserModel model)
        {
            using (SqlConnection Connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand Command = new SqlCommand("Usp_writeyours", Connection);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Add("@Id", SqlDbType.NVarChar).Value = model.Id;
                Connection.Open();
                return GetUserCollectionFromReader(Command.ExecuteReader());
            }
        }

   
        public int InsertUser(UserModel model)
        {

            using (SqlConnection Connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand Command = new SqlCommand("Usp_writeyours", Connection);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Add("@UserName", SqlDbType.Int).Value = model.UserName;
                Command.Parameters.Add("@Password", SqlDbType.Int).Value = model.Password;
                Command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = model.FirstName;           
                Connection.Open();
                return ExecuteNonQuery(Command);
            }

        }

     
        public int UpdateUser(UserModel model)
        {

            using (SqlConnection Connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand Command = new SqlCommand("Usp_writeyours", Connection);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Add("@UserName", SqlDbType.Int).Value = model.UserName;
                Command.Parameters.Add("@Password", SqlDbType.Int).Value = model.Password;
                Command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = model.FirstName;
                Connection.Open();
                return ExecuteNonQuery(Command);
            }

        }

     
        public int DeleteUser(string id)
        {

            using (SqlConnection Connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand Command = new SqlCommand("Usp_writeyours", Connection);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Add("@Id", SqlDbType.NVarChar).Value = id;
                Connection.Open();
                return ExecuteNonQuery(Command);
            }

        }

      
        #endregion

        #region Private Methods

      public List<UserModel> GetUserCollectionFromReader(SqlDataReader reader)
        {

            List<UserModel> UserModelInfo = new List<UserModel>();
            while (reader.Read())
            {
                UserModelInfo.Add(GetUserModelFromReader(reader));
            }
            return UserModelInfo;
        }

        private UserModel GetUserModelFromReader(DbDataReader reader)
        {

            if (reader.HasRows)
            {
                return new UserModel(reader["CodeId"] == DBNull.Value ? 0 : ((int)reader["CodeId"]));
            }
            return null;

        }

        #endregion
    }
}
