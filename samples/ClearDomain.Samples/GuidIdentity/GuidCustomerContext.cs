// <copyright file="GuidCustomerContext.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ClearDomain.Samples.GuidIdentity
{
    /// <summary>
    /// Sample guid customer context.
    /// </summary>
    internal sealed class GuidCustomerContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuidCustomerContext"/> class.
        /// </summary>
        public GuidCustomerContext()
        {
            Database.EnsureCreated();
        }
    }
}
