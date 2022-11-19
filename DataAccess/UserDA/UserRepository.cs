using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UserDA
{
    public class UserRepository : IUserRepository
    {
        public int addUser(User user) => UserDAO.Instance.addUser(user);

        public int deleteUser(User user) => UserDAO.Instance.deleteUser(user);

        public User getUser(int id) => UserDAO.Instance.getUser(id);

        public IEnumerable<User> getUsers() => UserDAO.Instance.getUsers();

        public int updateUser(User user) => UserDAO.Instance.updateUser(user);

        public User validateEmail(string email, string password) => UserDAO.Instance.validateEmail(email, password);

        public User validateUser(string username, string password) => UserDAO.Instance.validateUser(username, password);
    }
}
