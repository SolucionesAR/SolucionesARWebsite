#region Copyright Infutor Data Solutions
//	
// All rights are reserved. Reproduction or transmission in whole or in 
// part, in any form or by any means, electronic, mechanical or otherwise, 
// is prohibited without the prior written consent of the copyright owner.
//
// Filename: ListFilterValue.cs
//
#endregion

using System.Globalization;

namespace SolucionesARWebsite2.Helpers
{
    /// <summary>
    /// A filter that can be use on a list
    /// </summary>
    public class ListFilterValue
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListFilterValue"/> class.
        /// </summary>
        public ListFilterValue()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListFilterValue"/> class.
        /// </summary>
        /// <param name="name">The filer name.</param>
        /// <param name="value">The filter value.</param>
        public ListFilterValue(string name, string value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListFilterValue"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public ListFilterValue(string name, int value)
        {
            Name = name;
            Value = value.ToString(CultureInfo.InvariantCulture);
        }
    }
}