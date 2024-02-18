// <copyright file="IAggregateRoot.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using ClearDomain.Common;

namespace ClearDomain.GuidPrimary
{
    /// <summary>
    /// Interface constraint for a <see cref="Guid"/> AggregateRoot.
    /// </summary>
    public interface IAggregateRoot : IAggregateRoot<Guid>, IEntity
    {
    }
}
