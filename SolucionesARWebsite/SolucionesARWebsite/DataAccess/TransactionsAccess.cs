using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.DataAccess
{
    public class TransactionsAccess
    {

        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly DbModel _databaseModel;

        #endregion

        #region Contructors

        public TransactionsAccess()
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool SaveTransaction(Transaction transaction)
        {
            return _databaseModel.Transactions.Add(transaction) != null;
        }

        #endregion

        #region Private Methods
        #endregion


    }
}