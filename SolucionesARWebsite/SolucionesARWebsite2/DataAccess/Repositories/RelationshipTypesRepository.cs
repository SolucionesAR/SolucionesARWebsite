using System.Collections.Generic;
using System.Data;
using System.Linq;
using SolucionesARWebsite2.DataAccess.Interfaces;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.DataAccess.Repositories
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

        public void AddRelationshipType(RelationshipType relationshipType)
        {
            _databaseModel.RelationshipTypes.Add(relationshipType);
            _databaseModel.SaveChanges();
        }

        public void EditRelationshipType(RelationshipType relationshipType)
        {
            _databaseModel.Entry(relationshipType).State = EntityState.Modified;
            _databaseModel.SaveChanges();
        }

        public RelationshipType GetRelationShipType(int id)
        {
            var relationshipType = _databaseModel.RelationshipTypes
                                    .FirstOrDefault(r => r.RelationshipTypeId.Equals(id));
            return relationshipType;
        }

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