// <copyright file="IAggregateRoot.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace ClearDomain.IntPrimary
{
    /// <summary>
    /// Interface constraint for a <see cref="int"/> AggregateRoot.
    /// </summary>
    public interface IAggregateRoot : IAggregateRoot<int>, IEntity
    {
    }
}
