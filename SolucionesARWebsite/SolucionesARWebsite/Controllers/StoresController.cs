using System;
using System.Web.Mvc;
using SolucionesARWebsite.Business.Management;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.ViewModels.Forms.Stores;
using SolucionesARWebsite.ViewModels.Lists;
using SolucionesARWebsite.ViewModels.Views.Stores;

namespace SolucionesARWebsite.Controllers
{
    public class StoresController : BaseController
    {
        #region Constants
        #endregion

        #region Properties

        #endregion

        #region Private Members

        private readonly StoresManagement _storesManagement;
        private readonly CompaniesManagement _companiesManagement;
        private readonly LocationsManagement _districtsManagement;

        #endregion

        #region Constructors

        public StoresController()
        {
            _storesManagement = new StoresManagement();
            _companiesManagement = new CompaniesManagement();
            _districtsManagement = new LocationsManagement();
        }

        #endregion

        #region Public Actions

        //
        // GET: /Users/
        public ActionResult Index()
        {
            var stores = _storesManagement.GetStores();
            var indexViewModel = new IndexViewModel
            {
                StoresList = new StoresList
                {
                    Items = stores
                }
            };
            return View(indexViewModel);
        }

        //
        // GET: /Users/Create/
        public ActionResult Create()
        {
            var companies = _companiesManagement.GetCompanies();
            var districts = _districtsManagement.GetAllDistricts();
            var editViewModel = new EditViewModel
                                    {
                                        StoreId = 0,
                                        StoreName = "",
                                        CompaniesList = companies,
                                        Districts = districts,
                                        Company = new Company{CompanyId = 0},
                                        District = new District{DistrictId = 0},
                                        FaxNumber = "",
                                        PhoneNumber1 = "",
                                        PhoneNumber2 = ""
                                    };

            return View("Edit", editViewModel);
        }

        //
        // GET: /Users/Edit/{id}
        public ActionResult Edit(int id)
        {
            var store = _storesManagement.GetStore(id);
            var companies = _companiesManagement.GetCompanies();
            var districts = _districtsManagement.GetAllDistricts();
            var editViewModel = new EditViewModel
            {
                StoreId = store.StoreId,
                StoreName = store.StoreName,
                Company = store.Company,
                CompaniesList = companies,
                District = store.District,
                Districts = districts,
                FaxNumber = store.FaxNumber,
                PhoneNumber1 = store.PhoneNumber1,
                PhoneNumber2 = store.PhoneNumber2
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
                Store store;
                if (editFormModel.StoreId == 0)
                {
                    store = new Store
                    {
                        StoreId = editFormModel.StoreId,
                        //Company = _companiesManagement.GetCompany( editFormModel.Company.CompanyId),
                        CompanyId = editFormModel.Company.CompanyId,
                        DistrictId = editFormModel.District.DistrictId,
                        FaxNumber = editFormModel.FaxNumber,
                        PhoneNumber1 = editFormModel.PhoneNumber1,
                        PhoneNumber2 = editFormModel.PhoneNumber2,
                        StoreName = editFormModel.StoreName,
                        CreatetedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };
                    
                }
                else
                {
                    store = _storesManagement.GetStore(editFormModel.StoreId);
                    store.StoreName = editFormModel.StoreName;
                    store.PhoneNumber1 = editFormModel.PhoneNumber1;
                    store.PhoneNumber2 = editFormModel.PhoneNumber2;
                    store.CompanyId = editFormModel.Company.CompanyId;
                    store.DistrictId = editFormModel.District.DistrictId;
                    store.FaxNumber = editFormModel.FaxNumber;
                    store.UpdatedAt = new DateTime();
                }

                _storesManagement.SaveStore(store);
            }
            editViewModel.Districts = _districtsManagement.GetAllDistricts();
            editViewModel.CompaniesList = _companiesManagement.GetCompanies();
            return View("Edit", editViewModel);
        }

        #endregion

        #region Private Members

        private static EditViewModel ModelViewFromForm(EditFormModel editFormModel)
        {
            return new EditViewModel
                       {
                           StoreId = editFormModel.StoreId,
                           StoreName = editFormModel.StoreName,
                           Company = editFormModel.Company,
                           District = editFormModel.District,
                           FaxNumber = editFormModel.FaxNumber,
                           PhoneNumber1 = editFormModel.PhoneNumber1,
                           PhoneNumber2 = editFormModel.PhoneNumber2,
                           Districts = editFormModel.Districts,
                           CompaniesList = editFormModel.CompaniesList

                       };
        }

        #endregion
    }
}