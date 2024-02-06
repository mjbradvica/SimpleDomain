// <copyright file="AggregateRoot.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace SimpleDomain.Common
{
    /// <summary>
    /// A base class for aggregate roots.
    /// </summary>
    /// <typeparam name="T">The type of the identifier.</typeparam>
    public abstract class AggregateRoot<T> : Entity<T>, IAggregateRoot<T>
    {
        private readonly List<IDomainEvent> _domainEvents;

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateRoot{T}"/> class.
        /// </summary>
        protected AggregateRoot()
        {
            _domainEvents = new List<IDomainEvent>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateRoot{T}"/> class.
        /// </summary>
        /// <param name="id">The identifier for the aggregate root.</param>
        protected AggregateRoot(T id)
            : base(id)
        {
            _domainEvents = new List<IDomainEvent>();
        }

        /// <inheritdoc />
        public IEnumerable<IDomainEvent> DomainEvents => _domainEvents;

        /// <summary>
        /// Appends a domain event to the current list.
        /// </summary>
        /// <param name="domainEvent">A <see cref="IDomainEvent"/> to append.</param>
        public virtual void AppendDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
