// <copyright file="TestGuidEntity.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using ClearDomain.GuidPrimary;

namespace ClearDomain.Tests.GuidPrimary
{
    /// <summary>
    /// Test GUID entity.
    /// </summary>
    public class TestGuidEntity : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestGuidEntity"/> class.
        /// </summary>
        public TestGuidEntity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestGuidEntity"/> class.
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        public TestGuidEntity(Guid id)
            : base(id)
        {
        }
    }
}
