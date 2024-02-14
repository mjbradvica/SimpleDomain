// <copyright file="GuidEntityIntegrationTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClearDomain.Tests.Common;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;

namespace ClearDomain.Tests.GuidPrimary
{
    /// <summary>
    /// Guid entity integration tests.
    /// </summary>
    [TestClass]
    public class GuidEntityIntegrationTests : BaseIntegrationTest
    {
        /// <summary>
        /// Ensures an entity can be persisted correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Entity_EF_CanBePersisted()
        {
            await using (var context = new TestDbContext())
            {
                await context.GuidEntities.AddAsync(new TestGuidEntity(Guid.NewGuid()));

                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Ensures an entity can be retrieved correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Entity_EF_CanBeRetrieved()
        {
            var id = Guid.NewGuid();

            await using (var context = new TestDbContext())
            {
                await context.GuidEntities.AddAsync(new TestGuidEntity(id));

                await context.SaveChangesAsync();
            }

            await using (var context = new TestDbContext())
            {
                var result = await context.GuidEntities.FindAsync(id);

                Assert.IsNotNull(result);
                Assert.AreEqual(id, result.Id);
            }
        }

        /// <summary>
        /// Ensures an entity can be persisted correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Entity_Dapper_CanBePersisted()
        {
            await using (var connection = new SqlConnection(TestHelpers.ConnectionString()))
            {
                await connection.OpenAsync();

                var entity = new TestGuidEntity(Guid.NewGuid());

                await connection.ExecuteAsync($"INSERT INTO dbo.GuidEntities VALUES ('{entity.Id}');");

                await connection.CloseAsync();
            }
        }

        /// <summary>
        /// Ensures an entity can be retrieved correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Entity_Dapper_CanBeRetrieved()
        {
            var id = Guid.NewGuid();

            await using (var connection = new SqlConnection(TestHelpers.ConnectionString()))
            {
                await connection.OpenAsync();

                var entity = new TestGuidEntity(id);

                await connection.ExecuteAsync($"INSERT INTO dbo.GuidEntities VALUES ('{entity.Id}');");

                await connection.CloseAsync();
            }

            await using (var connection = new SqlConnection(TestHelpers.ConnectionString()))
            {
                await connection.OpenAsync();

                var result = await connection.QueryFirstAsync<TestGuidEntity>($"SELECT * FROM dbo.GuidEntities WHERE Id='{id}';");

                await connection.CloseAsync();

                Assert.IsNotNull(result);
                Assert.AreEqual(id, result.Id);
            }
        }

        /// <summary>
        /// Ensures an entity can be persisted correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Entity_ADO_CanBePersisted()
        {
            await using (var connection = new SqlConnection(TestHelpers.ConnectionString()))
            {
                await connection.OpenAsync();

                var entity = new TestGuidEntity(Guid.NewGuid());

                var transaction = connection.BeginTransaction();

                var command = new SqlCommand($"INSERT INTO dbo.GuidEntities VALUES ('{entity.Id}');", connection, transaction);

                await command.ExecuteNonQueryAsync();

                await transaction.CommitAsync();

                await connection.CloseAsync();
            }
        }

        /// <summary>
        /// Ensures an entity can be retrieved correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Entity_ADO_CanBeRetrieved()
        {
            var id = Guid.NewGuid();

            await using (var connection = new SqlConnection(TestHelpers.ConnectionString()))
            {
                await connection.OpenAsync();

                var entity = new TestGuidEntity(id);

                var transaction = connection.BeginTransaction();

                var command = new SqlCommand($"INSERT INTO dbo.GuidEntities VALUES ('{entity.Id}');", connection, transaction);

                await command.ExecuteNonQueryAsync();

                await transaction.CommitAsync();

                await connection.CloseAsync();
            }

            await using (var connection = new SqlConnection(TestHelpers.ConnectionString()))
            {
                await connection.OpenAsync();

                var command = new SqlCommand($"SELECT * FROM dbo.GuidEntities WHERE Id='{id}';", connection);

                var response = await command.ExecuteReaderAsync();

                var entities = new List<TestGuidEntity>();

                while (await response.ReadAsync())
                {
                    entities.Add(new TestGuidEntity(response.GetGuid(0)));
                }

                var result = entities.First();

                await connection.CloseAsync();

                Assert.IsNotNull(result);
                Assert.AreEqual(id, result.Id);
            }
        }

        /// <summary>
        /// Ensures an entity can be persisted correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Entity_Mongo_CanBePersisted()
        {
            var client = new MongoClient(TestHelpers.MongoConnectionString());

            var collection = client.GetDatabase("simple_domain").GetCollection<TestGuidEntity>("guid_entities");

            await collection.InsertOneAsync(new TestGuidEntity(Guid.NewGuid()));
        }

        /// <summary>
        /// Ensures an entity can be retrieved correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Entity_Mongo_CanBeRetrieved()
        {
            var id = Guid.NewGuid();

            var client = new MongoClient(TestHelpers.MongoConnectionString());

            var collection = client.GetDatabase("simple_domain").GetCollection<TestGuidEntity>("guid_entities");

            await collection.InsertOneAsync(new TestGuidEntity(id));

            var filter = Builders<TestGuidEntity>.Filter.Eq(x => x.Id, id);

            var result = await collection.FindAsync(filter);

            IEnumerable<TestGuidEntity> results = new List<TestGuidEntity>();

            if (await result.MoveNextAsync())
            {
                results = result.Current;
            }

            foreach (var document in results)
            {
                Assert.IsNotNull(document);
                Assert.AreEqual(id, document.Id);
            }
        }
    }
}
