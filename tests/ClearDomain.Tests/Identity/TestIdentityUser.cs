// <copyright file="TestIdentityUser.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using ClearDomain.Identity.Common;

namespace ClearDomain.Tests.Identity
{
    /// <summary>
    /// Test identity user.
    /// </summary>
    internal class TestIdentityUser : ClearDomainIdentityUser<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestIdentityUser"/> class.
        /// </summary>
        public TestIdentityUser()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestIdentityUser"/> class.
        /// </summary>
        /// <param name="userName">The username.</param>
        public TestIdentityUser(string userName)
            : base(userName)
        {
        }
    }
}
