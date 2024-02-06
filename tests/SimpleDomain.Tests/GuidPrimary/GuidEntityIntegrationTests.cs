// <copyright file="GuidEntityIntegrationTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleDomain.Tests.Common;

namespace SimpleDomain.Tests.GuidPrimary
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
            using (var context = new TestDbContext())
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

            using (var context = new TestDbContext())
            {
                await context.GuidEntities.AddAsync(new TestGuidEntity(id));

                await context.SaveChangesAsync();
            }

            using (var context = new TestDbContext())
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
            using (var connection = new SqlConnection(TestHelpers.ConnectionString()))
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

            using (var connection = new SqlConnection(TestHelpers.ConnectionString()))
            {
                await connection.OpenAsync();

                var entity = new TestGuidEntity(id);

                await connection.ExecuteAsync($"INSERT INTO dbo.GuidEntities VALUES ('{entity.Id}');");

                await connection.CloseAsync();
            }

            using (var connection = new SqlConnection(TestHelpers.ConnectionString()))
            {
                await connection.OpenAsync();

                var result = await connection.QueryFirstAsync<TestGuidEntity>($"SELECT * FROM dbo.GuidEntities WHERE Id='{id}'");

                await connection.CloseAsync();

                Assert.IsNotNull(result);
                Assert.AreEqual(id, result.Id);
            }
        }
    }
}
