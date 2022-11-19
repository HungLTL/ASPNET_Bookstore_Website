using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UserDA
{
    public interface IUserRepository
    {
        IEnumerable<User> getUsers();
        User getUser(int id);
        User validateUser(string username, string password);
        User validateEmail(string email, string password);
        int addUser(User user);
        int updateUser(User user);
        int deleteUser(User user);
    }
}
