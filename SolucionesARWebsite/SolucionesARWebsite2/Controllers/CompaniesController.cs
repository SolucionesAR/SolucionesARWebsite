using System.Web.Mvc;
using PagedList;
using SolucionesARWebsite2.Business.Management;
using SolucionesARWebsite2.ViewModels.Companies;

namespace SolucionesARWebsite2.Controllers
{
    public class CompaniesController : BaseController
    {
        #region Private Members

        private readonly CompaniesManagement _companiesManagement;

        #endregion

        #region Constructors

        public CompaniesController(CompaniesManagement companiesManagement, UsersManagement usersManagement)
            : base(usersManagement)
        {
            _companiesManagement = companiesManagement;
        }

        #endregion

        #region Public Actions

        public ActionResult Index(IndexViewModel indexViewModel)
        {
            var pageIndex = indexViewModel.Page.HasValue ? (int)indexViewModel.Page : FirstPage;
            //missing filtering
            var results = _companiesManagement.GetAllCompaniesList();
            indexViewModel.PagedItems = results.ToPagedList(pageIndex, PageSize);

            return View(indexViewModel);
        }

        public ActionResult Create()
        {
            var editViewModel = new EditViewModel
                                    {
                                        CompanyId = 0,
                                        CompanyName = string.Empty,
                                        
                                    };
            return View("Edit", editViewModel);
        }

        public ActionResult Edit(int id)
        {
            var companyInformation = _companiesManagement.GetCompany(id);
            var editViewModel = new EditViewModel
                                    {
                                        CompanyId = id,
                                        CashBackPercentaje = companyInformation.CashBackPercentaje,
                                        CompanyName = companyInformation.CompanyName,
                                        CorporateId = companyInformation.CorporateId,
                                        CompanyNickname = companyInformation.CompanyNickName,
                                        Enabled = companyInformation.Enabled,
                                        IsFinantial = companyInformation.IsFinantial,
                                    };
            return View(editViewModel);
        }

        [HttpPost]
        public ActionResult Save(EditViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                _companiesManagement.Save(editViewModel);
                return RedirectToAction("Index");
            }
            return View("Edit", editViewModel);
        }

        #endregion

        #region Private Members
        #endregion
    }
}