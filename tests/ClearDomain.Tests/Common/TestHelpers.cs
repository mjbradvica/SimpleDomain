// <copyright file="TestHelpers.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using ClearDomain.Tests.GuidPrimary;
using ClearDomain.Tests.IntPrimary;
using ClearDomain.Tests.LongPrimary;
using ClearDomain.Tests.StringPrimary;
using MongoDB.Driver;

namespace ClearDomain.Tests.Common
{
    /// <summary>
    /// Test helpers.
    /// </summary>
    public class TestHelpers
    {
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

            var client = new MongoClient(MongoConnectionString());

            client.GetDatabase("clear_domain").GetCollection<TestGuidEntity>("guid_entities")
                .DeleteMany(Builders<TestGuidEntity>.Filter.Empty);
            client.GetDatabase("clear_domain").GetCollection<TestIntEntity>("int_entities")
                .DeleteMany(Builders<TestIntEntity>.Filter.Empty);
            client.GetDatabase("clear_domain").GetCollection<TestLongEntity>("long_entities")
                .DeleteMany(Builders<TestLongEntity>.Filter.Empty);
            client.GetDatabase("clear_domain").GetCollection<TestStringEntity>("string_entities")
                .DeleteMany(Builders<TestStringEntity>.Filter.Empty);
        }

        /// <summary>
        /// Gets the db connection string.
        /// </summary>
        /// <returns>The correct connection string.</returns>
        public static string ConnectionString()
        {
            return Environment.GetEnvironmentVariable("TEST_CONNECTION_STRING") ??
                   "Server=.\\SQLExpress;Database=ClearDomain.Tests;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=True;TrustServerCertificate=true";
        }

        /// <summary>
        /// Gets the Mongo connection string.
        /// </summary>
        /// <returns>The correct connection string.</returns>
        public static string MongoConnectionString()
        {
            return "mongodb://localhost:27017";
        }
    }
}
