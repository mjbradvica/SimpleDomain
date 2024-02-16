// <copyright file="Airplane.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;

namespace ClearDomain.Samples
{
    /// <summary>
    /// Sample long entity.
    /// </summary>
    public class Airplane : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Airplane"/> class.
        /// </summary>
        /// <param name="id">The airplane identifier.</param>
        public Airplane(long id)
            : base(id)
        {
        }
    }
}
