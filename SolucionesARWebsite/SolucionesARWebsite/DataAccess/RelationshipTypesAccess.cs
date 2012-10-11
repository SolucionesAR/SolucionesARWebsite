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
        public const string GOLD_RELATION = "gold";
        public const string SILVER_RELATION = "silver";
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
            //TODO por implementar
            return new RelationshipType();
        }
        #endregion

        #region Private Methods
        #endregion


    }
}