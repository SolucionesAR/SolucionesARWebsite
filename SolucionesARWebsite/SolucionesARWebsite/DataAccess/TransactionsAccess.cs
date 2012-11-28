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
        /// <returns></returns>
        public List<Transaction> GetLastTransactions(int userId, int top)
        {
            var transactions =
                _databaseModel.Transactions
                    .Where(t => t.CustomerId.Equals(userId))
                    .OrderByDescending(t => t.CreatetedAt)
                    .Take(top).ToList();
            return transactions;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool SaveTransaction(Transaction transaction)
        {
            var result = _databaseModel.Transactions.Add(transaction);
            _databaseModel.SaveChanges();
            return result != null;
        }


        public Transaction GetTransaction(int id)
        {

            return _databaseModel.Transactions.FirstOrDefault(t => t.TransactionId == id);
        }

        #endregion

        #region Private Methods
        #endregion


    }
}