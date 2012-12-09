using System.Collections.Generic;
using SolucionesARWebsite.Business.Logic;
using SolucionesARWebsite.DataAccess;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.Business.Management
{
    public class TransactionsManagement
    {

        #region Constants

        private const int TOP_LAST_TRANSACTIONS = 10;

        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly TransactionsAccess _transactionsAccess;
        private readonly TransactionsLogic _transactionsLogic;

        #endregion

        #region Constructors

        public TransactionsManagement(TransactionsLogic transactionsLogic)
        {
            _transactionsLogic = transactionsLogic;

            _transactionsAccess = new TransactionsAccess();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Transaction> GetTransactions()
        {
            return _transactionsAccess.GetTransactions();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Transaction> GetLastTransactions(int userId)
        {
            return _transactionsAccess.GetLastTransactions(userId, TOP_LAST_TRANSACTIONS);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transaction"></param>
        public void SaveTransaction(Transaction transaction)
        {
            bool saveSuccess = _transactionsAccess.SaveTransaction(transaction);
            if (saveSuccess)
            {
                //TODO: aca recibo un  bool de exito, ver si lo ocupo
                _transactionsLogic.DistributeTransactionCashback(transaction);
            }

        }

        public Transaction GetTransaction(int id)
        {
            return _transactionsAccess.GetTransaction(id);
        }

        public bool SaveTransactions(string filename, string sheetName)
        {
            return _transactionsLogic.SaveTransactionsFromFile(filename, sheetName);
        }

        public void UpdateTransaction()
        {
            _transactionsAccess.UpdateTransaction();
        }
        #endregion

        #region Private Methods
        #endregion    
    }
}