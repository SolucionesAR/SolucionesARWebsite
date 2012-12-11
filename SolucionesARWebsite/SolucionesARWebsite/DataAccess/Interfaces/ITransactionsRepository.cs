using System;
using System.Collections.Generic;
using System.Linq;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.DataAccess.Interfaces
{
    public interface ITransactionsRepository
    {
        List<Transaction> GetTransactions();

        List<Transaction> GetTransactions(User customer, Company company, DateTime endingDate, DateTime dateTime);

        List<Transaction> GetLastTransactions(int userId, int top);

        bool SaveTransaction(Transaction transaction);

        void UpdateTransaction();

        Transaction GetTransaction(int id);
        
    }
}
