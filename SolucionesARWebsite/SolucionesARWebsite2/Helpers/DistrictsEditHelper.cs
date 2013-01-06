using System;
using System.Collections;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using SolucionesARWebsite2.ViewModels.Districts;

namespace SolucionesARWebsite2.Helpers
{
    public static class DistrictsEditHelper
    {
        public static MvcHtmlString DropDownListForProviceslList(this HtmlHelper<EditViewModel> htmlHelper,
            IEnumerable provincesList, Expression<Func<EditViewModel, int>> expression)
        {
            return htmlHelper.DropDownListFor(expression,
                                              new SelectList(provincesList, "ProvinceId", "Name",
                                                             htmlHelper.ViewData.Model.ProvinceId));
        }

        public static MvcHtmlString DropDownListForCantonslList(this HtmlHelper<EditViewModel> htmlHelper,
            IEnumerable cantonsList, Expression<Func<EditViewModel, int>> expression)
        {
            return htmlHelper.DropDownListFor(expression,
                                              new SelectList(cantonsList, "CantonId", "Name",
                                                             htmlHelper.ViewData.Model.CantonId));
        }
    }
}