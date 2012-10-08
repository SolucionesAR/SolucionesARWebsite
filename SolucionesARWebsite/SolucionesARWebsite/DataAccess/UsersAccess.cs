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
            var users = db.Users.ToList();
            List<User> usersList = new List<User>();
            foreach (var user in users)
            {
                
            }
            return usersList;
        } 
    }
}