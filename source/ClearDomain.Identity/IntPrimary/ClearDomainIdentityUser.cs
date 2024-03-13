// <copyright file="ClearDomainIdentityUser.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using ClearDomain.Identity.Common;
using ClearDomain.IntPrimary;

namespace ClearDomain.Identity.IntPrimary
{
    /// <summary>
    /// Base class for a <see cref="int"/> identity user with ClearDomain functionality.
    /// </summary>
    public abstract class ClearDomainIdentityUser : ClearDomainIdentityUser<int>, IAggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClearDomainIdentityUser"/> class.
        /// </summary>
        protected ClearDomainIdentityUser()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClearDomainIdentityUser"/> class.
        /// </summary>
        /// <param name="userName">The username for the identity user.</param>
        protected ClearDomainIdentityUser(string userName)
            : base(userName)
        {
        }
    }
}
