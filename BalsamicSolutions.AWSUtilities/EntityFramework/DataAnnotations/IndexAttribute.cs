﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BalsamicSolutions.AWSUtilities.EntityFramework.DataAnnotations
{
    /// <summary>
    /// Represents an attribute that is placed on a property to indicate that the database column to which the property is mapped has an index.
    /// Credit to https://github.com/jsakamoto/EntityFrameworkCore.IndexAttribute/blob/master/EntityFrameworkCore.IndexAttribute/IndexAttribute.cs
    /// for the implementation model
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class IndexAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the index name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets or sets a number that determines the column ordering for multi-column indexes.
        /// </summary>
        public int Order { get; }

        /// <summary>
        /// Gets or sets a value to indicate whether to define a unique index.
        /// </summary>
        public bool IsUnique { get; set; }

        /// <summary>
        /// Initializes a new IndexAttribute instance for an index that will be named by convention and has no column order, uniqueness specified.
        /// </summary>
        public IndexAttribute() : this(string.Empty, -1)
        {
        }

        /// <summary>
        /// Initializes a new IndexAttribute instance for an index with the given name and has no column order, uniqueness specified.
        /// </summary>
        /// <param name="name">The index name.</param>
        public IndexAttribute(string name) : this(name, -1)
        {
        }

        /// <summary>
        /// Initializes a new IndexAttribute instance for an index with the given name and column order, but with no uniqueness specified.
        /// </summary>
        /// <param name="name">The index name.</param>
        /// <param name="order">A number which will be used to determine column ordering for multi-column indexes.</param>
        public IndexAttribute(string name, int order)
        {
            this.Name = name;
            this.Order = order;
        }
        /// <summary>
        /// Initializes a new IndexAttribute instance for an index with the given name and column order, but with no uniqueness specified.
        /// </summary>
        /// <param name="name">The index name.</param>
        /// <param name="order">A number which will be used to determine column ordering for multi-column indexes.</param>
        public IndexAttribute(string name, int order, bool isUnique)
        {
            this.Name = name;
            this.Order = order;
            this.IsUnique = isUnique;
        }
    }
}
