using System.Collections.Generic;
using System.Data;
using System.Linq;
using SolucionesARWebsite2.DataAccess.Interfaces;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.DataAccess.Repositories
{
    public class CreditProcessesRepository : ICreditProcessesRepository
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly DbModel _databaseModel;

        #endregion

        #region Contructors

        public CreditProcessesRepository()
        {
            _databaseModel = new DbModel();
        }

        #endregion

        #region Public Methods
        
        public void AddCreditProcess(CreditProcess CreditProcess)
        {
            _databaseModel.CreditProcesss.Add(CreditProcess);
            _databaseModel.SaveChanges();
        }

        public void EditCreditProcess(CreditProcess CreditProcess)
        {
            _databaseModel.Entry(CreditProcess).State = EntityState.Modified;
            _databaseModel.SaveChanges();
        }
        
        public List<CreditProcess> GetAllCreditProcesses()
        {
            var creditProcessesList = _databaseModel.CreditProcesss.ToList();
            return creditProcessesList;
        }

        public List<CreditProcess> GetCreditProcesses()
        {
            var creditProcessesList = _databaseModel.CreditProcesss.ToList();
            return creditProcessesList;
        }

        public CreditProcess GetCreditProcess(int CreditProcessId)
        {
            var creditProcess = _databaseModel.CreditProcesss.First(d => d.CreditProcessId.Equals(CreditProcessId));
            return creditProcess;
        }

        #endregion

        #region Private Methods
        #endregion
    }
}