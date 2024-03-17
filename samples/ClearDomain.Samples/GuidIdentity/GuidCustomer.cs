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
        /// <param name="userName">The username.</param>
        public GuidCustomer(string userName)
            : base(userName)
        {
            Id = Guid.NewGuid();
            SecurityStamp = Guid.NewGuid().ToString();
        }
    }
}
