// <copyright file="IAggregateRoot.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using SimpleDomain.Common;

namespace SimpleDomain.LongPrimary
{
    /// <inheritdoc />
    public interface IAggregateRoot : IAggregateRoot<long>
    {
    }
}
