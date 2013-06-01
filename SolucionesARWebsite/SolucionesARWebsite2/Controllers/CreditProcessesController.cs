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

        #endregion

        #region Constructors

        public CreditProcessesController(CreditProcessesManagement creditProcessesManagement, UsersManagement usersManagement)
            : base(usersManagement)
        {
            _creditProcessesManagement = creditProcessesManagement;
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
                                        //CustomersList = _customerMana
                                        Salesman = new User(),
                                        //SalesmenList = _users,
                                        CreditStatus = new CreditStatus(),
                                        //CreditStatusesList = 
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
                //CustomersList = _customerMana
                Salesman = creditProcess.User,
                //SalesmenList = _users,
                CreditStatus = creditProcess.CreditStatus,
                //CreditStatusesList = 
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