using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.DataAccess
{
    public class RelationshipTypesAccess
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

        public RelationshipTypesAccess()
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

        #endregion

        #region Private Methods

        #endregion

    }
}