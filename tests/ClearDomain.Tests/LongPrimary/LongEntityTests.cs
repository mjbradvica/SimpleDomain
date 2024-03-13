// <copyright file="LongEntityTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using ClearDomain.LongPrimary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearDomain.Tests.LongPrimary
{
    /// <summary>
    /// Long entity tests.
    /// </summary>
    [TestClass]
    public class LongEntityTests
    {
        /// <summary>
        /// Ensures the long entity has the correct types.
        /// </summary>
        [TestMethod]
        public void Entity_HasTheCorrectTypes()
        {
            var entity = new TestLongEntity();

            Assert.IsInstanceOfType<Entity<long>>(entity);
            Assert.IsInstanceOfType<IEntity>(entity);
            Assert.IsInstanceOfType<IEntity<long>>(entity);
        }
    }
}
