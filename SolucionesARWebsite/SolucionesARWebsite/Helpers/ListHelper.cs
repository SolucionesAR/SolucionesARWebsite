using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using SolucionesARWebsite.Controllers;

namespace SolucionesARWebsite.Helpers
{
    public static class ListHelper
    {
        #region Constants
        
        const string PageSizeTag = "page_size";
        const string PageSizeValue = "{0} per page";
        const string SelectPageSizeOpen = "<div class=\"{0}\">View: <select id=\"{0}\" name=\"{0}\" onchange=\"javascript:filterList();\">";
        const string SelectItemFormat = "<option value=\"{0}\">{1}</option>";
        const string SelectItemSelFormat = "<option value=\"{0}\" selected=\"selected\">{1}</option>";
        const string SelectPageSizeClose = "</select></div>";
        const string SELECT_PAGE_SIZE_OPEN = "<div class=\"{0}\">View: <select id=\"{0}\" name=\"{0}\" onchange=\"javascript:filterList();\">";
        
        const string TEXTBOX_FORMAT = "<input type=\"text\" id=\"{0}\" name=\"{0}\" value=\"{1}\" onchange=\"javascript:filterList();\" {2}/>";
        const string SELECT_OPEN_FORMAT = "<select id=\"{0}\" name=\"{0}\" onchange=\"javascript:filterList();\">";
        const string SELECT_CLOSE_FORMAT = "</select>";
        
        #endregion

        #region Properties
        #endregion

        #region Private Members
        #endregion

        #region Public Methods

        public static MvcHtmlString TotalItems(int quantity, string label)
        {
            var spanTotal = string.Format("<span class=\"total-items\">{0} {1}</span>", quantity, label);
            return MvcHtmlString.Create(spanTotal);
        }

        public static MvcHtmlString DropDownListForPaging(this HtmlHelper htmlHelper, int quantityItems, int lapsesOf, RouteValueDictionary routeValues)
        {
            var initialPosition = Convert.ToInt32(ConfigurationManager.AppSettings[PageSizeTag]);
            var selectedValue = routeValues != null && routeValues.ContainsKey(PageSizeTag)
                                    ? Convert.ToString(routeValues[PageSizeTag])
                                    : string.Empty;
            return DropDownListForPaging(initialPosition, selectedValue, quantityItems, lapsesOf);
        }

        #endregion

        #region Private Methods

        private static MvcHtmlString DropDownListForPaging(int initialPosition, string selectedValue, int quantityItems, int lapsesOf)
        {
            var values = new List<ListFilterValue>();
            for (int i = 0; i < quantityItems; i++)
            {
                var value = Convert.ToString(initialPosition + ((i * lapsesOf) * i));
                values.Add(new ListFilterValue(new StringBuilder().AppendFormat(PageSizeValue, value).ToString(), value));
            }

            return DropDownListForPaging(PageSizeTag, selectedValue, values, Convert.ToString(initialPosition));
        }
        
        private static MvcHtmlString DropDownListForPaging(string name, string selectedValue, List<ListFilterValue> values, string selectLabel)
        {
            var strBuilder = new StringBuilder();
            strBuilder.AppendFormat(SelectPageSizeOpen, name);

            for (int i = 0; i < values.Count; i++)
            {
                if (!string.IsNullOrEmpty(selectedValue) && values[i].Value.Equals(selectedValue))
                    strBuilder.AppendFormat(SelectItemSelFormat, values[i].Value, values[i].Name);
                else
                    strBuilder.AppendFormat(SelectItemFormat, values[i].Value, values[i].Name);
            }
            strBuilder.Append(SelectPageSizeClose);

            return MvcHtmlString.Create(strBuilder.ToString());
        }
        #endregion
    }
}