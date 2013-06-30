using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SolucionesARWebsite2.DataAccess.Interfaces;
using SolucionesARWebsite2.Models;
using SolucionesARWebsite2.ViewModels.CreditStatuses;

namespace SolucionesARWebsite2.Business.Management
{
    public class CreditStatusesManagement
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly ICreditStatusesRepository _creditStatusesRepository;

        #endregion

        #region Public Methods
        public CreditStatusesManagement(ICreditStatusesRepository creditStatusesRepository)
        {
            _creditStatusesRepository = creditStatusesRepository;
        }

        public List<CreditStatus> GetCreditStatuses()
        {
            return _creditStatusesRepository.GetAllCreditStatus();
        }

        public CreditStatus GetCreditStatus(int creditStatusId)
        {
            return _creditStatusesRepository.GetCreditStatus(creditStatusId);
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
            _creditStatusesRepository.AddCreditStatus(creditStatus);
        }

        private void EditCreditStatus(CreditStatus creditStatus)
        {
            _creditStatusesRepository.EditCreditStatus(creditStatus);
        }
        #endregion

        
    }
}