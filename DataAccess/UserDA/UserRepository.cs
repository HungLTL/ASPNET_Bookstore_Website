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
        public void addUser(User user) => UserDAO.Instance.addUser(user);

        public void deleteUser(User user) => UserDAO.Instance.deleteUser(user);

        public User getUser(int id) => UserDAO.Instance.getUser(id);

        public IEnumerable<User> getUsers() => UserDAO.Instance.getUsers();

        public void updateUser(User user) => UserDAO.Instance.updateUser(user);

        public User validateEmail(string email, string password) => UserDAO.Instance.validateEmail(email, password);

        public User validateUser(string username, string password) => UserDAO.Instance.validateUser(username, password);
    }
}
