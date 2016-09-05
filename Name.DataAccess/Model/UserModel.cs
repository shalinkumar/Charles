using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class UserModel
    {
        #region Public Properties      

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
      
        #endregion

        #region Constructor

        public UserModel()
        {

        }

        public UserModel(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }

        public UserModel(string firstName)
        {
            this.FirstName = firstName;
        }
        public UserModel(int id)
        {
            this.Id = id;
        }
        #endregion
    }
}
