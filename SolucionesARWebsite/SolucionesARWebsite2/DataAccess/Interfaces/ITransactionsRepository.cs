using System;
using System.Collections.Generic;
using System.Linq;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.DataAccess.Interfaces
{
    public interface ITransactionsRepository
    {
        List<Transaction> GetTransactions();

        List<Transaction> GetTransactions(User customer, Company company, DateTime endingDate, DateTime dateTime);

        List<Transaction> GetLastTransactions(int userId, int top);

        bool SaveTransaction(Transaction transaction);

        int SaveChangesMade();

        void UpdateTransaction();

        Transaction GetTransaction(int id);

        void RejectChanges();

    }
}
