﻿using System.Collections.Generic;
using System.Linq;
using SolucionesARWebsite.DataAccess.Interfaces;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.DataAccess.Repositories
{
    public class RelationshipTypesRepository : IRelationshipTypesRepository
    {
        #region Constants

        public const string MASTER_RELATION = "Master";
        public const string SENIOR_RELATION = "Senior";

        #endregion

        #region Properties

        #endregion

        #region Private Members

        private readonly DbModel _databaseModel;

        #endregion

        #region Contructors

        public RelationshipTypesRepository()
        {
            _databaseModel = new DbModel();
        }

        #endregion

        #region Public Methods

        public RelationshipType GetRelationShipType(string relationDescription)
        {
            var relationshipType = _databaseModel.RelationshipTypes
                                    .FirstOrDefault(r => r.Description.ToLower().Equals(relationDescription.ToLower()));
            return relationshipType;
        }
        

        public List<RelationshipType> GetRelationshipTypesList()
        {
            var relationshipsList = _databaseModel.RelationshipTypes.ToList();
            return relationshipsList;
        }

        #endregion

        #region Private Methods

        #endregion

    }
}