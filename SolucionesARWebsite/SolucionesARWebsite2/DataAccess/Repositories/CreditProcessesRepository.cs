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

        public CreditProcess GetCreditProcess(int creditProcessId)
        {
            var creditProcess = _databaseModel.CreditProcesses.First(d => d.CreditProcessId.Equals(creditProcessId));
            return creditProcess;
        }

        public List<CreditProcessXCompany> GetFlowsPerCreditProcess(int creditProcessId)
        {
            var flowsPerCreditProcessList = _databaseModel.CreditProcessesXCompanies.Where(cpc => cpc.CreditProcessId.Equals(creditProcessId)).ToList();
            return flowsPerCreditProcessList;
        }
     
        public int AddCreditProcessFlow(CreditProcessXCompany creditProcessFlow)
        {
            var flowsPerCreditProcessList = _databaseModel.CreditProcessesXCompanies.Add(creditProcessFlow);
            _databaseModel.SaveChanges();
            return creditProcessFlow.CreditProcessXCompanyId;
        }

        public void UpdateCreditProcessFlow(CreditProcessXCompany creditProcessFlow)
        {
            var entry = _databaseModel.Entry(creditProcessFlow);
            if (entry.State == EntityState.Detached)
            {
                var set = _databaseModel.Set<CreditProcessXCompany>();
                var attachedEntity = set.Find(creditProcessFlow.CreditProcessXCompanyId);  // You need to have access to key

                if (attachedEntity != null)
                {
                    var attachedEntry = _databaseModel.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(creditProcessFlow);
                }
                else
                {
                    entry.State = EntityState.Modified; // This should attach entity
                }
            }


            _databaseModel.SaveChanges();
        }

        public void DeleteCreditProcessFlow(CreditProcessXCompany creditProcessFlow)
        {
            var entityToDelete = _databaseModel.CreditProcessesXCompanies
                .FirstOrDefault(cpc => cpc.CreditProcessXCompanyId.Equals(creditProcessFlow.CreditProcessXCompanyId));
            if (entityToDelete != null)
            {
                _databaseModel.CreditProcessesXCompanies.Remove(entityToDelete);
            }
            _databaseModel.SaveChanges();
        }

        public CreditProcessXCompany GetCreditProcessXCompanyFlow(int creditProcessXCompanyId)
        {
            var creditProcessXCompanyFlow = _databaseModel.CreditProcessesXCompanies.FirstOrDefault(cpc => cpc.CreditProcessXCompanyId.Equals(creditProcessXCompanyId));
            return creditProcessXCompanyFlow;
        }


        public List<CreditComment> GetCommentsPerCreditProcessFlow(int creditProcessId, int creditProcessXCompanyId)
        {
            var commentsPerCreditProcessFlowList = _databaseModel.CreditComments.Where(cpc =>
                cpc.CreditProcessId.Equals(creditProcessId)
                //&& cpc.CreditProcessesXCompanyId.Equals(processFlowId))
                ).ToList();
            return commentsPerCreditProcessFlowList;
        }

        public void AddCreditProcessFlowComment(CreditComment creditProcessFlowComment)
        {
            var flowsPerCreditProcessList = _databaseModel.CreditComments.Add(creditProcessFlowComment);
            _databaseModel.SaveChanges();
        }

        public void UpdateCreditProcessFlowComment(CreditComment creditProcessFlowComment)
        {
            var entry = _databaseModel.Entry(creditProcessFlowComment);
            if (entry.State == EntityState.Detached)
            {
                var set = _databaseModel.Set<CreditProcessXCompany>();
                var attachedEntity = set.Find(creditProcessFlowComment.CreditCommentId);  // You need to have access to key

                if (attachedEntity != null)
                {
                    var attachedEntry = _databaseModel.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(creditProcessFlowComment);
                }
                else
                {
                    entry.State = EntityState.Modified; // This should attach entity
                }
            }

            _databaseModel.SaveChanges();
        }

        #endregion

        #region Private Methods
        #endregion
    }
}