// <copyright file="Entity.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using ClearDomain.Common;

namespace ClearDomain.GuidPrimary
{
    /// <summary>
    /// Base class for all <see cref="Guid"/> entities.
    /// </summary>
    public abstract class Entity : Entity<Guid>, IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        protected Entity()
            : this(Guid.NewGuid())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        protected Entity(Guid id)
            : base(id)
        {
        }
    }
}
