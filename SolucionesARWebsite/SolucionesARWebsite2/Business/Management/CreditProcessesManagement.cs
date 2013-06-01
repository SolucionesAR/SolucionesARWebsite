﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SolucionesARWebsite2.DataAccess.Interfaces;
using SolucionesARWebsite2.Models;
using SolucionesARWebsite2.ViewModels.CreditProcesses;

namespace SolucionesARWebsite2.Business.Management
{
    public class CreditProcessesManagement
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly ICreditProcessesRepository _creditProcessesRepository;

        #endregion

        #region Public Methods
        public CreditProcessesManagement(ICreditProcessesRepository creditProcessesRepository)
        {
            _creditProcessesRepository = creditProcessesRepository;
        }

        public List<CreditProcess> GetCreditProcesses()
        {
            return _creditProcessesRepository.GetAllCreditProcesses();
        }

        public CreditProcess GetCreditProcess(int CreditProcessId)
        {
            return _creditProcessesRepository.GetCreditProcess(CreditProcessId);
        }

        public void Save(EditViewModel editViewModel)
        {
            var CreditProcess = Map(editViewModel);
            
            if (editViewModel.CreditProcessId.Equals(0))
            {
                AddCreditProcess(CreditProcess);
            }
            else
            {
                EditCreditProcess(CreditProcess);
            }
        }  

        #endregion

        #region Private Methods
        private static CreditProcess Map(EditViewModel editViewModel)
        {
            var CreditProcess = new CreditProcess
                                   {
                                       CreditProcessId = editViewModel.CreditProcessId,
                                       CustomerId = editViewModel.Customer.CustomerId,
                                       UserId = editViewModel.Salesman.UserId,
                                       CreditStatusId = editViewModel.CreditStatus.CreditStatusId,
                                       //TODO: missing list of current flows with the different companies
                                   };

            return CreditProcess;
        }

        private void AddCreditProcess (CreditProcess CreditProcess)
        {
            _creditProcessesRepository.AddCreditProcess(CreditProcess);
        }

        private void EditCreditProcess(CreditProcess CreditProcess)
        {
            _creditProcessesRepository.EditCreditProcess(CreditProcess);
        }
        #endregion        
    }
}