﻿using System;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.ViewModels.Transactions
{
    public class DetailsViewModel : BaseViewModel
    {
        #region Constants
        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public int TransactionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string BillBarCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Comision { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Company Company { get; set; }


        public DateTime TransactionDate { get; set; }


        /// <summary>
        /// The one who sales in the store
        /// </summary>
        //public User SalesMan { get; set; }

        /// <summary>
        /// The one that makes the purchase
        /// </summary>
        public User Customer { get; set; }

        #endregion

        #region Private Members
        #endregion

        #region Contructors
        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion
    }
}