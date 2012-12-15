using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.DataAccess.Interfaces
{
    public interface IUsersRepository
    {
        List<User> GetOrderedUsersList();

        List<User> GetUsersList();

        void AddUser(User user);

        void EditUser(User user);
        
        User GetUserById(int userId);

        User GetUserByGeneratedCode(string username);

        User GetSolucionesArUser();

        bool UpdateUser(User user);

        // void UpdateRelationship(int userId, int userReferenceId, int relationshipTypeId);   //TODO: quitando relations 
    }
}
