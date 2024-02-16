// <copyright file="StringEntityTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearDomain.Tests.StringPrimary
{
    /// <summary>
    /// String entity tests.
    /// </summary>
    [TestClass]
    public class StringEntityTests
    {
        /// <summary>
        /// Ensure the identifier is initialized by default.
        /// </summary>
        [TestMethod]
        public void DefaultConstructor_InstantiatesId()
        {
            var entity = new TestStringEntity();

            Assert.AreNotEqual(Guid.Empty.ToString(), entity.Id);
        }
    }
}
