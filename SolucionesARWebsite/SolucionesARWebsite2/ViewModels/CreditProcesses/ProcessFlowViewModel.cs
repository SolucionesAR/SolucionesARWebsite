namespace SolucionesARWebsite2.ViewModels.CreditProcesses
{
    public class ProcessFlowViewModel : BaseViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int CreditProcessXCompanyId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CreditStatusId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CreditProcessId { get; set; }

        public bool IsNew { get; set; }

        public bool IsDeleted { get; set; }
    }
}