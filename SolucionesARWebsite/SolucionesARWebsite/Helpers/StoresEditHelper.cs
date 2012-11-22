using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using SolucionesARWebsite.ModelsWebsite.Views.Stores;

namespace SolucionesARWebsite.Helpers
{
    public static class StoresEditHelper
    {
        public static MvcHtmlString DropDownListForCompanieslList(this HtmlHelper<EditViewModel> htmlHelper,
            Expression<Func<EditViewModel, int>> expression)
        {
            return htmlHelper.DropDownListFor(expression,
                                              new SelectList(htmlHelper.ViewData.Model.CompaniesList, "CompanyId", "CompanyName",
                                                             htmlHelper.ViewData.Model.Company.CompanyId));
        }

        public static MvcHtmlString DropDownListForDistrictsList(this HtmlHelper<EditViewModel> htmlHelper,
            Expression<Func<EditViewModel, int>> expression)
        {
            return htmlHelper.DropDownListFor(expression,
                                              new SelectList(htmlHelper.ViewData.Model.Districts, "DistrictId", "Name",
                                                             htmlHelper.ViewData.Model.District.DistrictId));
        }
    }
}