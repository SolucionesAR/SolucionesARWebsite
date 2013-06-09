﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using SolucionesARWebsite2.Business.Management;
using SolucionesARWebsite2.Models;
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
        private readonly UsersManagement _usersManagement;
        private readonly CreditStatusesManagement _creditStatusesManagement;
        private readonly CustomersManagement _customersManagement;
        private readonly CompaniesManagement _companiesManagement;

        #endregion

        #region Constructors

        public CreditProcessesController(CreditProcessesManagement creditProcessesManagement, UsersManagement usersManagement, CreditStatusesManagement creditStatusesManagement, CustomersManagement customersManagement, CompaniesManagement companiesManagement)
            : base(usersManagement)
        {
            _creditProcessesManagement = creditProcessesManagement;
            _usersManagement = usersManagement;
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
            var usersToShow = GenerateUsersToShow(_usersManagement.GetUsersList());
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
            var usersToShow = GenerateUsersToShow(_usersManagement.GetUsersList());
            var customersToShow = GenerateUsersToShow(_customersManagement.GetCustomers());
            var editViewModel = new EditViewModel
                                    {
                                        CreditProcessId = creditProcess.CreditStatusId,
                                        Customer = creditProcess.Customer,
                                        CustomersList = customersToShow,
                                        Salesman = creditProcess.User,
                                        SalesmenList = usersToShow,
                                        CreditStatus = creditProcess.CreditStatus,
                                        CreditStatusesList = _creditStatusesManagement.GetCreditStatuses(),
                                        FinantialCompany = new Company(),
                                        FinantialCompaniesList = _companiesManagement.GetFinantialCompaniesList(),
                                        PagedItems = flowsPerCreditProcessList.ToPagedList(1, PageSize),
                                    };
            return View(editViewModel);
        }

        [HttpPost]
        public ActionResult Save(EditViewModel editFormModel)
        {
            if (ModelState.IsValid)
            {
                //this call includes the credit flows as extra parameter 
                _creditProcessesManagement.Save(editFormModel);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult SaveProcessFlow(ProcessFlowViewModel processFlowViewModel)
        {
            if (ModelState.IsValid)
            {
                //store the processFlowViewModel in the Session and submit when the user saves all the form changes 
                //the application doesn't know if there is a credit process created before the user saves the process flow

            }
            return this.Json(new { success = "true" });
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
        #endregion
    }
}