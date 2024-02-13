// <copyright file="EntityTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using ClearDomain.Tests.GuidPrimary;
using ClearDomain.Tests.IntPrimary;
using ClearDomain.Tests.LongPrimary;
using ClearDomain.Tests.StringPrimary;

namespace ClearDomain.Tests
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
        public void GuidConstructor_EmptyId_ThrowsException()
        {
            Assert.ThrowsException<NullReferenceException>(() => new TestGuidEntity(Guid.Empty));
        }

        /// <summary>
        /// Ensures the entity throws an exception on a zeroed int.
        /// </summary>
        [TestMethod]
        public void IntConstructor_EmptyId_ThrowsException()
        {
            Assert.ThrowsException<NullReferenceException>(() => new TestIntEntity(0));
        }

        /// <summary>
        /// Ensures the entity throws an exception on a zeroed long.
        /// </summary>
        [TestMethod]
        public void LongConstructor_EmptyId_ThrowsException()
        {
            Assert.ThrowsException<NullReferenceException>(() => new TestLongEntity(0));
        }

        /// <summary>
        /// Ensures the entity throws an exception on a zeroed long.
        /// </summary>
        [TestMethod]
        public void StringConstructor_EmptyId_ThrowsException()
        {
            Assert.ThrowsException<NullReferenceException>(() => new TestStringEntity(string.Empty));
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
        /// Ensures a null entity id returns the correct result.
        /// </summary>
        [TestMethod]
        public void Equal_EntityObject_NullId_ReturnsFalse()
        {
            var first = new TestStringEntity
            {
                Id = default!,
            };
            var second = new TestStringEntity();

            Assert.IsFalse(first.Equals(second));
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
