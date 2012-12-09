using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using SolucionesARWebsite.ViewModels.Views.Transactions;

namespace SolucionesARWebsite.Helpers
{
    public static class TransactionsEditHelper
    {
        public static MvcHtmlString DropDownListForStoresList(this HtmlHelper<EditViewModel> htmlHelper,
            Expression<Func<EditViewModel, int>> expression)
        {
            return htmlHelper.DropDownListFor(expression,
                                              new SelectList(htmlHelper.ViewData.Model.StoresList, "StoreId", "StoreName",
                                                             htmlHelper.ViewData.Model.Store.StoreId));
        }


        public static MvcHtmlString DropDownListForCustomersList(this HtmlHelper<EditViewModel> htmlHelper,
           Expression<Func<EditViewModel, int>> expression)
        {
            return htmlHelper.DropDownListFor(expression,
                                              new SelectList(htmlHelper.ViewData.Model.CustomersList, "UserId", "FName",
                                                             htmlHelper.ViewData.Model.Customer.UserId));
        }

        
    }
}