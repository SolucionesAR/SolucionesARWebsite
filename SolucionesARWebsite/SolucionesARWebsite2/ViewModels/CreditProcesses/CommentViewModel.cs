using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolucionesARWebsite2.ViewModels.CreditProcesses
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public DateTime CommentDate { get; set; }

        public int CreditProcessId { get; set; }

        public bool IsNew { get; set; }
    }
}