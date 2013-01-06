using System.Collections;
using System.Collections.Generic;
using System.Web;

namespace SolucionesARWebsite2.ViewModels
{
    public class SubmitResults : ModelErrors
    {
        /// <summary>
        /// Gets or sets a value indicating whether [submit success].
        /// </summary>
        /// <value><c>true</c> if [submit success]; otherwise, <c>false</c>.</value>
        public bool SuccessSubmit
        {
            get
            {
                return !string.IsNullOrEmpty(SuccessMessage);
            }
        }

        /// <summary>
        /// Gets or sets the success message.
        /// </summary>
        /// <value>The success message.</value>
        public string SuccessMessage
        {
            get
            {
                return Items[SUCCESS_MESSAGE_KEY] as string;
            }
            set
            {
                Items[SUCCESS_MESSAGE_KEY] = value;
            }
        }

        private const string SUCCESS_MESSAGE_KEY = "SuccessMessage";

        private readonly IDictionary _items = new Dictionary<string, object>();

        private IDictionary Items
        {
            get { return HttpContext.Current != null ? HttpContext.Current.Items : _items; }
        }
    }
}