// <copyright file="TestDbContext.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using ClearDomain.Tests.GuidPrimary;
using ClearDomain.Tests.IntPrimary;
using ClearDomain.Tests.LongPrimary;
using ClearDomain.Tests.StringPrimary;
using Microsoft.EntityFrameworkCore;

namespace ClearDomain.Tests.Common
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
            StringEntities = Set<TestStringEntity>();
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

        /// <summary>
        /// Gets the string entity set.
        /// </summary>
        public DbSet<TestStringEntity> StringEntities { get; }

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(TestHelpers.ConnectionString());
        }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestIntEntity>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<TestLongEntity>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
