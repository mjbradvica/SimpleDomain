// <copyright file="IAggregateRoot.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace ClearDomain.LongPrimary
{
    /// <summary>
    /// Interface constraint for a <see cref="long"/> AggregateRoot.
    /// </summary>
    public interface IAggregateRoot : IAggregateRoot<long>, IEntity
    {
    }
}
