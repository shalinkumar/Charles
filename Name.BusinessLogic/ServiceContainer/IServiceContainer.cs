using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businesslogic.ServiceContainer
{
    public interface IServiceContainer
    {
        bool ValidateApplicationUser(string userName, string password);
    }
}
