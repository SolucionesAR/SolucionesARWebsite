using System;
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

        public CreditProcess GetCreditProcess(int creditProcessId)
        {
            return _creditProcessesRepository.GetCreditProcess(creditProcessId);
        }

        public List<CreditProcessXCompany> GetFlowsPerCreditProcess(int creditProcessId)
        {
            return _creditProcessesRepository.GetFlowsPerCreditProcess(creditProcessId);
        }

        public void Save(EditViewModel editViewModel, List<ProcessFlowViewModel> creditProcessFlowsList)
        {
            var creditProcess = Map(editViewModel);
            creditProcess.UpdatedAt = DateTime.UtcNow;
            if (editViewModel.CreditProcessId.Equals(0))
            {
                creditProcess.CreatedAt = DateTime.UtcNow;
                AddCreditProcess(creditProcess, creditProcessFlowsList);
            }
            else
            {
                UpdateCreditProcess(creditProcess, creditProcessFlowsList);
            }
        }  

        #endregion

        #region Private Methods
        private static CreditProcess Map(EditViewModel editViewModel)
        {
            var creditProcess = new CreditProcess
                                   {
                                       CreditProcessId = editViewModel.CreditProcessId,
                                       CustomerId = editViewModel.Customer.CustomerId,
                                       UserId = editViewModel.Salesman.UserId,
                                       CreditStatusId = editViewModel.CreditStatus.CreditStatusId,
                                       Product = editViewModel.Product,
                                       //TODO: missing list of current flows with the different companies
                                   };

            return creditProcess;
        }

        private CreditProcessXCompany Map(ProcessFlowViewModel viewModel)
        {
            var creditProcessXCompany = new CreditProcessXCompany
                                        {
                                            CompanyId = viewModel.CompanyId,
                                            CreditProcessId = viewModel.CreditProcessId,
                                            CreditProcessXCompanyId = viewModel.CreditProcessXCompanyId,
                                            CreditStatusId = viewModel.CreditStatusId,
                                        };
            return creditProcessXCompany;
        }

        private void AddCreditProcess(CreditProcess creditProcess, List<ProcessFlowViewModel> creditProcessFlowsList)
        {
            var creditProcessId = _creditProcessesRepository.AddCreditProcess(creditProcess);
            foreach(var creditProcessFlow in creditProcessFlowsList)
            {
                creditProcessFlow.CreditProcessId = creditProcessId;
                _creditProcessesRepository.AddCreditProcessFlow(Map(creditProcessFlow));
            }
        }

        private void UpdateCreditProcess(CreditProcess creditProcess, List<ProcessFlowViewModel> creditProcessFlowsList)
        {
            _creditProcessesRepository.UpdateCreditProcess(creditProcess);

            foreach (var creditProcessFlow in creditProcessFlowsList)
            {
                if (creditProcessFlow.IsNew)
                {
                    _creditProcessesRepository.AddCreditProcessFlow(Map(creditProcessFlow));
                }
                else
                {
                    if (creditProcessFlow.IsDeleted)
                    {
                        _creditProcessesRepository.DeleteCreditProcessFlow(Map(creditProcessFlow));
                    }
                    else
                    {
                        _creditProcessesRepository.UpdateCreditProcessFlow(Map(creditProcessFlow));
                    }
                }
            }
        }
        #endregion        
    }
}