using System;
using System.Collections.Generic;
using SolucionesARWebsite2.DataAccess.Interfaces;
using SolucionesARWebsite2.Models;
using SolucionesARWebsite2.ViewModels.RelationshipTypes;

namespace SolucionesARWebsite2.Business.Management
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

        public RelationshipType GetRelationshipType(int id)
        {
            return _relationshipTypesRepository.GetRelationShipType(id);
        }

        public void Save(EditViewModel editViewModel)
        {
            var relationshipType = Map(editViewModel);

            if (editViewModel.RelationshipTypesId.Equals(0))
            {
                relationshipType.CreatetedAt = DateTime.Now;
                relationshipType.UpdatedAt = DateTime.Now;
                AddRelationshipType(relationshipType);
            }
            else
            {
                relationshipType.UpdatedAt = DateTime.Now;
                EditRelationshipType(relationshipType);
            }
        }
        #endregion

        #region Private Methods

        private void AddRelationshipType(RelationshipType relationshipType)
        {
            _relationshipTypesRepository.AddRelationshipType(relationshipType);
        }

        private void EditRelationshipType(RelationshipType relationshipType)
        {
            _relationshipTypesRepository.EditRelationshipType(relationshipType);
        }

        private static RelationshipType Map(EditViewModel editViewMode)
        {
            return new RelationshipType
                       {
                           RelationshipTypeId = editViewMode.RelationshipTypesId,
                           Description = editViewMode.Description.ToUpper(),
                       };
        }

        #endregion
    }
}