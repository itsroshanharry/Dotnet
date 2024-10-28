using DataAccess2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess2.Repository
{
    public class Repository:IRepository
    {
        private UserDetailDbContext context;

        public Repository()
        {
            context = new UserDetailDbContext();
        }

        public bool AddUser(UserDetail userDetail)
        {
            if (userDetail == null)
            {
                return false;
            }
            try
            {
                context.UserDetails.Add(userDetail);
                context.SaveChanges();
            } catch
            {
                return false;
            }
            return true;
        }

        public bool UpdateUser(UserDetail userDetail)
        {
            if (userDetail == null)
            {
                return false;
            }
            try
            {
                UserDetail temp = context.UserDetails.Find(userDetail.id);
                temp.FirstName = userDetail.FirstName;
                temp.LastName = userDetail.LastName;
                temp.EmailId = userDetail.EmailId;
                temp.Password = userDetail.Password;

                context.SaveChanges();
            } catch
            {
                return false;
            }
            return true;
        }

        public UserDetail getUserById(int id)
        {
            UserDetail user = null;
            try
            {
                user = context.UserDetails.Find(id);
            } catch
            {
                return null;
            }
            return user;
        }

        public List<UserDetail> getAllUsers()
        {
            return context.UserDetails.ToList();
        }
    }
}
