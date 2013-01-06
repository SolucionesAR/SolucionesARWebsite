using System.Collections.Generic;
using System.Data;
using System.Linq;
using SolucionesARWebsite2.DataAccess.Interfaces;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.DataAccess.Repositories
{
    public class StoresRepository : IStoresRepository
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly DbModel _databaseModel;

        #endregion

        #region Contructors

        public StoresRepository()
        {
            _databaseModel = new DbModel();
        }

        #endregion

        #region Public Methods

        public void AddStore(Store store)
        {
            _databaseModel.Stores.Add(store);
            _databaseModel.SaveChanges();
        }

        public void EditStore(Store store)
        {
            _databaseModel.Entry(store).State = EntityState.Modified;
            _databaseModel.SaveChanges();
        }

        public List<Store> GetStores()
        {
            var stores = _databaseModel.Stores.ToList();
            return stores;
        }

        public Store GetStore(int storeId)
        {

            return _databaseModel.Stores.FirstOrDefault(p => p.StoreId == storeId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="store"></param>
        public void SaveStore(Store store)
        {
            _databaseModel.Stores.Add(store);
            _databaseModel.SaveChanges();
        }

        public Store GetStore(string storeName)
        {
            return _databaseModel.Stores.FirstOrDefault(s => s.StoreName.ToLower().Equals(storeName.ToLower()));
        }

        #endregion

        #region Private Methods
        #endregion
    }
}