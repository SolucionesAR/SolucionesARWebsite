using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.DataAccess.Interfaces
{
    public interface IUsersRepository
    {
        List<User> GetUsersList();

        void AddUser(User user);

        void EditUser(User user);
        
        User GetUser(int userId);

        User GetUserByCode(string username);

        bool UpdateUser(User user);

        void UpdateRelationship(int userId, int userReferenceId, int relationshipTypeId);
    }
}
