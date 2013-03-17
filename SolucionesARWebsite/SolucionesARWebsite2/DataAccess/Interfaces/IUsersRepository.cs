using System.Collections.Generic;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.DataAccess.Interfaces
{
    public interface IUsersRepository
    {
        List<User> GetOrderedUsersList();

        List<User> GetUsersList();

        void AddUser(User user);

        void EditUser(User user);

        User GetUserById(int userId);

        User GetUserByGeneratedCode(string username);

        User GetUserByIdentificationNumber(int identificationNumber);

        User GetSolucionesArUser();

        bool UpdateUser(User user);

        bool HasValidIdentificationNumber(int userId, int identificationNumber);

        void Delete(int userId);
    }
}
