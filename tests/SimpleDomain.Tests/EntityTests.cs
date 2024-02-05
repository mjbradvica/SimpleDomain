// <copyright file="EntityTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleDomain.Tests.GuidPrimary;

namespace SimpleDomain.Tests
{
    /// <summary>
    /// Test for entity objects.
    /// </summary>
    [TestClass]
    public class EntityTests
    {
        /// <summary>
        /// Ensures the constructor instantiates the identifier.
        /// </summary>
        [TestMethod]
        public void DefaultConstructor_InstantiatesId()
        {
            var entity = new TestGuidEntity(Guid.NewGuid());

            Assert.AreNotEqual(Guid.Empty, entity.Id);
        }

        /// <summary>
        /// Ensures the entity throws an exception on an empty guid.
        /// </summary>
        [TestMethod]
        public void Constructor_EmptyId_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new TestGuidEntity(Guid.Empty));
        }

        /// <summary>
        /// Ensures a null equality comparison returns correct result.
        /// </summary>
        [TestMethod]
        public void Equals_NullEntity_ReturnsFalse()
        {
            var entity = new TestGuidEntity(Guid.NewGuid());

            Assert.IsFalse(entity.Equals(null));
        }

        /// <summary>
        /// Ensures an entity comparison returns the correct result.
        /// </summary>
        [TestMethod]
        public void Equals_NonNullEntity_ReturnsTrue()
        {
            var id = Guid.NewGuid();

            var first = new TestGuidEntity(id);
            var second = new TestGuidEntity(id);

            Assert.IsTrue(first.Equals(second));
        }

        /// <summary>
        /// Ensures an entity comparison returns the correct result.
        /// </summary>
        [TestMethod]
        public void Equals_EntityObject_ReturnsTrue()
        {
            var id = Guid.NewGuid();

            var first = new TestGuidEntity(id);
            object second = new TestGuidEntity(id);

            Assert.IsTrue(first.Equals(second));
        }

        /// <summary>
        /// Ensures an entity comparison returns the correct result.
        /// </summary>
        [TestMethod]
        public void Equals_NonEntityObject_ReturnsFalse()
        {
            var first = new TestGuidEntity(Guid.NewGuid());
            object second = "notAnEntity";

            Assert.IsFalse(first.Equals(second));
        }

        /// <summary>
        /// Ensures the hash code is above the floor value.
        /// </summary>
        [TestMethod]
        public void GetHaseCode_ReturnsMinimumValue()
        {
            var entity = new TestGuidEntity(Guid.NewGuid());

            Assert.IsTrue(entity.GetHashCode() > 0);
        }
    }
}
