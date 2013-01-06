using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SolucionesARWebsite2.DataAccess.Interfaces;
using SolucionesARWebsite2.Enumerations;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.DataAccess.Repositories
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

        public List<User> GetOrderedUsersList()
        {
            var users = _databaseModel.Users.OrderBy(u => u.GeneratedCode).ToList();
            return users;
        }
        
        public List<User> GetUsersList()
        {
            var users = _databaseModel.Users.ToList();
            return users;
        }

        public User GetUserById(int userId)
        {
            var user = _databaseModel.Users.FirstOrDefault(u => u.UserId.Equals(userId));
            return user;
        }

        public User GetUserByGeneratedCode(string username)
        {
            var user = _databaseModel.Users.FirstOrDefault(u => u.GeneratedCode.Equals(username));
            return user;
        }

        public User GetSolucionesArUser()
        {
            var user = GetUserById((int) Constants.SolucionesArUser);
            return user;
        }

        public bool UpdateUser(User user)
        {
            _databaseModel.Entry(user).State = EntityState.Modified;
            _databaseModel.SaveChanges();
            return true;
        }

        /*    public void UpdateRelationship(int userId, int userReferenceId, int relationshipTypeId)//TODO: quitando relations
            {
                var relationship =
                    _databaseModel.Relationships.FirstOrDefault(
                        r => r.UserId1.Equals(userId) && r.UserId2.Equals(userReferenceId));
                if (relationship != null)
                {
                    relationship.UserId2 = userReferenceId;
                    relationship.RelationshipTypeId = relationshipTypeId;
                    relationship.UpdatedAt = DateTime.UtcNow;
                }
                else
                {
                    relationship = new Relationship
                                       {
                                           UserId1 = userId,
                                           UserId2 = userReferenceId,
                                           RelationshipTypeId = relationshipTypeId,
                                           CreatetedAt = DateTime.UtcNow,
                                           UpdatedAt = DateTime.UtcNow,
                                       };
                    _databaseModel.Relationships.Add(relationship);
                }
                _databaseModel.SaveChanges();
            }*/

        #endregion

        #region Private Methods
        #endregion
    }
}