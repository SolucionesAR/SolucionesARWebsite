using System;
using System.Collections;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using SolucionesARWebsite.ViewModels.Users;

namespace SolucionesARWebsite.Helpers
{
    public static class UserEditHelper
    {
        public static MvcHtmlString DropDownListForRolesList(this HtmlHelper<EditViewModel> htmlHelper,
            Expression<Func<EditViewModel, int>> expression)
        {
            return htmlHelper.DropDownListFor(expression,
                                              new SelectList(htmlHelper.ViewData.Model.RolesList, "RolId", "Name",
                                                             htmlHelper.ViewData.Model.UserRol.RolId));
        }

        public static MvcHtmlString DropDownListForRelationshipTypeslList(this HtmlHelper<EditViewModel> htmlHelper,
            Expression<Func<EditViewModel, int>> expression)
        {
            return htmlHelper.DropDownListFor(expression,
                                              new SelectList(htmlHelper.ViewData.Model.RelationshipTypeList, "RelationshipTypeId", "Description",
                                                             htmlHelper.ViewData.Model.RelationshipType.RelationshipTypeId));
        }

        public static MvcHtmlString DropDownListForCompanieslList(this HtmlHelper<EditViewModel> htmlHelper,
            Expression<Func<EditViewModel, int>> expression)
        {
            return htmlHelper.DropDownListFor(expression,
                                              new SelectList(htmlHelper.ViewData.Model.CompaniesList, "CompanyId", "CompanyName",
                                                             htmlHelper.ViewData.Model.Company.CompanyId));
        }

        public static MvcHtmlString DropDownListForIdenficationlList(this HtmlHelper<EditViewModel> htmlHelper,
            Expression<Func<EditViewModel, int>> expression)
        {
            return htmlHelper.DropDownListFor(expression,
                                              new SelectList(htmlHelper.ViewData.Model.IdentificationTypesList, "IdentificationTypeId", "IdentificationDescription",
                                                             htmlHelper.ViewData.Model.IdentificationType.IdentificationTypeId));
        }

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

        public static MvcHtmlString DropDownListForDistrictslList(this HtmlHelper<EditViewModel> htmlHelper,
            IEnumerable districtsList, Expression<Func<EditViewModel, int>> expression)
        {
            return htmlHelper.DropDownListFor(expression,
                                              new SelectList(districtsList, "DistrictId", "Name",
                                                             htmlHelper.ViewData.Model.DistrictId));
        }
    }
}