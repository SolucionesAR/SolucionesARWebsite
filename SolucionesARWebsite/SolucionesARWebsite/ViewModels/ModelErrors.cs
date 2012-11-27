using System;
using System.Collections.Generic;

namespace SolucionesARWebsite.ViewModels
{
    /// <summary>
    /// Contains Erros and Warning collections with several methods to manipulate them.
    /// </summary>
    public abstract class ModelErrors
    {
        /// <summary>
        /// Gets or sets the warning.
        /// </summary>
        /// <value>The warning.</value>
        public List<string> Warnings { get; private set; }

        /// <summary>
        /// Gets or sets the exceptions.
        /// </summary>
        /// <value>The exceptions.</value>
        public List<Exception> Errors { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelErrors"/> class.
        /// </summary>
        protected ModelErrors()
        {
            Errors = new List<Exception>();
            Warnings = new List<string>();
        }

        /// <summary>
        /// Resets the errors.
        /// </summary>
        public void ResetErrors()
        {
            Errors.Clear();
        }

        /// <summary>
        /// Adds the error.
        /// </summary>
        /// <param name="error">The error.</param>
        public void AddError(string error)
        {
            Errors.Add(new Exception(error));
        }

        /// <summary>
        /// Adds the error.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public void AddError(Exception ex)
        {
            Errors.Add(ex);
        }

        /// <summary>
        /// Determines whether this instance has warning.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if this instance has warning; otherwise, <c>false</c>.
        /// </returns>
        public bool HasWarnings()
        {
            return Warnings != null && Warnings.Count > 0;
        }

        /// <summary>
        /// Determines whether this instance has errors.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if this instance has errors; otherwise, <c>false</c>.
        /// </returns>
        public bool HasErrors()
        {
            return Errors != null && Errors.Count > 0;
        }
    }
}
