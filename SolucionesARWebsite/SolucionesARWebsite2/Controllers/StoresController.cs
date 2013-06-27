using System.Web.Mvc;
using SolucionesARWebsite2.Business.Management;
using SolucionesARWebsite2.Models;
using SolucionesARWebsite2.ViewModels.Lists;
using SolucionesARWebsite2.ViewModels.Stores;

namespace SolucionesARWebsite2.Controllers
{
    public class StoresController : BaseController
    {
        #region Private Members

        private readonly CompaniesManagement _companiesManagement;
        private readonly LocationsManagement _locationsManagement;
        private readonly StoresManagement _storesManagement;

        #endregion

        #region Constructors

        public StoresController(CompaniesManagement companiesManagement, UsersManagement usersManagement, StoresManagement storesManagement)
            : base(usersManagement)
        {
            _companiesManagement = companiesManagement;
            _storesManagement = storesManagement;
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
            var companies = _companiesManagement.GetCompaniesList();
            var editViewModel = new EditViewModel
            {
                StoreId = 0,
                StoreName = "",
                CompaniesList = companies,
                Company = new Company { CompanyId = 0 },
                FaxNumber = "",
                PhoneNumber1 = "",
                PhoneNumber2 = "",
                ProvinceId = _locationsManagement.GetProvince(1).ProvinceId,
                ProvincesList = _locationsManagement.GetAllProvinces(),
                CantonId = 1,
                CantonsList = _locationsManagement.GetCantonsByProvince(1),
                //CantonsList = 
                DistrictId = 1,
                DistrictsList = _locationsManagement.GetDistrictsByCanton(1),
                //DistrictsList = 
            };

            return View("Edit", editViewModel);
        }

        //
        // GET: /Stores/Edit/{id}
        public ActionResult Edit(int id)
        {
            var store = _storesManagement.GetStore(id);
            var companies = _companiesManagement.GetCompaniesList();
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

                ProvinceId = province.ProvinceId,
                ProvincesList = _locationsManagement.GetAllProvinces(),
                CantonId = canton.CantonId,
                CantonsList = _locationsManagement.GetCantonsByProvince(province.ProvinceId),
                DistrictId = store.DistrictId,
                DistrictsList = _locationsManagement.GetDistrictsByCanton(canton.CantonId),
            };
            return View(editViewModel);
        }

        //
        // POST: /Users/Save/{editeditFormModel}
        [HttpPost]
        public ActionResult Save(EditViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                _storesManagement.SaveStore(editViewModel);
                return RedirectToAction("Index");
            }
            var canton = _locationsManagement.GetCantonByDistrict(editViewModel.DistrictId);
            var province = _locationsManagement.GetProvinceByCanton(canton.CantonId);
            editViewModel.ProvincesList = _locationsManagement.GetAllProvinces();
            editViewModel.CantonsList = _locationsManagement.GetCantonsByProvince(province.ProvinceId);
            editViewModel.DistrictsList = _locationsManagement.GetDistrictsByCanton(canton.CantonId);
            editViewModel.CompaniesList = _companiesManagement.GetCompaniesList();
            return View("Edit", editViewModel);
        }

        #endregion

        #region Private Members

        #endregion
    }
}