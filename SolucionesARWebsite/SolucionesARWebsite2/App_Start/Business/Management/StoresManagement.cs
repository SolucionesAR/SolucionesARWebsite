using System;
using System.Collections.Generic;
using SolucionesARWebsite2.DataAccess.Interfaces;
using SolucionesARWebsite2.Models;
using SolucionesARWebsite2.ViewModels.Stores;

namespace SolucionesARWebsite2.Business.Management
{
    public class StoresManagement
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly IStoresRepository _storesRepository;

        #endregion

        #region Constructors

        public StoresManagement(IStoresRepository storesRepository)
        {
            _storesRepository = storesRepository;
        }

        #endregion

        #region Public Methods
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Store> GetStores()
        {
            return _storesRepository.GetStores();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public Store GetStore(int storeId)
        {
            return _storesRepository.GetStore(storeId);
        }

        public void SaveStore(EditViewModel editViewModel)
        {
            var store = Map(editViewModel);

            if (editViewModel.StoreId == 0)
            {
                AddStore(store);
            }
            else
            {
                EditStore(store);
            }
        }
        #endregion

        #region Private Methods

        private void AddStore(Store store)
        {
            store.CreatetedAt = DateTime.UtcNow;
            store.UpdatedAt = DateTime.UtcNow;
            _storesRepository.AddStore(store);
        }

        private void EditStore(Store store)
        {
            store.UpdatedAt = DateTime.UtcNow;
            _storesRepository.EditStore(store);
        }

        private static Store Map(EditViewModel editViewModel)
        {
            return new Store
                       {
                           StoreId = editViewModel.StoreId,
                           //Company = _companiesManagement.GetCompany( editFormModel.Company.CompanyId),
                           CompanyId = editViewModel.Company.CompanyId,
                           DistrictId = editViewModel.DistrictId,
                           FaxNumber = editViewModel.FaxNumber,
                           PhoneNumber1 = editViewModel.PhoneNumber1,
                           PhoneNumber2 = editViewModel.PhoneNumber2,
                           StoreName = editViewModel.StoreName.ToUpper(),
                       };
        }

        #endregion
    }
}