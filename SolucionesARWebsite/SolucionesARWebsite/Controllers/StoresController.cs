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
        private readonly LocationsManagement _locationsManagement;

        #endregion

        #region Constructors

        public StoresController(CompaniesManagement companiesManagement)
        {
            _companiesManagement = companiesManagement;

            _storesManagement = new StoresManagement();
            _locationsManagement = new LocationsManagement();
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
            var editViewModel = new EditViewModel
            {
                StoreId = 0,
                StoreName = "",
                CompaniesList = companies,
                Company = new Company { CompanyId = 0 },
                FaxNumber = "",
                PhoneNumber1 = "",
                PhoneNumber2 = "",
                Province = _locationsManagement.GetProvince(1),
                ProvincesList = _locationsManagement.GetAllProvinces(),
                Canton = new Canton(),
                CantonsList = _locationsManagement.GetCantonsByProvince(1),
                //CantonsList = 
                District = new District(),
                DistrictsList = _locationsManagement.GetDistrictsByCanton(1),
                //DistrictsList = 
            };

            return View("Edit", editViewModel);
        }

        //
        // GET: /Users/Edit/{id}
        public ActionResult Edit(int id)
        {
            var store = _storesManagement.GetStore(id);
            var companies = _companiesManagement.GetCompanies();
            var canton = _locationsManagement.GetCantonByDistrict(store.District.DistrictId);
            var province = _locationsManagement.GetProvinceByCanton(canton.CantonId);
            var editViewModel = new EditViewModel
            {
                StoreId = store.StoreId,
                StoreName = store.StoreName,
                Company = store.Company,
                CompaniesList = companies,

                FaxNumber = store.FaxNumber,
                PhoneNumber1 = store.PhoneNumber1,
                PhoneNumber2 = store.PhoneNumber2,

                Province = province,
                ProvincesList = _locationsManagement.GetAllProvinces(),
                Canton = canton,
                CantonsList = _locationsManagement.GetCantonsByProvince(province.ProvinceId),
                District = store.District,
                DistrictsList = _locationsManagement.GetDistrictsByCanton(canton.CantonId),
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
                    store.UpdatedAt = DateTime.UtcNow;
                }

                _storesManagement.SaveStore(store);
            }
            var canton = _locationsManagement.GetCantonByDistrict(editFormModel.District.DistrictId);
            var province = _locationsManagement.GetProvinceByCanton(canton.CantonId);
            editViewModel.ProvincesList = _locationsManagement.GetAllProvinces();
            editViewModel.CantonsList = _locationsManagement.GetCantonsByProvince(province.ProvinceId);
            editViewModel.DistrictsList = _locationsManagement.GetDistrictsByCanton(canton.CantonId);
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
                FaxNumber = editFormModel.FaxNumber,
                PhoneNumber1 = editFormModel.PhoneNumber1,
                PhoneNumber2 = editFormModel.PhoneNumber2,
                DistrictsList = editFormModel.Districts,
                CompaniesList = editFormModel.CompaniesList,
                Province = editFormModel.Province,
                Canton = editFormModel.Canton,
                District = editFormModel.District,

            };
        }

        #endregion
    }
}