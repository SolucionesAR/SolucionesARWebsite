using System.Collections.Generic;
using SolucionesARWebsite.DataAccess.Interfaces;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.Business.Management
{
    public class RelationshipTypesManagement
    {
        #region Private Members

        private readonly IRelationshipTypesRepository _relationshipTypesRepository;

        #endregion

        #region Constructors

        public RelationshipTypesManagement(IRelationshipTypesRepository relationshipTypesRepository)
        {
            _relationshipTypesRepository = relationshipTypesRepository;
        }

        #endregion

        #region Public Methods

        public List<RelationshipType> GetRelationshipTypesList()
        {
            return _relationshipTypesRepository.GetRelationshipTypesList();
        }

        #endregion

        #region Private Methods

        #endregion
    }
}