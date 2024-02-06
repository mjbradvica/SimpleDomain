// <copyright file="TestLongEntity.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using SimpleDomain.LongPrimary;

namespace SimpleDomain.Tests.LongPrimary
{
    /// <summary>
    /// Test long entity.
    /// </summary>
    public class TestLongEntity : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestLongEntity"/> class.
        /// </summary>
        public TestLongEntity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestLongEntity"/> class.
        /// </summary>
        /// <param name="id">The identifier for the test entity.</param>
        public TestLongEntity(long id)
            : base(id)
        {
        }
    }
}
