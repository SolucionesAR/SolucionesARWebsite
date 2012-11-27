using System.Collections.Generic;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.Utils;

namespace SolucionesARWebsite.ViewModels.Lists
{
    #region enums

    public enum TransactionsListSortField
    {
        [Value("transaction_id")]
        Id,
        [Value("bill_bar_code")]
        BillBarCode,
        [Value("amount")]
        Amount,
        [Value("store")]
        Store,
        [Value("sales_man")]
        SalesMan,
        [Value("customer")]
        Customer,
        [Value("created_at")]
        CreatedAt,
    }

    public enum TransactionsListFilter
    {
        [Value("transaction_id")]
        Id,
        [Value("bill_bar_code")]
        BillBarCode,
        [Value("amount")]
        Amount,
        [Value("store")]
        Store,
        [Value("sales_man")]
        SalesMan,
        [Value("customer")]
        Customer,

    }

    #endregion

    public class TransactionsList : BaseListModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the counts.
        /// </summary>
        /// <value>The counts.</value>
        public new List<Transaction> Items
        {
            get
            {
                return (List<Transaction>)base.Items;
            }
            set
            {
                base.Items = value;
            }
        }

        #endregion

        #region Constructors

        public TransactionsList()
        {
        }

        public TransactionsList(TransactionsListSortField sort, SortDirectionType dir, Dictionary<TransactionsListFilter, string> filters)
        {
        }

        #endregion
    }
}