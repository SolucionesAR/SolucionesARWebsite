using System.Linq;
using SolucionesARWebsite.DataAccess.Interfaces;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.DataAccess.Repositories
{
    public class RelationshipsRepository : IRelationshipsRepository
    {
        #region Constants

        public const string GOLD_RELATION = "gold";
        public const string SILVER_RELATION = "silver";

        #endregion


        #region Private Members

        private readonly DbModel _databaseModel;

        #endregion

        #region Contructors

        public RelationshipsRepository()
        {
            _databaseModel = new DbModel();
        }

        #endregion

        #region Public Methods

        public User GetRelatedUser(User customer, RelationshipType relationshipType)
        {
            var user = _databaseModel.Relationships
                .Where(
                    r =>
                    r.User1.UserId  == customer.UserId &&
                    r.RelationshipType.RelationshipTypeId == relationshipType.RelationshipTypeId)
                .Select(rs => rs.User2).FirstOrDefault();
            return user;
        }

        public Relationship GetRelationshipByUsers(int userId, int parentUserId)
        {
            var relationship =
                _databaseModel.Relationships.FirstOrDefault(
                    r => r.UserId1.Equals(userId) && r.UserId2.Equals(parentUserId));
            return relationship;
        }

        #endregion

        #region Private Methods
        #endregion
    }
}