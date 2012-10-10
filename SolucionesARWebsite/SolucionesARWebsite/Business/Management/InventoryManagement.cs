using System.Collections.Generic;
using SolucionesARWebsite.DataAccess;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.Business.Management
{
    public class InventoryManagement
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly InventoryAccess _inventoryAccess;

        #endregion

        #region Constructors

        public InventoryManagement()
        {
            _inventoryAccess = new InventoryAccess();
        }

        #endregion

        #region Public Methods

        public List<Transaction> GetTransactions()
        {
            return _inventoryAccess.GetTransactions();
        }

        #endregion

        #region Private Methods
        #endregion
    }
}