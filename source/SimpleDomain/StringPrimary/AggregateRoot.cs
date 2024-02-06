// <copyright file="AggregateRoot.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using SimpleDomain.Common;

namespace SimpleDomain.StringPrimary
{
    /// <summary>
    /// Base class for all <see cref="string"/> aggregate roots.
    /// </summary>
    public abstract class AggregateRoot : AggregateRoot<string>, IAggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateRoot"/> class.
        /// </summary>
        protected AggregateRoot()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateRoot"/> class.
        /// </summary>
        /// <param name="id">The identifier for the aggregate root.</param>
        protected AggregateRoot(string id)
            : base(id)
        {
        }
    }
}
