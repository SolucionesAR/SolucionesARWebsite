using System.Collections.Generic;
using System.Data;
using System.Linq;
using SolucionesARWebsite2.DataAccess.Interfaces;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.DataAccess.Repositories
{
    public class CreditStatusesRepository: ICreditStatusesRepository
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly DbModel _databaseModel;

        #endregion

        #region Contructors

        public CreditStatusesRepository()
        {
            _databaseModel = new DbModel();
        }

        #endregion

        #region Public Methods
        
        public void AddCreditStatus(CreditStatus creditStatus)
        {
            _databaseModel.CreditStatus.Add(creditStatus);
            _databaseModel.SaveChanges();
        }

        public void EditCreditStatus(CreditStatus creditStatus)
        {
            _databaseModel.Entry(creditStatus).State = EntityState.Modified;
            _databaseModel.SaveChanges();
        }
        
        public List<CreditStatus> GetAllCreditStatus()
        {
            var creditStatusesList = _databaseModel.CreditStatus.ToList();
            return creditStatusesList;
        }

        public List<CreditStatus> GetCreditStatus()
        {
            var creditStatusesList = _databaseModel.CreditStatus.ToList();
            return creditStatusesList;
        }

        public CreditStatus GetCreditStatus(int creditStatusId)
        {
            var creditStatus = _databaseModel.CreditStatus.First(d => d.CreditStatusId.Equals(creditStatusId));
            return creditStatus;
        }

        #endregion

        #region Private Methods
        #endregion
    }
}