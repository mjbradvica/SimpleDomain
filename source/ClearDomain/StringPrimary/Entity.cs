// <copyright file="Entity.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using ClearDomain.Common;

namespace ClearDomain.StringPrimary
{
    /// <summary>
    /// Base class for all <see cref="string"/> entities.
    /// </summary>
    public abstract class Entity : Entity<string>, IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        protected Entity()
            : this(Guid.NewGuid().ToString())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        /// <param name="id">The identifier for the entity.</param>
        protected Entity(string id)
            : base(id)
        {
        }
    }
}
