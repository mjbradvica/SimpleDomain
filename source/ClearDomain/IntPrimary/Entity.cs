// <copyright file="Entity.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace ClearDomain.IntPrimary
{
    /// <summary>
    /// Base class for all <see cref="int"/> entities.
    /// </summary>
    public abstract class Entity : Entity<int>, IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        protected Entity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        /// <param name="id">The identifier for the entity.</param>
        protected Entity(int id)
            : base(id)
        {
        }
    }
}
