// <copyright file="GuidCustomer.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using ClearDomain.Identity.GuidPrimary;

namespace ClearDomain.Samples.GuidIdentity
{
    /// <summary>
    /// Sample <see cref="Guid"/> identity user.
    /// </summary>
    public sealed class GuidCustomer : ClearDomainIdentityUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuidCustomer"/> class.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <param name="userName">The customer username.</param>
        public GuidCustomer(Guid id, string userName)
        {
            Id = id;
            UserName = userName;
            SecurityStamp = Guid.NewGuid().ToString();

            if (Id == Guid.Empty)
            {
                throw new NullReferenceException(nameof(id));
            }
        }
    }
}
