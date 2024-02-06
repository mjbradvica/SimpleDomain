// <copyright file="BaseIntegrationTest.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

namespace SimpleDomain.Tests.Common
{
    /// <summary>
    /// Base class for integration tests.
    /// </summary>
    public class BaseIntegrationTest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseIntegrationTest"/> class.
        /// </summary>
        public BaseIntegrationTest()
        {
            TestHelpers.ClearDatabase();
        }
    }
}
