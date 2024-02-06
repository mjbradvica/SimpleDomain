// <copyright file="TestHelpers.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;

namespace SimpleDomain.Tests.Common
{
    /// <summary>
    /// Test helpers.
    /// </summary>
    public class TestHelpers
    {
        /// <summary>
        /// Returns the test db context.
        /// </summary>
        /// <returns>A new <see cref="TestDbContext"/> instance.</returns>
        public static TestDbContext GetDbContext()
        {
            return new TestDbContext();
        }

        /// <summary>
        /// Clears all test tables.
        /// </summary>
        public static void ClearDatabase()
        {
            using (var context = new TestDbContext())
            {
                context.GuidEntities.RemoveRange(context.GuidEntities);
                context.IntEntities.RemoveRange(context.IntEntities);
                context.LongEntities.RemoveRange(context.LongEntities);

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Gets the db connection string.
        /// </summary>
        /// <returns>The correct connection string.</returns>
        public static string ConnectionString()
        {
            return Environment.GetEnvironmentVariable("TEST_CONNECTION_STRING") ??
                                 "Server=.\\SQLExpress;Database=SimpleDomain;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=True;TrustServerCertificate=true";
        }
    }
}
