using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using SolucionesARWebsite2.ViewModels.Reports;

namespace SolucionesARWebsite2.Helpers
{
    public static class ReportsEditHelper
    {
        public static MvcHtmlString DropDownListForCompaniesList(this HtmlHelper<CompanyReportViewModel> htmlHelper,
           Expression<Func<CompanyReportViewModel, int>> expression)
        {
            return htmlHelper.DropDownListFor(expression,
                                              new SelectList(htmlHelper.ViewData.Model.CompaniesList, "CompanyId", "CompanyName",
                                                             htmlHelper.ViewData.Model.Company.CompanyId));
        }


        public static MvcHtmlString DropDownListForCustomersListToShow(this HtmlHelper<CustomerReportViewModel> htmlHelper,
           Expression<Func<CustomerReportViewModel, int>> expression)
        {
            return htmlHelper.DropDownListFor(expression,
                                              new SelectList(htmlHelper.ViewData.Model.UsersToShowList, "UserToShowId", "CustomerName", 
                                                             htmlHelper.ViewData.Model.Customer.UserId));
        }

        
    }
}