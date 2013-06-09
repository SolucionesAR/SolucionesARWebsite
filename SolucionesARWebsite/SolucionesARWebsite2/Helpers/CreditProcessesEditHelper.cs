using System;
using System.Collections;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using SolucionesARWebsite2.ViewModels.CreditProcesses;

namespace SolucionesARWebsite2.Helpers
{
    public static class CreditProcessesEditHelper
    {
        public static MvcHtmlString DropDownListForCreditStatuses(this HtmlHelper<EditViewModel> htmlHelper,
            Expression<Func<EditViewModel, int>> expression)
        {
            return htmlHelper.DropDownListFor(expression,
                                              new SelectList(htmlHelper.ViewData.Model.CreditStatusesList, "CreditStatusId", "CreditStatusDescription",
                                                             htmlHelper.ViewData.Model.CreditStatus.CreditStatusId));
        }

        public static MvcHtmlString DropDownListForCustomersList(this HtmlHelper<EditViewModel> htmlHelper,
            Expression<Func<EditViewModel, int>> expression)
        {
            return htmlHelper.DropDownListFor(expression,
                                              new SelectList(htmlHelper.ViewData.Model.CustomersList, "UserToShowId", "CustomerName",
                                                             htmlHelper.ViewData.Model.Customer.CustomerId));
        }

        public static MvcHtmlString DropDownListForUsersList(this HtmlHelper<EditViewModel> htmlHelper,
            Expression<Func<EditViewModel, int>> expression)
        {
            return htmlHelper.DropDownListFor(expression,
                                              new SelectList(htmlHelper.ViewData.Model.SalesmenList, "UserToShowId", "CustomerName",
                                                             htmlHelper.ViewData.Model.Salesman.UserId));
        }
        
        public static MvcHtmlString DropDownListForCompaniesList(this HtmlHelper<EditViewModel> htmlHelper,
            Expression<Func<EditViewModel, int>> expression)
        {
            return htmlHelper.DropDownListFor(expression,
                                              new SelectList(htmlHelper.ViewData.Model.FinantialCompaniesList, "CompanyId", "CompanyName",
                                                             htmlHelper.ViewData.Model.FinantialCompany.CompanyId));
        }     
    }
}