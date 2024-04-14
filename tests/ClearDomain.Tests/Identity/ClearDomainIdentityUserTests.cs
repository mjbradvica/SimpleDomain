// <copyright file="ClearDomainIdentityUserTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Linq;
using ClearDomain.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearDomain.Tests.Identity
{
    /// <summary>
    /// Tests for identity users.
    /// </summary>
    [TestClass]
    public class ClearDomainIdentityUserTests
    {
        /// <summary>
        /// Ensures events are initialized on creation.
        /// </summary>
        [TestMethod]
        public void DefaultConstructor_InitializesDomainEvents()
        {
            var user = new TestIdentityUser();

            Assert.IsNotNull(user.DomainEvents);
        }

        /// <summary>
        /// Ensures all properties are initialized on creation.
        /// </summary>
        [TestMethod]
        public void UserNameConstructor_InitializesProperties()
        {
            var user = new TestIdentityUser("user");

            Assert.IsNotNull(user.UserName);
            Assert.IsNotNull(user.DomainEvents);
        }

        /// <summary>
        /// Ensures entity equals is correct.
        /// </summary>
        [TestMethod]
        public void Equals_NullOther_ReturnsCorrectResponse()
        {
            var user = new TestIdentityUser();

            var result = user.Equals(null);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// Ensures entity equals is correct.
        /// </summary>
        [TestMethod]
        public void Equals_NullId_ReturnsCorrectResponse()
        {
            var user = new TestIdentityUser();

            var other = new TestIdentityUser();

            var result = user.Equals(other);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// Ensures entity equals is correct.
        /// </summary>
        [TestMethod]
        public void Equals_Successful_ReturnsCorrectResponse()
        {
            var id = Guid.NewGuid().ToString();

            var user = new TestIdentityUser
            {
                Id = id,
            };

            var other = new TestIdentityUser
            {
                Id = id,
            };

            var result = user.Equals(other);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Ensures equals only runs for the correct type.
        /// </summary>
        [TestMethod]
        public void Equals_CorrectType_ReturnsCorrectResponse()
        {
            var id = Guid.NewGuid().ToString();

            var user = new TestIdentityUser
            {
                Id = id,
            };

            object other = new TestIdentityUser
            {
                Id = id,
            };

            var result = user.Equals(other);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Ensures equals only runs for the correct type.
        /// </summary>
        [TestMethod]
        public void Equals_IncorrectType_ReturnsCorrectResponse()
        {
            var user = new TestIdentityUser();

            object other = string.Empty;

            var result = user.Equals(other);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// Ensures hashcode is above floor.
        /// </summary>
        [TestMethod]
        public void GetHashCode_IsAboveMinimum()
        {
            var user = new TestIdentityUser();

            var hashcode = user.GetHashCode();

            Assert.IsTrue(hashcode > 0);
        }

        /// <summary>
        /// Ensures domain events are added.
        /// </summary>
        [TestMethod]
        public void AppendDomainEvent_IsAppended()
        {
            var user = new TestIdentityUser();

            user.AppendDomainEvent(new AggregateRootTests.TestDomainEvent());

            Assert.AreEqual(1, user.DomainEvents.Count());
        }

        /// <summary>
        /// Class has correct types.
        /// </summary>
        [TestMethod]
        public void Class_HasCorrectTypes()
        {
            var user = new TestIdentityUser();

            Assert.IsInstanceOfType<IdentityUser<string>>(user);
            Assert.IsInstanceOfType<IAggregateRoot<string>>(user);
            Assert.IsInstanceOfType<IEquatable<IEntity<string>>>(user);
        }
    }
}
