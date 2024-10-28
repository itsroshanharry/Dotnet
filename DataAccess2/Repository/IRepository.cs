using DataAccess2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess2.Repository
{
    public interface IRepository
    {
        public bool AddUser(UserDetail userDetail);
        public bool UpdateUser(UserDetail userDetail);
        public UserDetail getUserById(int id);
        public List<UserDetail> getAllUsers();

    }
}
