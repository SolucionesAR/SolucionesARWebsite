using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using SolucionesARWebsite2.ViewModels.Transactions;

namespace SolucionesARWebsite2.Helpers
{
    public static class TransactionsEditHelper
    {
        public static MvcHtmlString DropDownListForCompaniesList(this HtmlHelper<EditViewModel> htmlHelper,
            Expression<Func<EditViewModel, int>> expression)
        {
            return htmlHelper.DropDownListFor(expression,
                                              new SelectList(htmlHelper.ViewData.Model.CompaniesList, "CompanyId", "CompanyNickName",
                                                             htmlHelper.ViewData.Model.Company.CompanyId));
        }


        public static MvcHtmlString DropDownListForCustomersListToShow(this HtmlHelper<EditViewModel> htmlHelper,
           Expression<Func<EditViewModel, int>> expression)
        {
            return htmlHelper.DropDownListFor(expression,
                                              new SelectList(htmlHelper.ViewData.Model.UsersToShowList, "UserToShowId", "CustomerName", //TODO: ver si esto se vale...
                                                             htmlHelper.ViewData.Model.Customer.UserId));
        }

        
    }
}