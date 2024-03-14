// <copyright file="GuidIdentityUserTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using ClearDomain.GuidPrimary;
using ClearDomain.Identity.Common;
using ClearDomain.Identity.GuidPrimary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearDomain.Tests.GuidPrimary
{
    /// <summary>
    /// Tests for the <see cref="ClearDomainIdentityUser"/> class.
    /// </summary>
    [TestClass]
    public class GuidIdentityUserTests
    {
        /// <summary>
        /// Class has default constructor.
        /// </summary>
        [TestMethod]
        public void Class_HasDefaultConstructor()
        {
            var user = new TestGuidIdentityUser();

            Assert.IsNotNull(user);
        }

        /// <summary>
        /// Class has default constructor.
        /// </summary>
        [TestMethod]
        public void Class_HasUsernameConstructor()
        {
            var user = new TestGuidIdentityUser("username");

            Assert.IsNotNull(user);
        }

        /// <summary>
        /// Class has correct types.
        /// </summary>
        [TestMethod]
        public void Class_HasCorrectTypes()
        {
            var user = new TestGuidIdentityUser();

            Assert.IsInstanceOfType<ClearDomainIdentityUser<Guid>>(user);
            Assert.IsInstanceOfType<IAggregateRoot>(user);
        }
    }
}
