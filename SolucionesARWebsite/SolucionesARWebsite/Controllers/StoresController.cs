using System.Collections.Generic;
using System.Web.Mvc;
using SolucionesARWebsite.Business.Management;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.ModelsWebsite.Forms.Stores;
using SolucionesARWebsite.ModelsWebsite.Lists;
using SolucionesARWebsite.ModelsWebsite.Views.Stores;

namespace SolucionesARWebsite.Controllers
{
    public class StoresController : BaseController
    {
        #region Constants
        #endregion

        #region Properties

        #endregion

        #region Private Members

        private StoresManagement _storesManagement;

        #endregion

        #region Constructors

        public StoresController()
        {
            _storesManagement = new StoresManagement();
        }

        #endregion

        #region Public Actions

        //
        // GET: /Users/
        public ActionResult Index()
        {
            var indexViewModel = new IndexViewModel
                                     {
                                         StoresList =
                                             new StoresList
                                                 {
                                                     Items = new List<Store>
                                                                 {
                                                                     new Store
                                                                         {
                                                                             StoreId = 1,
                                                                             CompanyId = 2,
                                                                         },
                                                                     new Store
                                                                         {
                                                                             StoreId = 2,
                                                                             CompanyId = 2,
                                                                         },
                                                                     new Store
                                                                         {
                                                                             StoreId = 3,
                                                                             CompanyId = 2,
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
                                        StoreId = 0,
                                    };

            return View("Edit", editViewModel);
        }

        //
        // GET: /Users/Edit/{id}
        public ActionResult Edit(int id = 0)
        {
            var editViewModel = new EditViewModel
                                    {
                                        StoreId = 1,
                                        Company = new Company
                                                      {
                                                          CompanyId = 1,
                                                          CompanyName = "SolucionesAR",
                                                          CashBackPercentaje = 0.0,
                                                          CorporateId = "001-0000000-0",
                                                      },
                                        CompaniesList =
                                            new List<Company>
                                                {
                                                    new Company {CompanyName = "Coopeservidores"},
                                                    new Company {CompanyName = "Curacao"},
                                                    new Company {CompanyName = "SolucionesAR"},
                                                },
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
                editViewModel.StoreId = 1;
            }

            return View("Edit", editViewModel);
        }

        #endregion

        #region Private Members

        private static EditViewModel ModelViewFromForm(EditFormModel editFormModel)
        {
            return new EditViewModel
                       {
                           StoreId = editFormModel.StoreId,
                           Company = new Company {CompanyId = editFormModel.CompanyId},
                       };
        }

        #endregion
    }
}