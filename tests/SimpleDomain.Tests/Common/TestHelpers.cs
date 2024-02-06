﻿// <copyright file="TestHelpers.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using MongoDB.Driver;
using SimpleDomain.Tests.GuidPrimary;

namespace SimpleDomain.Tests.Common
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

            client.GetDatabase("simple_domain").GetCollection<TestGuidEntity>("guid_entities").DeleteMany(Builders<TestGuidEntity>.Filter.Empty);
        }

        /// <summary>
        /// Gets the db connection string.
        /// </summary>
        /// <returns>The correct connection string.</returns>
        public static string ConnectionString()
        {
            return Environment.GetEnvironmentVariable("TEST_CONNECTION_STRING") ??
                                 "Server=.\\SQLExpress;Database=SimpleDomain.Tests;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=True;TrustServerCertificate=true";
        }

        /// <summary>
        /// Gets the Mongo connection string.
        /// </summary>
        /// <returns>The correct connection string.</returns>
        public static string MongoConnectionString()
        {
            return Environment.GetEnvironmentVariable("TEST_MONGO_CONNECTION") ?? "mongodb://localhost:27017";
        }
    }
}
