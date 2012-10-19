using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.DataAccess
{
    public class RelationshipsAccess
    {
        #region Constants
        public const string GOLD_RELATION = "gold";
        public const string SILVER_RELATION = "silver";
        #endregion

        #region Properties
        #endregion

        #region Private Members
        private readonly DbModel _databaseModel;
        #endregion

        #region Contructors

        public RelationshipsAccess()
        {
            _databaseModel = new DbModel();
        }

        #endregion

        #region Public Methods
        public User GetRelatedUser(User customer, RelationshipType relationshipType)
        {
            //TODO: Revisar con julio
            var user = _databaseModel.Relationships
                                    .Where(r => r.User1 == customer && r.RelationshipType == relationshipType)
                                    .Select(rs => rs.User2).FirstOrDefault();
            return user;
        }

        #endregion

        #region Private Methods
        #endregion
    }
}