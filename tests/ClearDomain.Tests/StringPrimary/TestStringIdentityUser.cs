// <copyright file="TestStringIdentityUser.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using ClearDomain.Identity.StringPrimary;

namespace ClearDomain.Tests.StringPrimary
{
    /// <summary>
    /// Test string identity user.
    /// </summary>
    public class TestStringIdentityUser : ClearDomainIdentityUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestStringIdentityUser"/> class.
        /// </summary>
        public TestStringIdentityUser()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestStringIdentityUser"/> class.
        /// </summary>
        /// <param name="username">The username.</param>
        public TestStringIdentityUser(string username)
        : base(username)
        {
        }
    }
}
