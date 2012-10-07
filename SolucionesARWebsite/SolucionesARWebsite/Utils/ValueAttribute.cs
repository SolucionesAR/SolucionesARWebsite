using System;

namespace SolucionesARWebsite.Utils
{
    /// <summary>
    /// This attribute is used to represent a string value
    /// for a value in an enum.
    /// </summary>
    public class ValueAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValueAttribute"/> class.
        /// </summary>
        /// <param name="value">The attribute value.</param>
        public ValueAttribute(object value)
        {
            Value = value;
        }

        /// <summary>
        /// Holds the stringvalue for a value in an enum.
        /// </summary>
        public object Value { get; private set; }
    }
}