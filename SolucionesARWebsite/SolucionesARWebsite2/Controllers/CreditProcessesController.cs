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
        private readonly UsersManagement _UsersManagement;
        private readonly CreditStatusesManagement _CreditStatusesManagement;
        private readonly CustomersManagement _CustomersManagement;


        #endregion

        #region Constructors

        public CreditProcessesController(CreditProcessesManagement creditProcessesManagement, UsersManagement usersManagement, CreditStatusesManagement creditStatusesManagement, CustomersManagement customersManagement)
            : base(usersManagement)
        {
            _creditProcessesManagement = creditProcessesManagement;
            _UsersManagement = usersManagement;
            _CreditStatusesManagement = creditStatusesManagement;
            _CustomersManagement = customersManagement;
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
            var editViewModel = new EditViewModel
                                    {
                                        CreditProcessId = 0,
                                        Customer = new Customer(),
                                        CustomersList = _CustomersManagement.GetCustomers(),
                                        Salesman = new User(),
                                        SalesmenList = _UsersManagement.GetUsersList(),
                                        CreditStatus = new CreditStatus(),
                                        CreditStatusesList = _CreditStatusesManagement.GetCreditStatuses(), 
                                    };
            return View("Edit", editViewModel);
        }

        public ActionResult Edit(int id)
        {
            var creditProcess = _creditProcessesManagement.GetCreditProcess(id);
            var editViewModel = new EditViewModel
            {
                CreditProcessId = creditProcess.CreditStatusId,
                Customer = creditProcess.Customer,
                CustomersList = _CustomersManagement.GetCustomers(),
                Salesman = creditProcess.User,
                SalesmenList = _UsersManagement.GetUsersList(),
                CreditStatus = creditProcess.CreditStatus,
                CreditStatusesList = _CreditStatusesManagement.GetCreditStatuses(),
            };
            return View(editViewModel);
        }

        [HttpPost]
        public ActionResult Save(EditViewModel editFormModel)
        {
            if (ModelState.IsValid)
            {
                _creditProcessesManagement.Save(editFormModel);
            }
            return RedirectToAction("Index");
        }



        #endregion

        #region Private Members
        #endregion
    }
}