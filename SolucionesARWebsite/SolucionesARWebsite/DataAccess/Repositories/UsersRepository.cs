using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SolucionesARWebsite.DataAccess.Interfaces;
using SolucionesARWebsite.Enumerations;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly DbModel _databaseModel;

        #endregion

        #region Contructors

        public UsersRepository()
        {
            _databaseModel = new DbModel();
        }

        #endregion

        #region Public Methods

        public void AddUser(User user)
        {
            _databaseModel.Users.Add(user);
            _databaseModel.SaveChanges();
        }

        public void EditUser(User user)
        {
            _databaseModel.Entry(user).State = EntityState.Modified;
            _databaseModel.SaveChanges();
        }
        
        public List<User> GetUsersList()
        {
            var users = _databaseModel.Users.ToList();
            return users;
        }

        public User GetUser(int userId)
        {
            var user = _databaseModel.Users.FirstOrDefault(u => u.UserId.Equals(userId));
            return user;
        }

        public User GetUserByCode(string username)
        {
            var user = _databaseModel.Users.FirstOrDefault(u => u.GeneratedCode.Equals(username)) ??
                       _databaseModel.Users.FirstOrDefault(u => u.UserId.Equals(Constants.SolucionesArId));
            return user;
        }

        public User GetUserByName(string username)
        {
            var user = _databaseModel.Users.FirstOrDefault(u => u.FName.Equals(username));
            return user;
        }

        public bool UpdateUser(User user)
        {
            _databaseModel.Entry(user).State = EntityState.Modified;
            _databaseModel.SaveChanges();
            return true;
        }

        public void UpdateRelationship(int userId, int userReferenceId, int relationshipTypeId)
        {
            var relationship =
                _databaseModel.Relationships.FirstOrDefault(
                    r => r.UserId1.Equals(userId) && r.UserId2.Equals(userReferenceId));
            if (relationship != null)
            {
                relationship.UserId2 = userReferenceId;
                relationship.RelationshipTypeId = relationshipTypeId;
                relationship.UpdatedAt = DateTime.Now;
            }
            else
            {
                relationship = new Relationship
                                   {
                                       UserId1 = userId,
                                       UserId2 = userReferenceId,
                                       RelationshipTypeId = relationshipTypeId,
                                       CreatetedAt = DateTime.Now,
                                       UpdatedAt = DateTime.Now,
                                   };
                _databaseModel.Relationships.Add(relationship);
            }
            _databaseModel.SaveChanges();
        }

        #endregion

        #region Private Methods
        #endregion
    }
}