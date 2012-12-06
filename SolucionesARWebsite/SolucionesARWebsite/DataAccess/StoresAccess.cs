using System.Collections.Generic;
using System.Linq;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.DataAccess
{
    public class StoresAccess
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly DbModel _databaseModel;

        #endregion

        #region Contructors

        public StoresAccess()
        {
            _databaseModel = new DbModel();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Store> GetStores()
        {
            var stores = _databaseModel.Stores.ToList();
            return stores;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
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

        #endregion

        #region Private Methods
        #endregion

        public Store GetStore(string storeName)
        {
            return _databaseModel.Stores.FirstOrDefault(s => s.StoreName.ToLower().Equals(storeName.ToLower()));
        }
    }
}