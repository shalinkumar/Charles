using DataAccess;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businesslogic
{
    public class User
    {
        #region Public Properties      

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }

        #endregion

        #region Constructor

        public User()
        {

        }

        public User(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }

        public User(string firstName)
        {
            this.FirstName = firstName;
        }
        public User(int id)
        {
            this.Id = id;
        }
        #endregion

        #region Public Methods
        public bool ValidateUser()
        {
            bool res = false;
            UserModel MyUser = new UserModel(this.UserName, this.Password);
            return UserDataProvider.Instance.ValidateUser(MyUser);
            //return res;
        }

        public List<UserModel> GetUserById()
        {
            UserModel MyUser = new UserModel(this.Id);
            return UserDataProvider.Instance.GetUserById(MyUser);
        }


        #endregion
    }
}
