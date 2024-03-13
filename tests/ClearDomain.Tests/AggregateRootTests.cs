// <copyright file="AggregateRootTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Linq;
using ClearDomain.Common;
using ClearDomain.GuidPrimary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearDomain.Tests
{
    /// <summary>
    /// Tests for aggregate roots.
    /// </summary>
    [TestClass]
    public class AggregateRootTests
    {
        /// <summary>
        /// Ensure that events are instantiated on initialization.
        /// </summary>
        [TestMethod]
        public void DefaultConstructor_InstantiatesEvents()
        {
            var root = new TestAggregateRoot();

            Assert.IsNotNull(root.DomainEvents);
        }

        /// <summary>
        /// Ensure that events are instantiated on initialization.
        /// </summary>
        [TestMethod]
        public void NonDefaultConstructor_InstantiatesEvents()
        {
            var root = new TestAggregateRoot(Guid.NewGuid());

            Assert.IsNotNull(root.DomainEvents);
        }

        /// <summary>
        /// Ensures domain events are appended to the list.
        /// </summary>
        [TestMethod]
        public void AddNotification_AppendsToEvents()
        {
            var root = new TestAggregateRoot();

            root.AppendDomainEvent(new TestDomainEvent());

            Assert.AreEqual(1, root.DomainEvents.Count());
        }

        /// <summary>
        /// Test domain event.
        /// </summary>
        public class TestDomainEvent : IDomainEvent
        {
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
            public TestAggregateRoot(Guid id)
                : base(id)
            {
            }
        }
    }
}
