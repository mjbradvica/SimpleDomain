// <copyright file="Program.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using ClearDomain.Samples.GuidIdentity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task Main()
        {
            var provider = BuildDependencies();

            var customer = new GuidCustomer(Guid.NewGuid(), "mikeBrad123");

            var userManger = provider.GetRequiredService<UserManager<GuidCustomer>>();

            // await userManger.CreateAsync(customer, "SuperSecret123!");
            var foundCustomer = await userManger.FindByNameAsync("mikeBrad123");

            if (foundCustomer != null)
            {
                Console.WriteLine(foundCustomer.Id);
            }

            var id = Guid.NewGuid();

            var first = new GuidCustomer(id, "anotherUserName");
            var second = new GuidCustomer(id, "someUserName");

            // Customers' have entity equality
            Console.WriteLine(first.Equals(second));

            // Customers can add domain events.
            first.AppendDomainEvent(new CustomerCreated());
        }

        private static IServiceProvider BuildDependencies()
        {
            var collection = new ServiceCollection();

            collection.AddDbContext<GuidCustomerContext>(x => x.UseSqlServer("Server=.\\SQLExpress;Database=ClearDomain.Samples;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=True;TrustServerCertificate=true"));

            collection
                .AddIdentityCore<GuidCustomer>()
                .AddEntityFrameworkStores<GuidCustomerContext>();

            collection.AddLogging();

            return collection.BuildServiceProvider();
        }
    }
}
