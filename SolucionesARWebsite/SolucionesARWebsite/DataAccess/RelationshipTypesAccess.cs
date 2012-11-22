﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.DataAccess
{
    public class RelationshipTypesAccess
    {
        #region Constants

        public const string MASTER_RELATION = "master";
        public const string SENIOR_RELATION = "senior";

        #endregion

        #region Properties

        #endregion

        #region Private Members

        private readonly DbModel _databaseModel;

        #endregion

        #region Contructors

        public RelationshipTypesAccess()
        {
            _databaseModel = new DbModel();
        }

        #endregion

        #region Public Methods

        public RelationshipType GetRelationShipType(string relationDescription)
        {
            var relationshipType = _databaseModel.RelationshipTypes
                                    .FirstOrDefault(r => r.Description.Equals(relationDescription));
            return relationshipType;
        }

        #endregion

        #region Private Methods

        #endregion

    }
}