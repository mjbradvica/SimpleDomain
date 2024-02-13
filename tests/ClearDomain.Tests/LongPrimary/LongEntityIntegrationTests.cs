// <copyright file="LongEntityIntegrationTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClearDomain.Tests.Common;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace ClearDomain.Tests.LongPrimary
{
    /// <summary>
    /// Long entity integration tests.
    /// </summary>
    [TestClass]
    public class LongEntityIntegrationTests : BaseIntegrationTest
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
                await context.LongEntities.AddAsync(new TestLongEntity());

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
            await using (var context = new TestDbContext())
            {
                await context.LongEntities.AddAsync(new TestLongEntity());

                await context.SaveChangesAsync();
            }

            await using (var context = new TestDbContext())
            {
                var result = await context.LongEntities.ToListAsync();

                Assert.IsNotNull(result.First());
                Assert.IsTrue(result.First().Id > 0);
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

                var entity = new TestLongEntity();

                await connection.ExecuteAsync("SET IDENTITY_INSERT dbo.LongEntities ON; INSERT INTO dbo.LongEntities (Id) VALUES ('1');");

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
            const int id = 1;

            await using (var connection = new SqlConnection(TestHelpers.ConnectionString()))
            {
                await connection.OpenAsync();

                var entity = new TestLongEntity(id);

                await connection.ExecuteAsync($"SET IDENTITY_INSERT dbo.LongEntities ON; INSERT INTO dbo.LongEntities (Id) VALUES ('{id}');");

                await connection.CloseAsync();
            }

            await using (var connection = new SqlConnection(TestHelpers.ConnectionString()))
            {
                await connection.OpenAsync();

                var result = await connection.QueryFirstAsync<TestLongEntity>($"SELECT * FROM dbo.LongEntities WHERE Id='{id}';");

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

                var entity = new TestLongEntity(1);

                var transaction = connection.BeginTransaction();

                var command = new SqlCommand($"SET IDENTITY_INSERT dbo.LongEntities ON; INSERT INTO dbo.LongEntities (Id) VALUES ('{entity.Id}');", connection, transaction);

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
            const int id = 1;

            await using (var connection = new SqlConnection(TestHelpers.ConnectionString()))
            {
                await connection.OpenAsync();

                var entity = new TestLongEntity(id);

                var transaction = connection.BeginTransaction();

                var command = new SqlCommand($"SET IDENTITY_INSERT dbo.LongEntities ON; INSERT INTO dbo.LongEntities (Id) VALUES ('{entity.Id}');", connection, transaction);

                await command.ExecuteNonQueryAsync();

                await transaction.CommitAsync();

                await connection.CloseAsync();
            }

            await using (var connection = new SqlConnection(TestHelpers.ConnectionString()))
            {
                await connection.OpenAsync();

                var command = new SqlCommand($"SELECT * FROM dbo.LongEntities WHERE Id='{id}';", connection);

                var response = await command.ExecuteReaderAsync();

                var entities = new List<TestLongEntity>();

                while (await response.ReadAsync())
                {
                    entities.Add(new TestLongEntity(response.GetInt64(0)));
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

            var collection = client.GetDatabase("simple_domain").GetCollection<TestLongEntity>("long_entities");

            await collection.InsertOneAsync(new TestLongEntity(1));
        }

        /// <summary>
        /// Ensures an entity can be retrieved correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Entity_Mongo_CanBeRetrieved()
        {
            const int id = 1;

            var client = new MongoClient(TestHelpers.MongoConnectionString());

            var collection = client.GetDatabase("simple_domain").GetCollection<TestLongEntity>("long_entities");

            await collection.InsertOneAsync(new TestLongEntity(id));

            var filter = Builders<TestLongEntity>.Filter.Eq(x => x.Id, id);

            var result = await collection.FindAsync(filter);

            IEnumerable<TestLongEntity> results = new List<TestLongEntity>();

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
