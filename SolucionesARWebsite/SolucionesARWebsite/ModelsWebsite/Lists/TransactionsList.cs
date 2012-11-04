using System.Collections.Generic;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.Utils;

namespace SolucionesARWebsite.ModelsWebsite.Lists
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

    public class TransactionsList : ListWrapper
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

        /// <summary>
        /// Gets or sets the current sorting field.
        /// </summary>
        /// <value></value>
        public new TransactionsListSortField SortField
        {
            get
            {
                return (TransactionsListSortField)base.SortField;
            }
            set
            {
                base.SortField = value;
            }
        }

        /// <summary>
        /// Gets or sets the filters.
        /// </summary>
        /// <value>The filters.</value>
        public new Dictionary<TransactionsListFilter, string> Filters
        {
            get
            {
                return (Dictionary<TransactionsListFilter, string>)base.Filters;
            }
            set
            {
                base.Filters = value;
            }
        }

        #endregion

        #region Constructors

        public TransactionsList()
        {
        }

        public TransactionsList(TransactionsListSortField sort, SortDirectionType dir, Dictionary<TransactionsListFilter, string> filters)
            : base(sort, dir, filters)
        {
        }

        #endregion
    }
}