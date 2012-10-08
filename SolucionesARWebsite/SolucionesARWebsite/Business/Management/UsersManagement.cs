using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SolucionesARWebsite.DataAccess;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.Business.Management
{
    public class UsersManagement
    {
        private UsersAccess _usersAccess;

        public UsersManagement()
        {
            _usersAccess = new UsersAccess();
        }

        public List<User> GetUsers()
        {
            return _usersAccess.GetUsers();
        }
    }
}