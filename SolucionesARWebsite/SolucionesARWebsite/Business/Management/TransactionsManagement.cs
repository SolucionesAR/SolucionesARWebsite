﻿using System.Collections.Generic;
using SolucionesARWebsite.Business.Logic;
using SolucionesARWebsite.DataAccess;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.Business.Management
{
    public class TransactionsManagement
    {

        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly TransactionsAccess _transactionsAccess;
        private readonly TransactionsLogic _transactionsLogic;

        #endregion

        #region Constructors

        public TransactionsManagement()
        {
            _transactionsAccess = new TransactionsAccess();
            _transactionsLogic = new TransactionsLogic();
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
        /// <param name="transaction"></param>
        public void SaveTransaction(Transaction transaction)
        {
            bool saveSuccess = _transactionsAccess.SaveTransaction(transaction);
            if (saveSuccess)
            {
                _transactionsLogic.DistributeTransactionCashback(transaction);
            }
            
        }

        #endregion
        
        #region Private Methods
        #endregion
    }
}