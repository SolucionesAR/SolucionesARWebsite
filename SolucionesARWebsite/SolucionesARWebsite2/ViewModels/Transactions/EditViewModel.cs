using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SolucionesARWebsite2.Models;
using SolucionesARWebsite2.ViewModels.Lists;

namespace SolucionesARWebsite2.ViewModels.Transactions
{
    public class EditViewModel : BaseViewModel
    {
        #region Constants
        #endregion

        #region Properties
        public int TransactionId { get; set; }

        [Display(Name = "Codigo Fractura*", Prompt = "Codigo Fractura")]
        [Required]
        public string BillBarCode { get; set; }

        [Display(Name = "Monto*", Prompt = "000.00")]
        [Required]
        public double Amount { get; set; }

        [DisplayName("Compania")]
        [Required]
        public Company Company { get; set; }

        [DisplayName("Vendedor")]
        [Required]
        public User Customer { get; set; }

        public List<Company> CompaniesList { get; set; }

        [Display(Name = "Puntos*", Prompt = "50")]
        public int Points { get; set; }

        [Display(Name = "Fecha", Prompt = "01/01/1970")]
        public string TransactionDate { get; set; }

        [Display(Name = "Comision*", Prompt = "000.00")]
        public double Comision { get; set; }

        public List<UserToShow> UsersToShowList { get; set; }
        
        // public List<User> ListSalesMan { get; set; }
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