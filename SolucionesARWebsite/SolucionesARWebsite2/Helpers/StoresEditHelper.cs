﻿using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using SolucionesARWebsite2.ViewModels.Stores;

namespace SolucionesARWebsite2.Helpers
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

        public static MvcHtmlString DropDownListForProviceslList(this HtmlHelper<EditViewModel> htmlHelper,
            Expression<Func<EditViewModel, int>> expression)
        {
            return htmlHelper.DropDownListFor(expression,
                                              new SelectList(htmlHelper.ViewData.Model.ProvincesList, "ProvinceId", "Name",
                                                             htmlHelper.ViewData.Model.ProvinceId));
        }

        public static MvcHtmlString DropDownListForCantonslList(this HtmlHelper<EditViewModel> htmlHelper,
            Expression<Func<EditViewModel, int>> expression)
        {
            return htmlHelper.DropDownListFor(expression,
                                              new SelectList(htmlHelper.ViewData.Model.CantonsList, "CantonId", "Name",
                                                             htmlHelper.ViewData.Model.CantonId));
        }

        public static MvcHtmlString DropDownListForDistrictslList(this HtmlHelper<EditViewModel> htmlHelper,
            Expression<Func<EditViewModel, int>> expression)
        {
            return htmlHelper.DropDownListFor(expression,
                                              new SelectList(htmlHelper.ViewData.Model.DistrictsList, "DistrictId", "Name",
                                                             htmlHelper.ViewData.Model.DistrictId));
        }
    }
}