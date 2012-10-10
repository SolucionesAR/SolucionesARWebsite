using System.Collections.Generic;
using SolucionesARWebsite.DataAccess;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.Business.Management
{
    public class StoresManagement
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly StoresAccess _storesAccess;

        #endregion

        #region Constructors

        public StoresManagement()
        {
            _storesAccess = new StoresAccess();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Store> GetStores()
        {
            return _storesAccess.GetStores();
        }

        #endregion

        #region Private Methods
        #endregion
    }
}