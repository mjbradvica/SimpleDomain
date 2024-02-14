// <copyright file="TestStringEntity.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using ClearDomain.StringPrimary;

namespace ClearDomain.Tests.StringPrimary
{
    /// <summary>
    /// Test string entity.
    /// </summary>
    public class TestStringEntity : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestStringEntity"/> class.
        /// </summary>
        public TestStringEntity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestStringEntity"/> class.
        /// </summary>
        /// <param name="id">The identifier for the entity.</param>
        public TestStringEntity(string id)
            : base(id)
        {
        }
    }
}
