// <copyright file="AggregateRoot.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using SimpleDomain.Common;

namespace SimpleDomain.LongPrimary
{
    /// <summary>
    /// Base class for all <see cref="long"/> aggregate roots.
    /// </summary>
    public abstract class AggregateRoot : AggregateRoot<long>, IAggregateRoot
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
        /// <param name="id">The identifier for an aggregate root.</param>
        protected AggregateRoot(long id)
            : base(id)
        {
        }
    }
}
