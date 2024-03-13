// <copyright file="StringIdentityUserTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using ClearDomain.Identity.Common;
using ClearDomain.Identity.StringPrimary;
using ClearDomain.StringPrimary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearDomain.Tests.StringPrimary
{
    /// <summary>
    /// Tests for the <see cref="ClearDomainIdentityUser"/> class.
    /// </summary>
    [TestClass]
    public class StringIdentityUserTests
    {
        /// <summary>
        /// Class has default constructor.
        /// </summary>
        [TestMethod]
        public void Class_HasDefaultConstructor()
        {
            var user = new TestIdentityUser();

            Assert.IsNotNull(user);
        }

        /// <summary>
        /// Class has username constructor.
        /// </summary>
        [TestMethod]
        public void Class_HasUsernameConstructor()
        {
            var user = new TestIdentityUser("user");

            Assert.IsNotNull(user);
        }

        /// <summary>
        /// Class has correct types.
        /// </summary>
        [TestMethod]
        public void Class_HasCorrectTypes()
        {
            var user = new TestIdentityUser();

            Assert.IsInstanceOfType<ClearDomainIdentityUser<string>>(user);
            Assert.IsInstanceOfType<IAggregateRoot>(user);
        }

        /// <summary>
        /// Test class.
        /// </summary>
        internal class TestIdentityUser : ClearDomainIdentityUser
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
            /// <param name="username">The username.</param>
            public TestIdentityUser(string username)
                : base(username)
            {
            }
        }
    }
}
