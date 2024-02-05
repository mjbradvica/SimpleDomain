// <copyright file="IEntity.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using SimpleDomain.Common;

namespace SimpleDomain.GuidPrimary
{
    /// <inheritdoc/>
    public interface IEntity : IEntity<Guid>
    {
    }
}
