// <copyright file="ValueObjectTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleDomain.Common;

namespace SimpleDomain.Tests
{
    /// <summary>
    /// Tests for value objects.
    /// </summary>
    [TestClass]
    public class ValueObjectTests
    {
        /// <summary>
        /// Ensures non property equality.
        /// </summary>
        [TestMethod]
        public void EqualsOperator_ComparesObjects()
        {
            var first = new TestValueObject();
            var second = new TestValueObject();

            Assert.IsTrue(first == second);
        }

        /// <summary>
        /// Ensures property equality.
        /// </summary>
        [TestMethod]
        public void NonEqualsOperators_ComparesObjects()
        {
            var first = new TestValueObject();
            first.SetId(10);

            var second = new TestValueObject();

            Assert.IsTrue(first != second);
        }

        /// <summary>
        /// Ensures property equality.
        /// </summary>
        [TestMethod]
        public void Equals_ValueObject_EqualValues_ReturnsFalse()
        {
            var first = new TestValueObject();
            var second = new TestValueObject();

            Assert.IsTrue(first.Equals(second));
            Assert.AreEqual(first.Id, second.Id);
            Assert.AreEqual(first.Second, second.Second);
        }

        /// <summary>
        /// Ensures correct response on null comparisons.
        /// </summary>
        [TestMethod]
        public void Equals_ValueObject_NullValue_ReturnsFalse()
        {
            var first = new TestValueObject();
            first.SetId(null);

            var second = new TestValueObject();

            Assert.IsFalse(first.Equals(second));
        }

        /// <summary>
        /// Ensures correct response on non equal comparisons.
        /// </summary>
        [TestMethod]
        public void Equals_ValueObject_NonEqualValue_ReturnsFalse()
        {
            var first = new TestValueObject();
            first.SetId(10);

            var second = new TestValueObject();

            Assert.IsFalse(first.Equals(second));
        }

        /// <summary>
        /// Ensures correct response on object equality.
        /// </summary>
        [TestMethod]
        public void Equals_ObjectValueObject_ReturnsTrue()
        {
            var first = new TestValueObject();
            object second = new TestValueObject();

            Assert.IsTrue(first.Equals(second));
        }

        /// <summary>
        /// Ensure correct response on object equality.
        /// </summary>
        [TestMethod]
        public void Equals_NonObjectValueObject_ReturnsTrue()
        {
            var first = new TestValueObject();
            object second = "nonValueObject";

            Assert.IsFalse(first.Equals(second));
        }

        /// <summary>
        /// Ensures the hashcode returns the floor minimum.
        /// </summary>
        [TestMethod]
        public void GetHashCode_ReturnsMinimumValue()
        {
            var valueObject = new TestValueObject();

            Assert.IsTrue(valueObject.GetHashCode() > 1);
        }

        /// <summary>
        /// Test value object.
        /// </summary>
        internal class TestValueObject : ValueObject
        {
            private int? _id;

            /// <summary>
            /// Initializes a new instance of the <see cref="TestValueObject"/> class.
            /// </summary>
            public TestValueObject()
            {
                _id = 1;
                Second = "second";
            }

            /// <summary>
            /// Gets the value object property.
            /// </summary>
            public int? Id => _id;

            /// <summary>
            /// Gets the second value object property.
            /// </summary>
            public string Second { get; }

            /// <summary>
            /// Test setter for the property.
            /// </summary>
            /// <param name="id">An updated identifier.</param>
            public void SetId(int? id)
            {
                _id = id;
            }
        }
    }
}
