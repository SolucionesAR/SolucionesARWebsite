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
        
        public int AddCreditProcess(CreditProcess creditProcess)
        {
            _databaseModel.CreditProcesses.Add(creditProcess);
            _databaseModel.SaveChanges();
            return creditProcess.CreditProcessId;
        }

        public void UpdateCreditProcess(CreditProcess creditProcess)
        {
            var entry = _databaseModel.Entry(creditProcess);
            if (entry.State == EntityState.Detached)
            {
                var set = _databaseModel.Set<CreditProcess>();
                var attachedEntity = set.Find(creditProcess.CreditProcessId);  // You need to have access to key

                if (attachedEntity != null)
                {
                    var attachedEntry = _databaseModel.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(creditProcess);
                }
                else
                {
                    entry.State = EntityState.Modified; // This should attach entity
                }
            }

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

        public void AddCreditProcessFlow(CreditProcessXCompany creditProcessFlow)
        {
            var flowsPerCreditProcessList = _databaseModel.CreditProcessesXCompanies.Add(creditProcessFlow);
            _databaseModel.SaveChanges();
        }

        public void UpdateCreditProcessFlow(CreditProcessXCompany creditProcessFlow)
        {
            _databaseModel.Entry(creditProcessFlow).State = EntityState.Modified;
            _databaseModel.SaveChanges();
        }

        public void DeleteCreditProcessFlow(CreditProcessXCompany creditProcessFlow)
        {
            _databaseModel.CreditProcessesXCompanies.Remove(creditProcessFlow);
            _databaseModel.SaveChanges();
        }

        #endregion

        #region Private Methods
        #endregion
    }
}