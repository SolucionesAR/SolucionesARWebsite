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
            _databaseModel.CreditProcesses.Add(CreditProcess);
            _databaseModel.SaveChanges();
        }

        public void EditCreditProcess(CreditProcess CreditProcess)
        {
            _databaseModel.Entry(CreditProcess).State = EntityState.Modified;
            _databaseModel.SaveChanges();
        }
        
        public List<CreditProcess> GetAllCreditProcesses()
        {
            var creditProcessesList = _databaseModel.CreditProcesses.ToList();
            return creditProcessesList;
        }

        public List<CreditProcess> GetCreditProcesses()
        {
            var creditProcessesList = _databaseModel.CreditProcesses.ToList();
            return creditProcessesList;
        }

        public CreditProcess GetCreditProcess(int CreditProcessId)
        {
            var creditProcess = _databaseModel.CreditProcesses.First(d => d.CreditProcessId.Equals(CreditProcessId));
            return creditProcess;
        }

        public List<CreditProcessXCompany> GetFlowsPerCreditProcess(int creditProcessId)
        {
            var flowsPerCreditProcessList = _databaseModel.CreditProcessesXCompanies.Where(cpc => cpc.CreditProcessId.Equals(creditProcessId)).ToList();
            return flowsPerCreditProcessList;
        }
        #endregion

        #region Private Methods
        #endregion
    }
}