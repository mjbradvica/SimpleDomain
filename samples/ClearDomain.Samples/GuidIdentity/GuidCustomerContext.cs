// <copyright file="GuidCustomerContext.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClearDomain.Samples.GuidIdentity
{
    /// <summary>
    /// Sample guid customer context.
    /// </summary>
    internal sealed class GuidCustomerContext : IdentityDbContext<GuidCustomer, IdentityRole<Guid>, Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuidCustomerContext"/> class.
        /// </summary>
        /// <param name="options">The configuration options.</param>
        public GuidCustomerContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
