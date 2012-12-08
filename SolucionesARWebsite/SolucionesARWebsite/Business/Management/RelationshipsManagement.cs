using System.Collections.Generic;
using SolucionesARWebsite.DataAccess.Interfaces;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.Business.Management
{
    public class RelationshipsManagement
    {
        #region Private Members

        private readonly IRelationshipsRepository _relationshipRepository;

        #endregion

        #region Constructors

        public RelationshipsManagement(IRelationshipsRepository relationshipRepository)
        {
            _relationshipRepository = relationshipRepository;
        }

        #endregion

        #region Public Methods

        public RelationshipType GetRelationshipType(int userId, int parentUserId)
        {
            var relationship = _relationshipRepository.GetRelationshipByUsers(userId, parentUserId);
            if(relationship!= null)
            {
                return relationship.RelationshipType;
            }
            return null;
        }

        #endregion

        #region Private Methods
        
        #endregion
    }
}