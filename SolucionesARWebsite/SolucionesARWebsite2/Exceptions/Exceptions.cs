using System.Web;

namespace SolucionesARWebsite2.Exceptions
{
    public class Exceptions
    {
    }

    /// <summary>
    /// Represent errors that occur when the user tries to login with an invalid username
    /// </summary>
    public class UnautorizedException : HttpException
    {
        public string Controller { get; set; }

        public string Action { get; set; }

        public string Parameters { get; set; }

        public UnautorizedException(int httpStatusCode, string message, string controller, string action)
            : base(httpStatusCode, message)
        {
            Controller = controller;
            Action = action;
        }

        public UnautorizedException(int httpStatusCode, string message, string controller, string action, string parameters)
            : base(httpStatusCode, message)
        {
            Controller = controller;
            Action = action;
            Parameters = parameters;
        }
    }
}
