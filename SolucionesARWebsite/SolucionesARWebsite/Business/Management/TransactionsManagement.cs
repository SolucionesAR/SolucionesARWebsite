using System;
using System.Collections.Generic;
using SolucionesARWebsite.Business.Logic;
using SolucionesARWebsite.DataAccess.Interfaces;
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

        private readonly ITransactionsRepository _transactionsRepository;
        private readonly TransactionsLogic _transactionsLogic;

        #endregion

        #region Constructors

        public TransactionsManagement(TransactionsLogic transactionsLogic, ITransactionsRepository transactionsRepository)
        {
            _transactionsLogic = transactionsLogic;
            _transactionsRepository = transactionsRepository;    
        }

        #endregion

        #region Public Methods

        public List<Transaction> GetTransactions()
        {
            return _transactionsRepository.GetTransactions();
        }

        public List<Transaction> GetTransactions(DateTime beginningDate, DateTime endingDate)
        {
            return _transactionsRepository.GetTransactions(null, null, beginningDate, endingDate);
        }

        public List<Transaction> GetTransactions(Company company, DateTime beginningDate, DateTime endingDate)
        {
            return _transactionsRepository.GetTransactions(null, company, beginningDate, endingDate);
        }

        public List<Transaction> GetTransactions(User customer, DateTime beginningDate, DateTime endingDate)
        {
            return _transactionsRepository.GetTransactions(customer, null, beginningDate, endingDate);
        }

        public List<Transaction> GetLastTransactions(int userId)
        {
            return _transactionsRepository.GetLastTransactions(userId, TOP_LAST_TRANSACTIONS);
        }

        public void SaveTransaction(Transaction transaction)
        {
            bool saveSuccess = _transactionsRepository.SaveTransaction(transaction);
            if (saveSuccess)
            {
                //TODO: aca recibo un  bool de exito, ver si lo ocupo
                _transactionsLogic.DistributeTransactionCashback(transaction);
            }

        }

        public Transaction GetTransaction(int id)
        {
            return _transactionsRepository.GetTransaction(id);
        }

        public bool SaveTransactions(string filename, string sheetName)
        {
            return _transactionsLogic.SaveTransactionsFromFile(filename, sheetName);
        }

        public void UpdateTransaction()
        {
            _transactionsRepository.UpdateTransaction();
        }
        #endregion

        #region Private Methods
        #endregion    
    }
}