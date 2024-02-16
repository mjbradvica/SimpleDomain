// <copyright file="Program.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;

namespace ClearDomain.Samples
{
    /// <summary>
    /// Samples program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Samples entry-point.
        /// </summary>
        public static void Main()
        {
            var airplane = new Airplane(1);

            var money = Money.FromDollars(159);

            var flight = new Flight(133, airplane, money);

            Console.WriteLine(money);

            Console.WriteLine(flight.Cost);
        }
    }
}
