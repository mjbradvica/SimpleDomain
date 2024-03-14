// <copyright file="LongIdentityUserTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using ClearDomain.Identity.Common;
using ClearDomain.Identity.LongPrimary;
using ClearDomain.LongPrimary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearDomain.Tests.LongPrimary
{
    /// <summary>
    /// Tests for the <see cref="ClearDomainIdentityUser"/> class.
    /// </summary>
    [TestClass]
    public class LongIdentityUserTests
    {
        /// <summary>
        /// Class has default constructor.
        /// </summary>
        [TestMethod]
        public void Class_HasDefaultConstructor()
        {
            var user = new TestLongIdentityUser();

            Assert.IsNotNull(user);
        }

        /// <summary>
        /// Class has username constructor.
        /// </summary>
        [TestMethod]
        public void Class_HasUsernameConstructor()
        {
            var user = new TestLongIdentityUser("user");

            Assert.IsNotNull(user);
        }

        /// <summary>
        /// Class has correct types.
        /// </summary>
        [TestMethod]
        public void Class_HasCorrectTypes()
        {
            var user = new TestLongIdentityUser();

            Assert.IsInstanceOfType<ClearDomainIdentityUser<long>>(user);
            Assert.IsInstanceOfType<IAggregateRoot>(user);
        }
    }
}
