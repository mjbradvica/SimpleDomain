// <copyright file="TestLongIdentityUser.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using ClearDomain.Identity.LongPrimary;

namespace ClearDomain.Tests.LongPrimary
{
    /// <summary>
    /// Test long identity user.
    /// </summary>
    public class TestLongIdentityUser : ClearDomainIdentityUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestLongIdentityUser"/> class.
        /// </summary>
        public TestLongIdentityUser()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestLongIdentityUser"/> class.
        /// </summary>
        /// <param name="username">THe username.</param>
        public TestLongIdentityUser(string username)
            : base(username)
        {
        }
    }
}
