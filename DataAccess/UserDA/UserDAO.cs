using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UserDA
{
    public class UserDAO
    {
        private static UserDAO instance;
        private static readonly object instanceLock = new object();
        public static UserDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new UserDAO();
                    return instance;
                }
            }
        }

        public IEnumerable<User> getUsers()
        {
            List<User> users = new List<User>();
            try
            {
                var context = new ffmlwpyhContext();
                users = context.Users.ToList();
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return users;
        }

        public User getUser(int id)
        {
            User user = null;
            try
            {
                var context = new ffmlwpyhContext();
                user = context.Users.SingleOrDefault(u => u.Id == id);
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return user;
        }

        public User validateEmail(string email, string password)
        {
            User user = null;
            try
            {
                var context = new ffmlwpyhContext();
                user = context.Users.SingleOrDefault(u => u.Email.Equals(email) && u.Password.Equals(password));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return user;
        }

        public User validateUser(string username, string password)
        {
            User user = null;
            try
            {
                var context = new ffmlwpyhContext();
                user = context.Users.SingleOrDefault(u => u.Username.Equals(username) && u.Password.Equals(password));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return user;
        }

        public int addUser(User user)
        {
            User _user = getUser(user.Id);
            if (_user == null)
            {
                try
                {
                    var context = new ffmlwpyhContext();
                    context.Users.Add(user);
                    context.SaveChanges();
                    return 1;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
                throw new Exception("User already exists!");
        }

        public int updateUser(User user)
        {
            User _user = getUser(user.Id);
            if (_user != null)
            {
                try
                {
                    var context = new ffmlwpyhContext();
                    context.Entry(user).State = EntityState.Modified;
                    context.SaveChanges();
                    return 1;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
                throw new Exception("User doesn't exist!");
        }

        public int deleteUser(User user)
        {
            User _user = getUser(user.Id);
            if (_user != null)
            {
                try
                {
                    var context = new ffmlwpyhContext();
                    context.Users.Remove(user);
                    context.SaveChanges();
                    return 1;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
                throw new Exception("User doesn't exist!");
        }
    }
}
