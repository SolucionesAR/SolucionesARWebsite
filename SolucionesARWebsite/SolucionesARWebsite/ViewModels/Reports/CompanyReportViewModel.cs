using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.ViewModels.Reports
{
    public class CompanyReportViewModel : BaseReportViewModel
    {
        #region Properties

        [DisplayName("Compañía")]
        public Company Company { get; set; }

        [Required]
        [Display(Name = "Compañía*", Prompt = "Seleccione una Compañía")]
        public List<Company> CompaniesList { get; set; }

        #endregion
    }
}