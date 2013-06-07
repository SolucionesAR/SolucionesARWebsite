using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.ViewModels.Reports
{
    public class CustomerReportViewModel : BaseReportViewModel
    {
        #region Properties

        [DisplayName("Vendedor")]
        public User Customer { get; set; }

        [Required]
        [Display(Name = "Vendedor*", Prompt = "Seleccione un Usuario")]
        public List<UserToShow> UsersToShowList { get; set; }



        #endregion
    }
}