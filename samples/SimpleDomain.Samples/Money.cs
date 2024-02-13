// <copyright file="Money.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using SimpleDomain.Common;

namespace SimpleDomain.Samples
{
    /// <summary>
    /// Sample class to model money.
    /// </summary>
    public class Money : ValueObject
    {
        private Money(decimal dollars, decimal cents)
        {
            Dollars = dollars;
            Cents = cents;
        }

        /// <summary>
        /// Gets the whole dollars amount.
        /// </summary>
        public decimal Dollars { get; }

        /// <summary>
        /// Gets the whole cents amount.
        /// </summary>
        public decimal Cents { get; }

        /// <summary>
        /// Gets the whole Money value.
        /// </summary>
        public decimal Value => Dollars + (Cents * .01m);

        /// <summary>
        /// Instantiates a money value from dollars.
        /// </summary>
        /// <param name="dollars">A dollars value.</param>
        /// <returns>A new <see cref="Money"/> instance.</returns>
        public static Money FromDollars(decimal dollars)
        {
            return new Money(dollars, 0);
        }

        /// <summary>
        /// Instantiates a money value from cents.
        /// </summary>
        /// <param name="cents">A cents value.</param>
        /// <returns>A new <see cref="Money"/> instance.</returns>
        public static Money FromCents(decimal cents)
        {
            const int centsPerDollar = 100;

            var dollars = Math.Round(cents / centsPerDollar);

            var remainderCents = cents % centsPerDollar;

            return new Money(dollars, remainderCents);
        }

        /// <summary>
        /// Value of <see cref="Money"/> as a string.
        /// </summary>
        /// <returns>A string value of the Money.</returns>
        public override string ToString()
        {
            return $"{Dollars} Dollars & {Cents} Cents";
        }
    }
}
