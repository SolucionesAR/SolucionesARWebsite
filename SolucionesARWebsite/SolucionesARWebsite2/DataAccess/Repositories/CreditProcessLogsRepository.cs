using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using SolucionesARWebsite2.DataAccess.Interfaces;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.DataAccess.Repositories
{
    public class CreditProcessLogsRepository : ICreditProcessLogsRepository
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly DbModel _databaseModel;

        #endregion

        #region Contructors

        public CreditProcessLogsRepository()
        {
            _databaseModel = new DbModel();
        }

        #endregion


        #region Implementation of ICreditProcessLogsRepository

        public void AddCreditProcessLog(CreditProcessLog creditProcessLog)
        {
            _databaseModel.CreditProcessLogs.Add(creditProcessLog);
            _databaseModel.SaveChanges();
        }

        public void EditCreditProcessLog(CreditProcessLog creditProcessLog)
        {
            _databaseModel.Entry(creditProcessLog).State = EntityState.Modified;
            _databaseModel.SaveChanges();
        }

        public List<CreditProcessLog> GetAllCreditProcessLogs()
        {
            var creditProcessLogList = _databaseModel.CreditProcessLogs.ToList();
            return creditProcessLogList;
        }

        public List<CreditProcessLog> GetCreditProcessLogs()
        {
            var creditProcessLogList = _databaseModel.CreditProcessLogs.ToList();
            return creditProcessLogList;
        }

        public CreditProcessLog GetCreditProcessLogs(int creditProcessLogId)
        {
            var creditProcessLog =
                _databaseModel.CreditProcessLogs.First(d => d.CreditProcessLogId.Equals(creditProcessLogId));
            return creditProcessLog;
        }

        #endregion

        #region Private Methods
        #endregion
    }
}