using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using SolucionesARWebsite2.App_Start.Business.Management;
using SolucionesARWebsite2.Business.Management;
using SolucionesARWebsite2.Models;
using SolucionesARWebsite2.Enumerations;
using SolucionesARWebsite2.Utils;
using SolucionesARWebsite2.ViewModels.CreditProcesses;

namespace SolucionesARWebsite2.Controllers
{
    public class CreditProcessesController : BaseController
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly CreditProcessesManagement _creditProcessesManagement;
        private readonly CreditStatusesManagement _creditStatusesManagement;
        private readonly CustomersManagement _customersManagement;
        private readonly CompaniesManagement _companiesManagement;

        #endregion

        #region Constructors

        public CreditProcessesController(CreditProcessesManagement creditProcessesManagement, UsersManagement usersManagement, CreditStatusesManagement creditStatusesManagement, CustomersManagement customersManagement, CompaniesManagement companiesManagement)
            : base(usersManagement)
        {
            _creditProcessesManagement = creditProcessesManagement;
            _creditStatusesManagement = creditStatusesManagement;
            _customersManagement = customersManagement;
            _companiesManagement = companiesManagement;
        }

        #endregion

        #region Public Actions

        public ActionResult Index(IndexViewModel indexViewModel)
        {
            var pageIndex = indexViewModel.Page.HasValue ? (int)indexViewModel.Page : FirstPage;
            //missing filtering
            var results = _creditProcessesManagement.GetCreditProcesses();
            indexViewModel.PagedItems = results.ToPagedList(pageIndex, PageSize);
            
            return View(indexViewModel);
        }

        public ActionResult Create()
        {
            var usersToShow = GenerateUsersToShow(GetAvailableUsersList());
            var customersToShow = GenerateUsersToShow(_customersManagement.GetCustomers());
            var editViewModel = new EditViewModel
                                    {
                                        CreditProcessId = 0,
                                        Customer = new Customer(),
                                        CustomersList = customersToShow,
                                        Salesman = new User(),
                                        SalesmenList = usersToShow,
                                        CreditStatus = new CreditStatus(),
                                        CreditStatusesList = _creditStatusesManagement.GetCreditStatuses(),
                                        FinantialCompany = new Company(),
                                        FinantialCompaniesList = _companiesManagement.GetFinantialCompaniesList(),
                                        PagedItems = new List<CreditProcessXCompany>().ToPagedList(1, PageSize),
                                    };

            return View("Edit", editViewModel);
        }
                
        public ActionResult Edit(int id)
        {
            var creditProcess = _creditProcessesManagement.GetCreditProcess(id);
            var flowsPerCreditProcessList = _creditProcessesManagement.GetFlowsPerCreditProcess(id);
            var usersToShow = GenerateUsersToShow(GetAvailableUsersList());
            var customersToShow = GenerateUsersToShow(_customersManagement.GetCustomers());
            var editViewModel = new EditViewModel
                                    {
                                        CreditProcessId = id,
                                        Customer = creditProcess.Customer,
                                        CustomersList = customersToShow,
                                        Salesman = creditProcess.User,
                                        SalesmenList = usersToShow,
                                        CreditStatus = creditProcess.CreditStatus,
                                        CreditStatusesList = _creditStatusesManagement.GetCreditStatuses(),
                                        Product = creditProcess.Product,
                                        FinantialCompany = new Company(),
                                        FinantialCompaniesList = _companiesManagement.GetFinantialCompaniesList(),
                                        PagedItems = flowsPerCreditProcessList.ToPagedList(1, PageSize),
                                    };
            var processFlowsList = flowsPerCreditProcessList.Select(Map).ToList();
            UpdateCurrentProcessFlows(creditProcess.CreditProcessId, processFlowsList);

            return View(editViewModel);
        }

        [HttpPost]
        public ActionResult Save(EditViewModel editFormModel)
        {
            if (ModelState.IsValid)
            {
                //this call includes the credit flows as extra parameter 
                var processFlowsList = GetCurrentProcessFlows(editFormModel.CreditProcessId);
                _creditProcessesManagement.Save(editFormModel, processFlowsList);
                ClearCurrentProcessFlows(editFormModel.CreditProcessId);
                return RedirectToAction("Index");   
            }

            return View("Edit", editFormModel);
        }

        [HttpPost]
        public JsonResult SaveProcessFlow(ProcessFlowViewModel processFlowViewModel)
        {
            if (ModelState.IsValid)
            {
                //store the processFlowViewModel in the Session and submit when the user saves all the form changes 
                //the application doesn't know if here is a credit process created before the user saves the process flow
                var processFlowsList = GetCurrentProcessFlows(processFlowViewModel.CreditProcessId);

                if (!processFlowViewModel.IsNew)
                {
                    processFlowsList.RemoveAll(
                        pf => pf.CreditProcessXCompanyId.Equals(processFlowViewModel.CreditProcessXCompanyId));
                }

                processFlowViewModel.UpdatedAt = DateTime.Now;
                processFlowsList.Add(processFlowViewModel);
                UpdateCurrentProcessFlows(processFlowViewModel.CreditProcessId, processFlowsList);

                return Json(new { success = "true", updatedAt = processFlowViewModel.UpdatedAt.ToString() });
            }

            return Json(new {success = "false"});
        }

        [HttpPost]
        public JsonResult DeleteProcessFlow(ProcessFlowViewModel processFlowViewModel)
        {
            if (ModelState.IsValid)
            {
                //store the processFlowViewModel in the Session and submit when the user saves all the form changes 
                //the application doesn't know if here is a credit process created before the user saves the process flow
                var processFlowsList = GetCurrentProcessFlows(processFlowViewModel.CreditProcessId);

                var processFlow =
                    processFlowsList.FirstOrDefault(
                        pf => pf.CreditProcessXCompanyId.Equals(processFlowViewModel.CreditProcessXCompanyId));
                if (processFlow != null) processFlow.IsDeleted = true;

                UpdateCurrentProcessFlows(processFlowViewModel.CreditProcessId, processFlowsList);
            }

            return Json(new {success = "true"});
        }

        public ActionResult FlowDetails(int creditProcessId, int processFlowId)
        {
            var commentsPerCreditProcessFlowList =
                _creditProcessesManagement.GetCommentsPerCreditProcessFlow(creditProcessId, processFlowId);

            var detailsViewModel = new DetailsViewModel
                {
                    CreditProcessXCompanyId = processFlowId,
                    CreditProcessId = creditProcessId,
                    PagedItems = commentsPerCreditProcessFlowList.ToPagedList(1, PageSize),
                };

            return View(detailsViewModel);
        }

        [HttpPost]
        public ActionResult SaveFlowComment(DetailsViewModel formViewModel)
        {
            if (ModelState.IsValid)
            {
                _creditProcessesManagement.SaveComment(
                    new CommentViewModel
                        {
                            Comment = formViewModel.Comment,
                            CommentDate = DateTime.Now,
                            CreditProcessId = formViewModel.CreditProcessId,
                            CreditProcessXCompanyId = formViewModel.CreditProcessXCompanyId,
                        });
            }

            return RedirectToAction("FlowDetails",
                                    new
                                        {
                                            creditProcessId = formViewModel.CreditProcessId,
                                            processFlowId = formViewModel.CreditProcessXCompanyId
                                        });
        }

        #endregion

        #region Private Members

        private List<UserToShow> GenerateUsersToShow(IEnumerable<User> usersList)
        {
            return usersList.Select(user => new UserToShow
                {
                    UserToShowId = user.UserId,
                    CustomerName = user.FName + " " + user.LName1 + " " + user.LName2 + " - " + user.CedNumber
                }).ToList();
        }

        private List<UserToShow> GenerateUsersToShow(IEnumerable<Customer> customersList)
        {
            return customersList.Select(customer => new UserToShow
                {
                    UserToShowId = customer.CustomerId,
                    CustomerName = customer.FName + " " + customer.LName + " - " + customer.CedNumber
                }).ToList();
        }

        private List<ProcessFlowViewModel> GetCurrentProcessFlows(int creditProcessId)
        {
            var processFlowsCacheKey = string.Format("{0}|{1}", Constants.ProcessFlows.ToStringValue(), creditProcessId);
            var processFlowsList = Session[processFlowsCacheKey] as List<ProcessFlowViewModel>
                                ?? new List<ProcessFlowViewModel>();

            return processFlowsList;
        }

        private void ClearCurrentProcessFlows(int creditProcessId)
        {
            var processFlowsCacheKey = string.Format("{0}|{1}", Constants.ProcessFlows.ToStringValue(), creditProcessId);
            Session[processFlowsCacheKey] = new List<ProcessFlowViewModel>();
        }

        private void UpdateCurrentProcessFlows(int creditProcessId, List<ProcessFlowViewModel> processFlowsList)
        {
            var processFlowsCacheKey = string.Format("{0}|{1}", Constants.ProcessFlows.ToStringValue(), creditProcessId);
            Session[processFlowsCacheKey] = processFlowsList;
        }

        private static ProcessFlowViewModel Map(CreditProcessXCompany creditProcessXCompany)
        {
            var viewModel = new ProcessFlowViewModel
                            {
                                CompanyId = creditProcessXCompany.CompanyId,
                                CreditProcessId = creditProcessXCompany.CreditProcessId,
                                CreditProcessXCompanyId = creditProcessXCompany.CreditProcessXCompanyId,
                                CreditStatusId = creditProcessXCompany.CreditStatusId,
                                IsNew = false,
                                CreatedAt = creditProcessXCompany.CreatedAt,
                                UpdatedAt = creditProcessXCompany.UpdatedAt,
                            };

            return viewModel;
        }

        private CommentViewModel Map(CreditComment creditComment)
        {
            var viewModel = new CommentViewModel
                            {
                                Id = creditComment.CreditCommentId,
                                Comment = creditComment.Comment,
                                CommentDate = creditComment.CommentDate,
                                CreditProcessId = creditComment.CreditProcessId,
                                IsNew = false,
                            };

            return viewModel;
        }

        #endregion
    }
}