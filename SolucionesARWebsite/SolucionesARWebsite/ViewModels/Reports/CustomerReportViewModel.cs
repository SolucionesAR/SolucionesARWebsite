using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.ViewModels.Reports
{
    public class CustomerReportViewModel : BaseReportViewModel
    {
        #region Properties

        [DisplayName("Vendedor")]
        public User Customer { get; set; }

        [Required]
        [Display(Name = "Vendedor*", Prompt = "Seleccione un Usuario")]
        public List<User> CustomerList { get; set; }

        #endregion
    }
}