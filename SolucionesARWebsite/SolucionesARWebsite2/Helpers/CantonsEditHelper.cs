﻿using System;
using System.Collections;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using SolucionesARWebsite2.ViewModels.Cantons;

namespace SolucionesARWebsite2.Helpers
{
    public static class CantonsEditHelper
    {
        public static MvcHtmlString DropDownListForProviceslList(this HtmlHelper<EditViewModel> htmlHelper,
            IEnumerable provincesList, Expression<Func<EditViewModel, int>> expression)
        {
            return htmlHelper.DropDownListFor(expression,
                                              new SelectList(provincesList, "ProvinceId", "Name",
                                                             htmlHelper.ViewData.Model.ProvinceId));
        }
    }
}