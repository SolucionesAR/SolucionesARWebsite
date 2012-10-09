using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.DataAccess
{
    public class UsersAccess
    {
        private DbModel db = new DbModel();

        public List<User> GetUsers()
        {
            List<User> users = db.Users.ToList();
            return users;
        } 
    }
}