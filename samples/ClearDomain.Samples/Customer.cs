// <copyright file="Customer.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using ClearDomain.Identity.GuidPrimary;

namespace ClearDomain.Samples
{
    /// <summary>
    /// Sample identity user.
    /// </summary>
    public sealed class Customer : ClearDomainIdentityUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        public Customer(Guid id)
        {
            Id = id;
            SecurityStamp = Guid.NewGuid().ToString();

            if (Id == Guid.Empty)
            {
                throw new NullReferenceException(nameof(id));
            }
        }
    }
}
