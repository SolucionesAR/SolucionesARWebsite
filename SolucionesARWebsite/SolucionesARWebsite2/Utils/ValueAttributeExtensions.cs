using System;
using System.Reflection;
using SolucionesARWebsite2.Utils;

namespace SolucionesARWebsite2.Utils
{
    /// <summary>
    /// This attribute is used to get a string value for a value in an enum.
    /// </summary>
    public static class ValueAttributeExtensions
    {
        /// <summary>
        /// Will get the value for a given enums value, this will
        /// only work if you assign the StringValue attribute to
        /// the items in your enum.
        /// </summary>
        /// <param name="value">Enum to get the value</param>
        /// <returns>returns the value object</returns>
        public static object GetValue(this object value)
        {
            // Get the type
            Type type = value.GetType();

            // Get fieldinfo for this type
            FieldInfo fieldInfo = type.GetField(value.ToString());

            // Get the stringvalue attributes
            var attribs = fieldInfo.GetCustomAttributes(typeof(ValueAttribute), false) as ValueAttribute[];

            // Return the first if there was a match.
            return attribs != null && attribs.Length > 0 ? attribs[0].Value : value.ToString();
        }

        /// <summary>
        /// Will get the string value for a given enums value, this will
        /// only work if you assign the StringValue attribute to
        /// the items in your enum.
        /// </summary>
        /// <param name="value">Enum to get the value</param>
        /// <returns>the string representation of the value</returns>
        public static string ToStringValue(this object value)
        {
            return GetValue(value).ToString();
        }

        /// <summary>
        /// Parses the sort field.
        /// </summary>
        /// <typeparam name="TEnumType">The type of the enum type.</typeparam>
        /// <param name="strObject">The STR object.</param>
        /// <returns>The string as a Enum value</returns>
        public static TEnumType ToEnumValue<TEnumType>(this string strObject)
        {
            return strObject.ToEnumValue<TEnumType>(false);
        }

        /// <summary>
        /// Parses the sort field.
        /// </summary>
        /// <typeparam name="TEnumType">The type of the enum type.</typeparam>
        /// <param name="strObject">The STR object.</param>
        /// <param name="caseSensitve">if set to <c>true</c> [case sensitve].</param>
        /// <returns>The string as a Enum value</returns>
        public static TEnumType ToEnumValue<TEnumType>(this string strObject, bool caseSensitve)
        {
            foreach (TEnumType value in Enum.GetValues(typeof(TEnumType)))
            {
                Enum enumObject = value as Enum;
                if (caseSensitve)
                {
                    if (strObject.Equals(enumObject.ToStringValue()))
                        return value;
                }
                else
                {
                    if (strObject.Equals(enumObject.ToStringValue(), StringComparison.CurrentCultureIgnoreCase))
                        return value;
                }
            }

            throw new Exception("Unable to parse enum value from string");
        }
    }
}