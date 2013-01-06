using System.Collections.Generic;
using System.Data;
using System.Linq;
using SolucionesARWebsite2.DataAccess.Interfaces;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.DataAccess.Repositories
{
    public class IdentificationTypesRepository : IIdentificationTypesRepository
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly DbModel _databaseModel;

        #endregion

        #region Contructors

        public IdentificationTypesRepository()
        {
            _databaseModel = new DbModel();
        }

        #endregion

        #region Public Methods
        
        public void AddIdentificationType(IdentificationType identificationType)
        {
            _databaseModel.IdentificationType.Add(identificationType);
            _databaseModel.SaveChanges();
        }

        public void EditIdentificationType(IdentificationType identificationType)
        {
            _databaseModel.Entry(identificationType).State = EntityState.Modified;
            _databaseModel.SaveChanges();
        }
        
        public List<IdentificationType> GetAllIdentificationTypes()
        {
            var identificationTypes = _databaseModel.IdentificationType.ToList();
            return identificationTypes;
        }

        public List<IdentificationType> GetIdentificationTypes()
        {
            var identificationTypes = _databaseModel.IdentificationType.ToList();
            return identificationTypes;
        }

        public IdentificationType GetIdentificationType(int identificationTypeId)
        {
            var identificationTypes = _databaseModel.IdentificationType.First(d => d.IdentificationTypeId.Equals(identificationTypeId));
            return identificationTypes;
        }

        #endregion

        #region Private Methods
        #endregion
    }
}