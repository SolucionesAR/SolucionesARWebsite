using System.Collections.Generic;
using System.Linq;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.DataAccess
{
    public class InventoryAccess
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly DbModel _databaseModel;

        #endregion

        #region Contructors

        public InventoryAccess()
        {
            _databaseModel = new DbModel();
        }

        #endregion

        #region Public Methods
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Transaction> GetTransactions()
        {
            var transactions = _databaseModel.Transactions.ToList();
            return transactions;
        }

        #endregion

        #region Private Methods
        #endregion
    }
}