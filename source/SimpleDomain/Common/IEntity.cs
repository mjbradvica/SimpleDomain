﻿// <copyright file="IEntity.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

namespace SimpleDomain.Common
{
    /// <summary>
    /// Base interface for all entities.
    /// </summary>
    /// <typeparam name="T">The type of the identifier.</typeparam>
    public interface IEntity<out T>
        where T : struct
    {
        /// <summary>
        /// Gets the entity identifier.
        /// </summary>
        public T Id { get; }
    }
}
