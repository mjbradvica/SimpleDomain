// <copyright file="AggregateRoot.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using SimpleDomain.Common;

namespace SimpleDomain.StringPrimary
{
    /// <summary>
    /// Base class for all <see cref="string"/> aggregate roots.
    /// </summary>
    public class AggregateRoot : AggregateRoot<string>, IAggregateRoot
    {
    }
}
