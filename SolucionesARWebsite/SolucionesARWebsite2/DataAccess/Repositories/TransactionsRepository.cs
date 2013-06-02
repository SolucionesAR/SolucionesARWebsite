using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using SolucionesARWebsite2.DataAccess.Interfaces;
using SolucionesARWebsite2.Models;
using DbModel = SolucionesARWebsite2.Models.DbModel;

namespace SolucionesARWebsite2.DataAccess.Repositories
{
    public class TransactionsRepository : ITransactionsRepository
    {
        #region Private Members

        private readonly DbModel _databaseModel;

        #endregion

        #region Contructors

        public TransactionsRepository()
        {
            _databaseModel = new DbModel();
        }

        #endregion

        #region Public Methods

        public List<Transaction> GetTransactions()
        {
            var transactions = _databaseModel.Transactions.ToList();
            return transactions;
        }

        public List<Transaction> GetTransactions(User customer, Company company, DateTime beginningDate, DateTime endingDate)
        {
            var transactions = _databaseModel.Transactions
                .Where(t => (beginningDate <= t.CreatetedAt) && (t.CreatetedAt <= endingDate))
                .OrderByDescending(t => t.CreatetedAt);

            if (customer != null)
            {
                var filteredTransactions = transactions.Where(t => t.UserId.Equals(customer.UserId));
                return filteredTransactions.ToList();
            }
            if (company != null)
            {
               // var storesList = _databaseModel.Stores.Where(s => s.CompanyId.Equals(company.CompanyId));
               // var filteredTransactions = transactions.Join(storesList, t => t.StoreId, s => s.StoreId,
                                                            // (o, id) => o);
                var filteredTransactions = transactions.Where(t => t.CompanyId.Equals(company.CompanyId));
                return filteredTransactions.ToList();
            }
            return transactions.ToList();
        }

        public List<Transaction> GetLastTransactions(int userId, int top)
        {
            var transactions =
                _databaseModel.Transactions
                    .Where(t => t.UserId.Equals(userId))
                    .OrderByDescending(t => t.CreatetedAt)
                    .Take(top).ToList();
            return transactions;
        }

        public bool SaveTransaction(Transaction transaction)
        {
            var result = _databaseModel.Transactions.Add(transaction);
            //_databaseModel.SaveChanges();
            return result != null;
        }

        public int SaveChangesMade ()
        {
            return _databaseModel.SaveChanges();
        }


        public Transaction GetTransaction(int id)
        {

            return _databaseModel.Transactions.FirstOrDefault(t => t.TransactionId == id);
        }

        public void UpdateTransaction()
        {
            _databaseModel.SaveChanges();
        }

        public void RejectChanges()
        {
            var context = ((IObjectContextAdapter)_databaseModel).ObjectContext;
            foreach (var change in _databaseModel.ChangeTracker.Entries())
            {
                if (change.State == EntityState.Modified)
                {
                    context.Refresh(RefreshMode.StoreWins, change.Entity);
                }
                if (change.State == EntityState.Added)
                {
                    context.Detach(change.Entity);
                }
            }
        }

        #endregion

        #region Private Methods
        #endregion
    }
}