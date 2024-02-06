// <copyright file="TestDbContext.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using SimpleDomain.Tests.GuidPrimary;
using SimpleDomain.Tests.IntPrimary;
using SimpleDomain.Tests.LongPrimary;

namespace SimpleDomain.Tests.Common
{
    /// <summary>
    /// Test db context.
    /// </summary>
    public sealed class TestDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestDbContext"/> class.
        /// </summary>
        public TestDbContext()
        {
            Database.EnsureCreated();

            GuidEntities = Set<TestGuidEntity>();
            IntEntities = Set<TestIntEntity>();
            LongEntities = Set<TestLongEntity>();
        }

        /// <summary>
        /// Gets the guid entity set.
        /// </summary>
        public DbSet<TestGuidEntity> GuidEntities { get; }

        /// <summary>
        /// Gets the int entity set.
        /// </summary>
        public DbSet<TestIntEntity> IntEntities { get; }

        /// <summary>
        /// Gets the long entity set.
        /// </summary>
        public DbSet<TestLongEntity> LongEntities { get; }

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(TestHelpers.ConnectionString());
        }
    }
}
