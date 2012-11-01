using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using SolucionesARWebsite.ModelsWebsite.Views.Users;

namespace SolucionesARWebsite.Helpers
{
    public static class UserEditHelper
    {
        public static MvcHtmlString DropDownListForRolesList(this HtmlHelper<EditViewModel> htmlHelper,
            Expression<Func<EditViewModel, int>> expression)
        {
            return htmlHelper.DropDownListFor(expression,
                                              new SelectList(htmlHelper.ViewData.Model.RolesList, "RolId", "Name",
                                                             htmlHelper.ViewData.Model.Rol.RolId));
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
    }
}