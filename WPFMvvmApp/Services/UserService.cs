using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMvvmApp.Services;
public class UserService : IUserService
{
    public IEnumerable<string> GetUsers()
    {
        return new string[]
        {
            "User 1",
            "User 2",
            "User 3",
            "User 4",
        };
    }
}
