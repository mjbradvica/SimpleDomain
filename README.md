# ClearDomain

A collection of base classes and interfaces for DDD (Domain Driven Design) projects.

![TempIcon](https://i.imgur.com/Aj5IVzo.jpg)

![build-status](https://github.com/mjbradvica/ClearDomain/workflows/main/badge.svg) ![downloads](https://img.shields.io/nuget/dt/ClearDomain) ![downloads](https://img.shields.io/nuget/v/ClearDomain) ![activity](https://img.shields.io/github/last-commit/mjbradvica/ClearDomain/master)

## Overview

ClearDomain gives you:

- :seedling: Compact and straightforward API (3 classes and 3 interfaces)
- :muscle: Flexible to your needs
- :house: Reliable, consistent behavior
- :minidisc: Works with ADO.NET, Dapper, EF, and MongoDB
- :detective: ASP.NET Identity support

## Table of Contents

- [ClearDomain](#cleardomain)
  - [Overview](#overview)
  - [Table of Contents](#table-of-contents)
  - [Samples](#samples)
  - [Support](#support)
  - [Dependencies](#dependencies)
  - [Installation](#installation)
  - [Contents](#contents)
  - [Quick Start](#quick-start)
    - [Value Objects](#value-objects)
    - [Entities](#entities)
    - [Aggregate Roots](#aggregate-roots)
    - [Domain Events](#domain-events)
    - [Identity User](#identity-user)
  - [Detailed Usage](#detailed-usage)
    - [Entity Constraints](#entity-constraints)
    - [AggregateRoot Constraints](#aggregateroot-constraints)
    - [Entity \& AggregateRoot Encapsulation](#entity--aggregateroot-encapsulation)
    - [Domain Events with MediatR](#domain-events-with-mediatr)
    - [Using a Different Identifier Type](#using-a-different-identifier-type)
  - [Identity User Creation](#identity-user-creation)
  - [Identity User Types](#identity-user-types)
  - [FAQ](#faq)
    - [Do I need ClearDomain if I'm not using Domain Driven Design?](#do-i-need-cleardomain-if-im-not-using-domain-driven-design)
    - [What's the difference between an Entity and ValueObject?](#whats-the-difference-between-an-entity-and-valueobject)
    - [What's the difference between an Entity and AggregateRoot?](#whats-the-difference-between-an-entity-and-aggregateroot)
    - [Object Hierarchy Visualized](#object-hierarchy-visualized)
    - [How is equality for Entities and AggregateRoots calculated?](#how-is-equality-for-entities-and-aggregateroots-calculated)

## Samples

If you would like code samples for ClearDomain, they may be found [here](https://github.com/mjbradvica/ClearDomain/tree/master/samples/ClearDomain.Samples).

## Support

ClearDomain supports any version of .NET that allows for C# 9.0 and above. This currently includes NET5, NET6, NET7, and NET8.

> NetStandard 2.1 is not supported. This is due to a design decision to use the "init" keyword for properties.

## Dependencies

ClearDomain has no dependencies on any external Microsoft or third-party packages.

ClearDomain.Identity has a dependency on the ClearDomain base package and the [Microsoft.Extensions.Identity.Stores](https://www.nuget.org/packages/Microsoft.Extensions.Identity.Stores) package.

## Installation

The easiest way to get started is to: [Install with NuGet](https://www.nuget.org/packages/ClearDomain/).

Install where you need with:

```bash
Install-Package ClearDomain
```

If you are using the Identity version:

```bash
Install-Package ClearDomain.Identity
```

## Contents

ClearDomain gives you:

- Entities in either int, long, string, or Guid format with an interface constraint
- Value Objects with no generics or boiler-plate required
- Aggregate Roots with an interface constraint
- An empty interface used to constrain a Domain Event

ClearDomain.Identity provides:

- All of the above
- An IdentityUser class variant in integer, string, long, or Guid format
  with the same Aggregate Root behavior and interface constraints

## Purpose

Equality in dotnet is confusing and difficult to grasp if you are not aware of all the rules. ClearDomain is an attempt to remove some of the nuance and semantics around equality. It also provides a foundation for writing solid software with a small set of classes and interfaces you can build upon.

> You can still use ClearDomain even if your application is not strictly Domain Driven Design oriented.

## Quick Start

### Most Important Rules

The two most important rules with ClearDomain are:

1. Prefer the ".Equals()" method to "==", especially with Entities and AggregateRoots
2. Use interfaces such as [IEntity](https://github.com/mjbradvica/ClearDomain/blob/master/source/ClearDomain/GuidPrimary/IEntity.cs) as constraints, not base classes

### Value Objects

ValueObjects should all derive from the "ValueObject" base class.

```csharp
public class Money : ValueObject
{
    // implementation
}
```

The main characteristic of value objects is that their equality is based on their underlying properties.

```csharp
var first = Money.FromDollars(20);

var second = Money.FromDollars(20);

// true
var areEqual = first.Equals(second);

// works, but not recommended
var stillOk = first == second;
```

The main use for value objects is to model concepts that logically have no use for uniqueness. This may entail names, addresses, time, or in this example, money.

> Value Objects should be pure, modifying any value objects should return a completely new object.

It's a good idea to stick to static initializers for value objects. The DateTime object is a good example of an API to follow.

### Entities

Use an Entity when an object must have a unique identifier associated with it or needs to be persisted in physical storage.

```csharp
using ClearDomain.GuidPrimary;

// Guid based entity.
public class Person : Entity
{
}
```

> ClearDomain supports entities with either int, long, string, or Guid based identifiers. The type you use is determined by the namespace you import.

Entities use equality based on their identifiers.

```csharp
var first = new Person(1);

var second = new Person(1);

// true
var areEqual = first.Equals(second);

// DO NOT ATTEMPT. Entity operators are not overloaded.
var bad = first == second;
```

> Always use the Equals method for Entity equality comparison. More details are available [here](#entity-equality-details).

Entities have a default constructor that may be initialized during creation.

```csharp
public class Airplane : Entity
{
}

var airplane = new Airplane
{
    Id = Guid.NewGuid(),
};
```

> All entities use the "init" keyword for setters. The Id value may be set during object initialization, but not afterwards. This is to preserve encapsulation.

If you choose to use either Guid or string-based entities, the default constructor will initialize your object with an identifier value for you.

```csharp
var person = new Person();

// false
var isEmpty = person.Id == Guid.Empty;
```

> If you don't know which identifier to use, it is **highly recommended** to start with either GUIDs or strings.

### Aggregate Roots

An AggregateRoot is a designator for a logical boundary of entities and value objects.

AggregateRoots may contain domain events that react with other parts of your application.

Typically, these domain events are published when the aggregate root is saved, updated, or removed from persistence.

The following is a small example of a theoretical aggregate root that contains a list of items:

```csharp
public class ShoppingCart : AggregateRoot
{
    public IEnumerable<Item> Items { get; }

    public void AddItem(Item item)
    {
        Items.Add(item);

        AppendDomainEvent(new CartUpdated(item));
    }
}
```

The "AppendDomainEvent" method is virtual. You may override it to your liking.

> Aggregate Roots are a more specialized kind of entity that serve as an entry point to a model in your application.

### Domain Events

Domain Events in ClearDomain need to be inherited from the [IDomainEvent](https://github.com/mjbradvica/ClearDomain/blob/master/source/ClearDomain/Common/IDomainEvent.cs) interface. This is an empty constraint used to enforce that all domain events are classes.

```csharp
public class CardUpdated : IDomainEvent
{
    // properties in here
}
```

Use and publish a Domain Event when an Aggregate or model has something interesting to notify the rest of your application about.

The main benefit of using events is the ability to decouple your application from hard dependencies by publishing events. Customers may subscribe to specific events to implement accordingly.

### Identity User

The base IdentityUser class has been extended to support the same interfaces as Entities and Aggregate Roots.

Have your class inherit from the [ClearDomainIdentityUser](https://github.com/mjbradvica/ClearDomain/blob/development/source/ClearDomain.Identity/Common/ClearDomainIdentityUser.cs) class of your choice. As always, the type of the identifier is determined by what namespace you import.

> Unlike other Guid and string variants, the IdentityUser versions do no automatically create an identifier for you.

All of the ClearDomainIdentityUser base classes have the same constructors as the standard IdentityUser class. This is due to almost all properties being virtual.

```csharp
using ClearDomain.Identity.GuidPrimary;

public sealed class Customer : ClearDomainIdentityUser
{
    public Customer(string username)
    {
        Id = Guid.NewGuid();
        Username = username;
        SecurityStamp = Guid.NewGuid().ToString();
    }
}

var customer = new Customer("mikeBrad123");
```

It is highly recommended to apply the sealed keyword to avoid virtual calls in the constructor.

## Detailed Usage

### Entity Constraints

All entities derive from a single interface [IEntity](https://github.com/mjbradvica/ClearDomain/blob/master/source/ClearDomain/Common/IEntity.cs) that contains a getter-only property for the identifier.

This may be used when trying to query your persistence and you only require the single property.

```csharp
public async Task<int> DeleteEntity<T>(IEntity entity)
{
    var objValue = await Context.Set<T>.FindAsync(entity.Id);

    await Context.Set<T>.Remove(objValue);

    return await Context.SaveChangesAsync();
}
```

### Entity Equality Details

You should always use the Equals method for comparing entity equality. Using the "==" or "!=" will produce a compiler warning.

```csharp
var plane = new Airplane(1);

var plane2 = new Airplane(1);

// Warning: Possible unintended reference comparison.
var areSame = plane == plane2;
```

> ClearDomain does not overload the "==" or "!=" operators for Entities because they can only compare base types, not interfaces.

Unlike the Equals method, the "==" and "!=" can only be used against the same base type, not a set of interfaces. This could lead to undefined behavior, especially if you tried the operator with an "Entity" and "IdentityUser". They share the same interfaces, but calling the == on them would return false even if they had the same identifier.

Equality in C# is an advanced and difficult subject matter with lots of rules to follow. ClearDomain attempts to give you the user the easiest API to follow--but is still required to follow the rules of the language.

> We recommend using the Equals() method for everything so there will never be an issue.

### AggregateRoot Constraints

All aggregate roots derive from a single interface [IAggregateRoot](https://github.com/mjbradvica/ClearDomain/blob/master/source/ClearDomain/Common/IAggregateRoot.cs) that contains an IEnumerable of current domain events.

Similar to the IEntity interface, you may use this to constrain a parameter when you just need the domain events.

```csharp
private async Task PublishEvents(IAggregateRoot aggregateRoot)
{
    foreach (var domainEvent in aggregateRoot.DomainEvents)
    {
        await _bus.Publish(domainEvent);
    }
}
```

The method above is a small example of how you can publish domain events inside an object Repository.

> Aggregate Roots have all other downstream constraints such as IEntity

### Entity & AggregateRoot Encapsulation

If you do not wish for your entities to expose an empty constructor, you may define a constructor with a parameter that must be called.

```csharp
using ClearDomain.StringPrimary;

public class Airplane : Entity
{
    public Airplane(string id)
        : base(id)
    {
    }
}

// not possible, compile error
var incorrect = new Airplane();

var correct = new Airplane(Guid.NewGuid().ToString());
```

You may do the same for your AggregateRoots.

> The Microsoft base IdentityUser class has full public getters and setters. Utilizing constructors for your IdentityUser classes may not be worth it.

### Domain Events with MediatR

If you are using [MediatR](https://github.com/jbogard/MediatR) to publish events, it may be easier to create an interface that aggregates the interfaces necessary.

```csharp
public interface IEventNotification : INotification, IDomainEvent
{
}
```

Your new interface will now be used.

```csharp
public class CartUpdated : IEventNotification
{
    // properties in here
}
```

### Using a Different Identifier Type

If you wish to use an identifier type not provided you may extend the base classes.

1. Create an interface "IEntity" that extends from IEntity of type T where T is your new type
2. Create an abstract class "Entity" that extends from both Entity of T and your IEntity interface, then implement constructors as needed
3. Create an interface "IAggregateRoot" that extends from IAggregateRoot of type T where T is your new type and your closed "IEntity" interface
4. Create an abstract class "AggregateRoot" that extends from both AggregateRoot of T and your IAggregateRoot interface, then implement constructors as needed

## Identity User Creation

Due to the base properties being virtual, all ClearDomainIdentityUser classes have limited functionality in their constructors. The two biggest takeaways are:

1. You need to initialize the identifier value.
2. There are no null or empty identifier checks built in.

Even though all of the properties have public setters. You can still have a limited set of checks and balances with a custom constructor.

```csharp
using ClearDomain.Identity.GuidPrimary;

public sealed class Customer : ClearDomainIdentityUser
{
    public Customer(Guid id, string userName)
    {
        Id = id;

        if (Id == Guid.Empty)
        {
            throw new NullReferenceException(nameof(Id));
        }

        UserName = userName;
        SecurityStamp = Guid.NewGuid().ToString();
    }
}

var customer = new Customer(Guid.NewGuid(), "mikeBrad123");

// still possible
customer.Id = Guid.Empty;
```

## Identity User Types

All ClearDomainIdentityUser classes inherit from the same interfaces as normal Entities and AggregateRoots, but they **do not** share the same base classes.

This is due to only being able to inherit from a single concrete class in C#.

Here is a chart to help you visualize type comparisons:

| ClearDomainIdentityUser    | Inherits From |
| -------------------------- | ------------- |
| IEquatable of IEntity of T | Yes           |
| IEntity of T               | Yes           |
| IEntity (closed)           | Yes           |
| IAggregateRoot of T        | Yes           |
| IAggregateRoot (closed)    | Yes           |
| IdentityUser of T          | Yes           |
| Entity of T                | No            |
| Entity (closed)            | No            |
| AggregateRoot of T         | No            |
| AggregateRoot (closed)     | No            |

> A helpful reminder is to use the interfaces as constraints, NOT the base classes.

## FAQ

### Do I need ClearDomain if I'm not using Domain Driven Design?

Domain Driven Design (DDD) is a buffet. You can pick and choose what you want to use. You can still use aspects of ClearDomain even if your application is not a full DDD implementation.

### What's the difference between an Entity and ValueObject?

An Entity has a unique identifier and equality is based on said identifier.

A ValueObject has no identifier and equality is determined by individual property values.

> Dates, Names, Addresses, Time, and Money are all examples of ValueObjects.

### What's the difference between an Entity and AggregateRoot?

An AggregateRoot that defines an Aggregate is typically persisted via a Repository and is a logical barrier that contains other entities and value objects.

Every AggregateRoot is an Entity, but not every Entity is an AggregateRoot.

An entity is only accessed via the AggregateRoot that contains it. Entities may contain ValueObjects or references to other Entities.

### Object Hierarchy Visualized

ValueObjects and Entities at the bottom rung.

Aggregates are composed of a single AggregateRoot that contains other Entities and ValueObjects at the next level.

Finally, Aggregates are persisted via Repositories (not part of this package) and may publish DomainEvents exclusive to the model they represent.

### How is equality for Entities and AggregateRoots calculated?

All equality is based on the [IEntity](https://github.com/mjbradvica/ClearDomain/blob/master/source/ClearDomain/Common/IEntity.cs) of type T interface. This is the most basic type in ClearDomain.
