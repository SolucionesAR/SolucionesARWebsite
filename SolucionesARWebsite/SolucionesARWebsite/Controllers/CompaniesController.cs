using System.Collections.Generic;
using System.Web.Mvc;
using SolucionesARWebsite.Business.Management;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.ModelsWebsite.Forms.Companies;
using SolucionesARWebsite.ModelsWebsite.Lists;
using SolucionesARWebsite.ModelsWebsite.Views.Companies;

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
        public ActionResult Index()
        {
            var indexViewModel = new IndexViewModel
                                     {
                                         CompaniesList =
                                             new CompaniesList
                                                 {
                                                     Items = new List<Company>
                                                                 {
                                                                     new Company
                                                                         {
                                                                             CompanyId = 1,
                                                                             CompanyName = "SolucionesAR",
                                                                             CashBackPercentaje = 0.0,
                                                                             CorporateId = "001-0000000-0",
                                                                         },
                                                                     new Company
                                                                         {
                                                                             CompanyId = 2,
                                                                             CompanyName = "Coopeservidores",
                                                                             CashBackPercentaje = 10.0,
                                                                             CorporateId = "002-0000000-0",
                                                                         },
                                                                     new Company
                                                                         {
                                                                             CompanyId = 3,
                                                                             CompanyName = "Coracao",
                                                                             CashBackPercentaje = 5.0,
                                                                             CorporateId = "003-0000000-0",
                                                                         },
                                                                 }
                                                 }
                                     };
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
        public ActionResult Edit(int id = 0)
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
        public ActionResult Save(EditFormModel editFormModel)
        {
            var editViewModel = ModelViewFromForm(editFormModel);
            if (ModelState.IsValid)
            {
                editViewModel.CompanyId = 1;
            }

            return View("Edit", editViewModel);
        }

        #endregion

        #region Private Members

        private static EditViewModel ModelViewFromForm(EditFormModel editFormModel)
        {
            return new EditViewModel
                       {
                           CompanyId = editFormModel.CompanyId,
                           CompanyName = editFormModel.CompanyName,
                           CorporateId = editFormModel.CorporateId,
                           CashBackPercentaje = editFormModel.CashBackPercentaje,
                       };
        }

        #endregion
    }
}