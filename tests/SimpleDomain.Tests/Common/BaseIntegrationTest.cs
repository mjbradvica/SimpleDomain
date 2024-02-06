// <copyright file="BaseIntegrationTest.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using SimpleDomain.Tests.GuidPrimary;

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
            if (BsonSerializer.LookupSerializer(typeof(GuidSerializer)) == null)
            {
                BsonSerializer.TryRegisterSerializer(new GuidSerializer());
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(TestGuidEntity)))
            {
                BsonClassMap.RegisterClassMap<TestGuidEntity>(map =>
                {
                    map.AutoMap();
                });
            }

            TestHelpers.ClearDatabase();
        }
    }
}
