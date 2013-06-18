using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SolucionesARWebsite2.DataAccess.Interfaces;
using SolucionesARWebsite2.Models;
using SolucionesARWebsite2.ViewModels.CreditStatuses;

namespace SolucionesARWebsite2.Business.Management
{
    public class CreditProcessLogsManagement
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly ICreditProcessLogsRepository _creditProcessLogsRepository;

        #endregion

        #region Public Methods
        
        public CreditProcessLogsManagement(ICreditProcessLogsRepository creditProcessLogsRepository)
        {
            _creditProcessLogsRepository = creditProcessLogsRepository;
        }

        public List<CreditProcessLog> GetCreditProcessLogs()
        {
            return _creditProcessLogsRepository.GetCreditProcessLogs();
        }

        public CreditProcessLog GetCreditProcessLogs(int creditProcessLogId)
        {
            return _creditProcessLogsRepository.GetCreditProcessLogs(creditProcessLogId);
        }

        public void AddCreditProcessLog(CreditProcessLog creditProcessLog)
        {
            _creditProcessLogsRepository.AddCreditProcessLog(creditProcessLog);
        }

        public void EditCreditProcessLog(CreditProcessLog creditProcessLog)
        {
            _creditProcessLogsRepository.EditCreditProcessLog(creditProcessLog);
        }



        #endregion

        #region Private Methods


        #endregion
    }
}