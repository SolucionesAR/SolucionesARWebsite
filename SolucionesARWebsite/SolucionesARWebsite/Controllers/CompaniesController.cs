using System.Web.Mvc;
using PagedList;
using SolucionesARWebsite.Business.Management;
using SolucionesARWebsite.ViewModels.Companies;

namespace SolucionesARWebsite.Controllers
{
    public class CompaniesController : BaseController
    {
        #region Constants
        #endregion

        #region Properties

        #endregion

        #region Private Members

        private CompaniesManagement _companiesManagement;

        #endregion

        #region Constructors

        public CompaniesController()
        {
            _companiesManagement = new CompaniesManagement();
        }

        #endregion

        #region Public Actions

        //
        // GET: /Users/
        public ActionResult Index(IndexViewModel indexViewModel)
        {
            var pageIndex = indexViewModel.Page.HasValue ? (int)indexViewModel.Page : FirstPage;
            //missing filtering
            var results = _companiesManagement.GetCompanies();
            indexViewModel.PagedItems = results.ToPagedList(pageIndex, PageSize);

            return View(indexViewModel);
        }

        //
        // GET: /Users/Create/
        public ActionResult Create()
        {
            var editViewModel = new EditViewModel
                                    {
                                        CompanyId = 0,
                                    };

            return View("Edit", editViewModel);
        }

        //
        // GET: /Users/Edit/{id}
        public ActionResult Edit(int id)
        {
            var editViewModel = new EditViewModel
                                    {
                                        CompanyId = 1,
                                        CompanyName = "SolucionesAR",
                                        CashBackPercentaje = 0.0,
                                        CorporateId = "001-0000000-0",
                                    };
            return View(editViewModel);
        }

        //
        // POST: /Users/Save/{editeditFormModel}
        [HttpPost]
        public ActionResult Save(EditViewModel editViewModel)
        {
            //var editViewModel = ModelViewFromForm(EditViewModel);
            if (ModelState.IsValid)
            {
                _companiesManagement.Save(editViewModel);
            }

            return View("Edit", editViewModel);
        }

        #endregion

        #region Private Members

        private static EditViewModel ModelViewFromForm(EditViewModel editViewModel)
        {
            return new EditViewModel
                       {
                           CompanyId = editViewModel.CompanyId,
                           CompanyName = editViewModel.CompanyName,
                           CorporateId = editViewModel.CorporateId,
                           CashBackPercentaje = editViewModel.CashBackPercentaje,
                       };
        }

        #endregion
    }
}