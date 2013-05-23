using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SolucionesARWebsite2.DataAccess.Interfaces;
using SolucionesARWebsite2.Models;
using SolucionesARWebsite2.ViewModels.CreditStatus;

namespace SolucionesARWebsite2.Business.Management
{
    public class CreditStatusManagement
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly ICreditStatusRepository _creditStatusRepository;

        #endregion

        #region Public Methods
        public CreditStatusManagement(ICreditStatusRepository creditStatusRepository)
        {
            _creditStatusRepository = creditStatusRepository;
        }

        public List<CreditStatus> GetCreditStatuses()
        {
            return _creditStatusRepository.GetAllCreditStatus();
        }

        public CreditStatus GetCreditStatus(int creditStatusId)
        {
            return _creditStatusRepository.GetCreditStatus(creditStatusId);
        }

        public void Save(EditViewModel editViewModel)
        {
            var creditStatus = Map(editViewModel);
            
            if (editViewModel.CreditStatusId.Equals(0))
            {
                AddCreditStatus(creditStatus);
            }
            else
            {
                EditCreditStatus(creditStatus);
            }
        }

        

        #endregion

        #region Private Methods
        private static CreditStatus Map(EditViewModel editViewModel)
        {
            var creditStatus = new CreditStatus
                                   {
                                       CreditStatusId = editViewModel.CreditStatusId,
                                       CreditStatusDescription = editViewModel.CreditStatusDescription
                                   };

            return creditStatus;
        }

        private void AddCreditStatus (CreditStatus creditStatus)
        {
            _creditStatusRepository.AddCreditStatus(creditStatus);
        }

        private void EditCreditStatus(CreditStatus creditStatus)
        {
            _creditStatusRepository.EditCreditStatus(creditStatus);
        }
        #endregion

        
    }
}