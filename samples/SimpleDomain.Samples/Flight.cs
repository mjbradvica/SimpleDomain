// <copyright file="Flight.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using SimpleDomain.LongPrimary;

namespace SimpleDomain.Samples
{
    /// <summary>
    /// Sample Aggregate Root.
    /// </summary>
    public class Flight : AggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Flight"/> class.
        /// </summary>
        /// <param name="id">Flight identifier.</param>
        /// <param name="airplane">Assigned plane for the flight.</param>
        /// <param name="cost">Estimated flight cost.</param>
        public Flight(long id, Airplane airplane, Money cost)
            : base(id)
        {
            AssignedPlane = airplane;
            Cost = cost;
        }

        /// <summary>
        /// Gets the flight cost.
        /// </summary>
        public Money Cost { get; private set; }

        /// <summary>
        /// Gets the assigned plane.
        /// </summary>
        public Airplane AssignedPlane { get; }
    }
}
