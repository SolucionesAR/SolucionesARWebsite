using System.Web.Mvc;
using PagedList;
using SolucionesARWebsite2.Business.Management;
using SolucionesARWebsite2.ViewModels.CreditStatuses;

namespace SolucionesARWebsite2.Controllers
{
    public class CreditStatusesController : BaseController
    {
        
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly CreditStatusesManagement _creditStatusManagement;

        #endregion

        #region Constructors

        public CreditStatusesController(CreditStatusesManagement creditStatusManagement, UsersManagement usersManagement)
            : base(usersManagement)
        {
            _creditStatusManagement = creditStatusManagement;
        }

        #endregion

        #region Public Actions

        public ActionResult Index(IndexViewModel indexViewModel)
        {
            var pageIndex = indexViewModel.Page.HasValue ? (int)indexViewModel.Page : FirstPage;
            //missing filtering
            var results = _creditStatusManagement.GetCreditStatuses();
            indexViewModel.PagedItems = results.ToPagedList(pageIndex, PageSize);
            
            return View(indexViewModel);
        }

        public ActionResult Create()
        {
            var editViewModel = new EditViewModel
                                    {
                                        CreditStatusId = 0,
                                        CreditStatusDescription = string.Empty
                                    };
            return View("Edit", editViewModel);
        }

        public ActionResult Edit(int id)
        {
            var creditStatusInformation = _creditStatusManagement.GetCreditStatus(id);
            var editViewModel = new EditViewModel
                                    {
                                        CreditStatusId = creditStatusInformation.CreditStatusId,
                                        CreditStatusDescription = creditStatusInformation.CreditStatusDescription
                                    };
            return View(editViewModel);
        }

        [HttpPost]
        public ActionResult Save(EditViewModel editFormModel)
        {
            if (ModelState.IsValid)
            {
                _creditStatusManagement.Save(editFormModel);
            }
            return RedirectToAction("Index");
        }



        #endregion

        #region Private Members
        #endregion
    }
}