using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businesslogic.ServiceContainer
{
    public class ServiceContainer : IServiceContainer
    {

        public bool ValidateApplicationUser(string userName, string password)
        {
            User objUser = new User(userName, password);
            bool resultUser = objUser.ValidateUser();
            return resultUser;
        }
    }
}
