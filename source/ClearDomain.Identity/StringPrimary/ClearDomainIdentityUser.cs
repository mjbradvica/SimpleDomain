// <copyright file="ClearDomainIdentityUser.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using ClearDomain.Common;
using ClearDomain.StringPrimary;
using Microsoft.AspNetCore.Identity;

namespace ClearDomain.Identity.StringPrimary
{
    /// <summary>
    /// Base class for a <see cref="IdentityUser"/> with ClearDomain functionality.
    /// </summary>
    public abstract class ClearDomainIdentityUser : IdentityUser, IAggregateRoot, IEquatable<ClearDomainIdentityUser>
    {
        private readonly List<IDomainEvent> _domainEvents;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClearDomainIdentityUser"/> class.
        /// </summary>
        protected ClearDomainIdentityUser()
        {
            _domainEvents = new List<IDomainEvent>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClearDomainIdentityUser"/> class.
        /// </summary>
        /// <param name="userName">The username for the user.</param>
        protected ClearDomainIdentityUser(string userName)
            : base(userName)
        {
            _domainEvents = new List<IDomainEvent>();
        }

        /// <inheritdoc />
        public IEnumerable<IDomainEvent> DomainEvents => _domainEvents;

        /// <summary>
        /// Determines equality for another entity.
        /// </summary>
        /// <param name="other">The other entity to compare.</param>
        /// <returns>A <see cref="bool"/> indicating if the objects are equal.</returns>
        public bool Equals(ClearDomainIdentityUser? other)
        {
            if (other == null)
            {
                return false;
            }

            return Id.Equals(other.Id);
        }

        /// <summary>
        /// Determines equality for another object.
        /// </summary>
        /// <param name="obj">The other object to compare.</param>
        /// <returns>A <see cref="bool"/> indicating if the objects are equal.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is ClearDomainIdentityUser user)
            {
                return Equals(user);
            }

            return false;
        }

        /// <summary>
        /// Returns a hashcode for the entity. This is required by the <see cref="IEquatable{T}"/> interface.
        /// </summary>
        /// <returns>A <see cref="int"/> hashcode for the entity.</returns>
        public override int GetHashCode()
        {
            return GetType().GetHashCode();
        }

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
