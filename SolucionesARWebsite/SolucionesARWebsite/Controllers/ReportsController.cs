using System.Collections.Generic;
using System.Web.Mvc;
using PagedList;
using SolucionesARWebsite.Business.Management;
using SolucionesARWebsite.Enumerations;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.Utils;
using SolucionesARWebsite.ViewModels.Reports;
using IndexViewModel = SolucionesARWebsite.ViewModels.Reports.IndexViewModel;

namespace SolucionesARWebsite.Controllers
{
    public class ReportsController : BaseController
    {
        #region Private Members

        private readonly CompaniesManagement _companiesManagement;
        
        #endregion

        #region Constructors

        public ReportsController(CompaniesManagement companiesManagement, UsersManagement usersManagement)
            : base(usersManagement)
        {
            _companiesManagement = companiesManagement;
        }

        #endregion

        #region Public Actions

        public ActionResult Index(IndexViewModel indexViewModel)
        {
            var pageIndex = indexViewModel.Page.HasValue ? (int)indexViewModel.Page : FirstPage;
            var results = GetReportsList();
            indexViewModel.PagedItems = results.ToPagedList(pageIndex, PageSize);

            return View(indexViewModel);
        }

        public ActionResult SolucionesAr()
        {
            return View(new BaseReportViewModel());
        }

        [HttpPost]
        public ActionResult SolucionesAr(BaseReportViewModel reportViewModel)
        {
            return View();
        }

        public ActionResult Company()
        {
            var companyReportViewModel = new CompanyReportViewModel
                                             {
                                                 Company = new Company(),
                                                 CompaniesList = _companiesManagement.GetOrderedCompaniesList()
                                             };
            return View(companyReportViewModel);
        }

        [HttpPost]
        public ActionResult Company(CompanyReportViewModel reportViewModel)
        {
            return View();
        }

        public ActionResult Customer()
        {
            var customerReportViewModel = new CustomerReportViewModel
                                              {
                                                  Customer = new User(),
                                                  CustomerList = UsersManagement.GetOrderedUsersList(),
                                              };
            return View(customerReportViewModel);
        }

        [HttpPost]
        public ActionResult Customer(CustomerReportViewModel reportViewModel)
        {
            return View();
        }

        public ActionResult Application()
        {
            return View(new BaseReportViewModel());
        }

        [HttpPost]
        public ActionResult Application(BaseReportViewModel reportViewModel)
        {
            return View();
        }

        #endregion

        #region Private Members
        
        private static IEnumerable<Report> GetReportsList()
        {
            var reportsList = new List<Report>();
            foreach (var report in EnumUtil.GetValues<ApplicationReports>())
            {
                reportsList.Add(new Report { Id = (int)report, Name = report.ToStringValue(), Action = report.ToString()});
            }
            return reportsList;
        }

        #endregion
    }
}