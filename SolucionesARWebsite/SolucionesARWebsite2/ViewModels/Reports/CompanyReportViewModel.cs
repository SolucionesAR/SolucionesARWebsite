using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.ViewModels.Reports
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