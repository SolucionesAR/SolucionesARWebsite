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
        private readonly CreditProcessLogsManagement _creditProcessesLogManagement;

        #endregion

        #region Public Methods
        public CreditProcessesManagement(ICreditProcessesRepository creditProcessesRepository, CreditProcessLogsManagement creditProcessesLogManagement)
        {
            _creditProcessesRepository = creditProcessesRepository;
            _creditProcessesLogManagement = creditProcessesLogManagement;
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
                creditProcess.UpdatedAt = DateTime.UtcNow;
                AddCreditProcess(creditProcess, creditProcessFlowsList);
            }
            else
            {

                creditProcess.UpdatedAt = DateTime.UtcNow;
                UpdateCreditProcess(creditProcess, creditProcessFlowsList);
            }
        }

        public List<CreditComment> GetCommentsPerCreditProcessFlow(int creditProcessId, int processFlowId)
        {
            return _creditProcessesRepository.GetCommentsPerCreditProcessFlow(creditProcessId, processFlowId);
        }

        public void SaveComment(CommentViewModel commentViewModel)
        {
            var creditComment = Map(commentViewModel);
            if (commentViewModel.Id.Equals(0))
            {
                AddCreditProcessFlowComment(creditComment);
            }
            else
            {
                UpdateCreditProcessFlowComment(creditComment);
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

        private CreditComment Map(CommentViewModel viewModel)
        {
            var creditComment = new CreditComment
                                {
                                    CreditCommentId = viewModel.Id,
                                    CreditProcessId = viewModel.CreditProcessId,
                                    creditProcessXCompanyId = viewModel.CreditProcessXCompanyId,
                                    Comment = viewModel.Comment,
                                    CommentDate = viewModel.CommentDate,
                                };
            return creditComment;
        }

        private void AddCreditProcess(CreditProcess creditProcess, List<ProcessFlowViewModel> creditProcessFlowsList)
        {
            var creditProcessId = _creditProcessesRepository.AddCreditProcess(creditProcess);
            foreach(var creditProcessFlow in creditProcessFlowsList)
            {
                creditProcessFlow.CreditProcessId = creditProcessId;
                var creditProcessFlowFormed = Map(creditProcessFlow);
                creditProcessFlowFormed.CreatedAt = DateTime.UtcNow;
                creditProcessFlowFormed.UpdatedAt = DateTime.UtcNow;
                
                int flowId = _creditProcessesRepository.AddCreditProcessFlow(creditProcessFlowFormed);
                creditProcessFlowFormed.CreditProcessXCompanyId = flowId;
                var creditProcessLog = CreateNewCreditProcessLog(creditProcessFlowFormed);
                _creditProcessesLogManagement.AddCreditProcessLog(creditProcessLog);
            }
        }

        private void UpdateCreditProcess(CreditProcess creditProcess, List<ProcessFlowViewModel> creditProcessFlowsList)
        {
            _creditProcessesRepository.UpdateCreditProcess(creditProcess);

            foreach (var creditProcessFlow in creditProcessFlowsList)
            {
                var creditProcessFlowFormed = Map(creditProcessFlow);
                creditProcessFlowFormed.UpdatedAt = DateTime.UtcNow;
                if (creditProcessFlow.IsNew)
                {
                    creditProcessFlowFormed.CreatedAt = DateTime.UtcNow;
                    
                    int flowId = _creditProcessesRepository.AddCreditProcessFlow(creditProcessFlowFormed);
                    var creditProcessLog = CreateNewCreditProcessLog(creditProcessFlowFormed);
                    creditProcessFlowFormed.CreditProcessXCompanyId = flowId;
                    _creditProcessesLogManagement.AddCreditProcessLog(creditProcessLog);
                }
                else
                {
                    if (creditProcessFlow.IsDeleted)
                    {
                        _creditProcessesRepository.DeleteCreditProcessFlow(creditProcessFlowFormed);
                    }
                    else
                    {
                        var creditProcessLog = UpdateCreditProcessLog(creditProcessFlowFormed);
                        _creditProcessesLogManagement.AddCreditProcessLog(creditProcessLog);
                        _creditProcessesRepository.UpdateCreditProcessFlow(creditProcessFlowFormed);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creditComment"></param>
        private void AddCreditProcessFlowComment(CreditComment creditComment)
        {
            _creditProcessesRepository.AddCreditProcessFlowComment(creditComment);            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creditComment"></param>
        private void UpdateCreditProcessFlowComment(CreditComment creditComment)
        {
            _creditProcessesRepository.UpdateCreditProcessFlowComment(creditComment);
        }

        /// <summary>
        /// To add an update event in the credit process logs
        /// </summary>
        /// <param name="creditProcessFlowFormed"></param>
        /// <returns></returns>
        private CreditProcessLog UpdateCreditProcessLog(CreditProcessXCompany creditProcessFlowFormed)
        {
            var currentProcess =
                _creditProcessesRepository.GetCreditProcessXCompanyFlow(creditProcessFlowFormed.CreditProcessXCompanyId);

            var creditProcessLog = new CreditProcessLog
                                       {
                                           ChangeDate = DateTime.UtcNow,
                                           CreditProcessXCompanyId =
                                               creditProcessFlowFormed.CreditProcessXCompanyId,
                                           LastStatusId = currentProcess.CreditStatusId,
                                           NewStatusId = creditProcessFlowFormed.CreditStatusId,
                                       };
            return creditProcessLog;

        }

        /// <summary>
        /// To add a new event in the credit process logs
        /// </summary>
        /// <param name="creditProcessFlowFormed"></param>
        /// <returns></returns>
        private CreditProcessLog CreateNewCreditProcessLog(CreditProcessXCompany creditProcessFlowFormed)
        {
            var creditProcessLog = new CreditProcessLog
                                       {
                                           ChangeDate = DateTime.UtcNow,
                                           CreditProcessXCompanyId =
                                               creditProcessFlowFormed.CreditProcessXCompanyId,
                                           LastStatusId = creditProcessFlowFormed.CreditStatusId,
                                           NewStatusId = creditProcessFlowFormed.CreditStatusId,
                                       };
            return creditProcessLog;

        }

        #endregion        
    }
}