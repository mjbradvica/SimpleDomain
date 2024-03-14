// <copyright file="IntAggregateRootTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using ClearDomain.IntPrimary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearDomain.Tests.IntPrimary
{
    /// <summary>
    /// Tests for a <see cref="AggregateRoot"/>.
    /// </summary>
    [TestClass]
    public class IntAggregateRootTests
    {
        /// <summary>
        /// Ensure that events are instantiated on initialization.
        /// </summary>
        [TestMethod]
        public void DefaultConstructor_InstantiatesObject()
        {
            var root = new TestAggregateRoot();

            Assert.IsNotNull(root);
        }

        /// <summary>
        /// Ensure that events are instantiated on initialization.
        /// </summary>
        [TestMethod]
        public void NonDefaultConstructor_InstantiatesObject()
        {
            var root = new TestAggregateRoot(1);

            Assert.IsNotNull(root);
        }

        /// <summary>
        /// Ensures the class has the correct types.
        /// </summary>
        [TestMethod]
        public void AggregateRoot_HasCorrectTypes()
        {
            var root = new TestAggregateRoot(1);

            Assert.IsInstanceOfType<AggregateRoot<int>>(root);
            Assert.IsInstanceOfType<IAggregateRoot>(root);
        }

        /// <summary>
        /// Test aggregate root.
        /// </summary>
        internal class TestAggregateRoot : AggregateRoot
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="TestAggregateRoot"/> class.
            /// </summary>
            public TestAggregateRoot()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="TestAggregateRoot"/> class.
            /// </summary>
            /// <param name="id">The identifier for the aggregate root.</param>
            public TestAggregateRoot(int id)
                : base(id)
            {
            }
        }
    }
}
