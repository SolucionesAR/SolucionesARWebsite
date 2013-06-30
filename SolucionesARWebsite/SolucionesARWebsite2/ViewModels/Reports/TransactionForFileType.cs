namespace SolucionesARWebsite2.ViewModels.Reports
{
    public class TransactionForFileType
    {
        public string BillBarCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// The amount of points earned for the transaction
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CustomerCode { get; set; }

        /// <summary>
        /// The one that makes the purchase
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CreatetedAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        //public string StoreName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CompanyName { get; set; }
    }
}