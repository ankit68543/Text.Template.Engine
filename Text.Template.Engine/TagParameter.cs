﻿using System;
using Text.Template.Engine;

namespace Text.Template.Engine
{
    /// <summary>
    /// Defines a parameter belonging to a custom tag.
    /// </summary>
    public sealed class TagParameter
    {
        /// <summary>
        /// Initializes a new instance of a TagParameter.
        /// </summary>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <exception cref="System.ArgumentException">The parameter name is null or an invalid identifier.</exception>
        public TagParameter(string parameterName)
        {
            if (!RegexHelper.IsValidIdentifier(parameterName))
            {
                throw new ArgumentException(Resources.BlankParameterName, "parameterName");
            }
            Name = parameterName;
        }

        /// <summary>
        /// Gets the name of the parameter.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets or sets whether the field is required.
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// Gets or sets the default value to use when an argument is not provided
        /// for the parameter.
        /// </summary>
        public object DefaultValue { get; set; }
    }
}
