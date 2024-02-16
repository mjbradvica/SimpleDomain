// <copyright file="IAggregateRoot.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace ClearDomain.IntPrimary
{
    /// <inheritdoc />
    public interface IAggregateRoot : IAggregateRoot<int>
    {
    }
}
