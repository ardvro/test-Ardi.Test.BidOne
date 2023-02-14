using Ardi.Test.BidOne.Interfaces.Auth.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardi.Test.BidOne.Interfaces.Auth.Interfaces
{
    public interface IUserService
    {
        UserRegisterCode Register(UserRegistration userRegistration);

        List<User> GetUsers();

    }
}
