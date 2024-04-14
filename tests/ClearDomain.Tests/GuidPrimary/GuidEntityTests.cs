// <copyright file="GuidEntityTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using ClearDomain.Common;
using ClearDomain.GuidPrimary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearDomain.Tests.GuidPrimary
{
    /// <summary>
    /// Guid entity tests.
    /// </summary>
    [TestClass]
    public class GuidEntityTests
    {
        /// <summary>
        /// Ensure the identifier is initialized by default.
        /// </summary>
        [TestMethod]
        public void DefaultConstructor_InstantiatesId()
        {
            var entity = new TestGuidEntity();

            Assert.AreNotEqual(Guid.Empty, entity.Id);
        }

        /// <summary>
        /// Ensures the guid entity has the correct types.
        /// </summary>
        [TestMethod]
        public void Entity_HasTheCorrectTypes()
        {
            var entity = new TestGuidEntity();

            Assert.IsInstanceOfType<Entity<Guid>>(entity);
            Assert.IsInstanceOfType<IEntity>(entity);
            Assert.IsInstanceOfType<IEntity<Guid>>(entity);
        }
    }
}
