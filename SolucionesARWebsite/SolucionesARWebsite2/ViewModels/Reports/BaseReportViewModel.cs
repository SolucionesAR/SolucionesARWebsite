using System;
using System.ComponentModel.DataAnnotations;

namespace SolucionesARWebsite2.ViewModels.Reports
{
    public class BaseReportViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// The beginning date
        /// </summary>
        [Required]
        [Display(Name = "Fecha Inicial*", Prompt = "Fecha Inicial")]
        [DataType(DataType.Date)]
        public DateTime BeginningDate { get; set; }

        /// <summary>
        /// The ending date
        /// </summary>
        [Required]
        [Display(Name = "Fecha Final*", Prompt = "Fecha Final")]
        [DataType(DataType.Date)]
        public DateTime EndingDate { get; set; }

        #endregion
    }
}