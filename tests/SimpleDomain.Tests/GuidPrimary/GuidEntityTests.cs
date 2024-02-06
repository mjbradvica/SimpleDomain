// <copyright file="GuidEntityTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleDomain.Tests.GuidPrimary
{
    /// <summary>
    /// Guid entity tests.
    /// </summary>
    [TestClass]
    public class GuidEntityTests
    {
        /// <summary>
        /// Ensure the identifier is initialized by default.
        /// </summary>
        [TestMethod]
        public void DefaultConstructor_InstantiatesId()
        {
            var entity = new TestGuidEntity();

            Assert.AreNotEqual(Guid.Empty, entity.Id);
        }
    }
}
