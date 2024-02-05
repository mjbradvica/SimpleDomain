// <copyright file="IAggregateRoot.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace SimpleDomain.Common
{
    /// <summary>
    /// Base interface for aggregate roots.
    /// </summary>
    /// <typeparam name="T">The type of the entity identifier.</typeparam>
    public interface IAggregateRoot<out T> : IEntity<T>
        where T : struct
    {
        /// <summary>
        /// Gets all domain events for an aggregate root.
        /// </summary>
        public IEnumerable<IDomainEvent> DomainEvents { get; }
    }
}
