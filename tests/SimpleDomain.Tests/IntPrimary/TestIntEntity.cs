// <copyright file="TestIntEntity.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using SimpleDomain.IntPrimary;

namespace SimpleDomain.Tests.IntPrimary
{
    /// <summary>
    /// Test int entity.
    /// </summary>
    public class TestIntEntity : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestIntEntity"/> class.
        /// </summary>
        public TestIntEntity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestIntEntity"/> class.
        /// </summary>
        /// <param name="id">The test entity identifier.</param>
        public TestIntEntity(int id)
            : base(id)
        {
        }
    }
}
