# SimpleDomain

A collection of base classes and interfaces for DDD (Domain Driven Design) projects.

![TempIcon](https://i.imgur.com/Aj5IVzo.jpg)

![build-status](https://github.com/mjbradvica/SimpleDomain/workflows/main/badge.svg) ![downloads](https://img.shields.io/nuget/dt/SimpleDomain) ![downloads](https://img.shields.io/nuget/v/SimpleDomain) ![activity](https://img.shields.io/github/last-commit/mjbradvica/SimpleDomain/master)

## Overview

SimpleDomain gives you:

- :seedling: Compact and straightforward API
- :muscle: Flexible to your needs
- :test_tube: Reliable, consistent behavior
- :minidisc: Works with ADO.NET, Dapper, EF, and MongoDB

## Table of Contents

- [SimpleDomain](#simpledomain)
  - [Overview](#overview)
  - [Table of Contents](#table-of-contents)
  - [Samples](#samples)
  - [Support](#support)
  - [Dependencies](#dependencies)
  - [Installation](#installation)
  - [Quick Start](#quick-start)
    - [Value Objects](#value-objects)
    - [Entities](#entities)
    - [Aggregate Roots](#aggregate-roots)
    - [Domain Events](#domain-events)
  - [Detailed Usage](#detailed-usage)
    - [Entity Constraints](#entity-constraints)
    - [AggregateRoot Constraints](#aggregateroot-constraints)
    - [Entity Encapsulation](#entity-encapsulation)
    - [Domain Events with MediatR](#domain-events-with-mediatr)
  - [FAQ](#faq)
    - [Do I need SimpleDomain if I'm not using Domain Driven Design?](#do-i-need-simpledomain-if-im-not-using-domain-driven-design)
    - [What's the difference between an Entity and ValueObject?](#whats-the-difference-between-an-entity-and-valueobject)
    - [What's the difference between an Entity and AggregateRoot?](#whats-the-difference-between-an-entity-and-aggregateroot)

## Samples

If you would like code samples for SimpleDomain, they may be found [here](https://github.com/mjbradvica/SimpleDomain/tree/master/samples/SimpleDomain.Samples).

## Support

SimpleDomain supports any version of .NET that allows for C# 9.0 and above. This currently includes NET5, NET6, NET7, and NET8.

NetStandard 2.1 is not supported.

## Dependencies

SimpleDomain has no dependencies on any external Microsoft or third-party packages.

## Installation

The easiest way to get started is to: [Install with NuGet](https://www.nuget.org/packages/SimpleDomain/).

Install where you need with:

```bash
Install-Package SimpleDomain
```

## Quick Start

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

var areEqual = first == second;

// true
```

The main use for value objects is to model concepts that logically have no use for uniqueness. This may entail names, addresses, time, or in this example, money.

> Value Objects should be pure, modifying any value objects should return a completely new object.

It's a good idea to stick to static initializes for value objects. The DateTime object is a good example of an API to follow.

### Entities

Use an Entity when an object must have a unique identifier associated with it or needs to be persisted in physical storage.

```csharp
using SimpleDomain.GuidPrimary;

// Guid based entity.
public class Person : Entity
{
}
```

> SimpleDomain supports entities with either int, long, string, or Guid based identifiers. The type you use is determined by the namespace you import.

Entities use equality based on their identifiers.

```csharp
var first = new Person(1);

var second = new Person(1);

var areEqual = first.Equals(second);

// true
```

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

var isEmpty = person.Id == Guid.Empty;

// false
```

> If you don't know which identifier to go with, it is **highly recommended** to start with either GUIDs or strings.

### Aggregate Roots

An AggregateRoot is a designator for a logical boundary of entities and value objects.

AggregateRoots may contain domain events that other parts of your application may react to.

Typically these domain events are published when the aggregate root is saved, updated, or removed from persistence.

The following is a small example of a theoretical aggregate root that contains a list of items.

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

> Aggregate Roots are a more specialized kind of entity that serve as an entry point to a model in your application.

### Domain Events

Domain Events in SimpleDomain need to be inherited from the [IDomainEvent](https://github.com/mjbradvica/SimpleDomain/blob/master/source/SimpleDomain/Common/IDomainEvent.cs) interface. This is an empty constraint used to enforce that all domain events are classes.

```csharp
public class CardUpdated : IDomainEvent
{
    // properties in here
}
```

## Detailed Usage

### Entity Constraints

All entities derive from a single interface [IEntity](https://github.com/mjbradvica/SimpleDomain/blob/master/source/SimpleDomain/Common/IEntity.cs) that contains a getter-only property for the identifier.

This may be used when trying to query your persistence and you only require the single property.

```csharp
public async Task<T> FindById<T>(IEntity entity)
{
    return await Context.Set<T>.FindAsync(entity.Id);
}
```

### AggregateRoot Constraints

All aggregate roots derive from a single interface [IAggregateRoot](https://github.com/mjbradvica/SimpleDomain/blob/master/source/SimpleDomain/Common/IAggregateRoot.cs) that contains an IEnumerable of current domain events.

Similar to the IEntity interface, you may use this to constrain a parameter when you just need the domain events.

```csharp
public async Task PublishEvent(IAggregateRoot aggregateRoot)
{
    foreach (var domainEvent in aggregateRoot.DomainEvents)
    {
        await _bus.Publish(domainEvent);
    }
}
```

### Entity Encapsulation

If you do not wish for your entities to expose an empty constructor, you may define a constructor with a parameter that must be called.

```csharp
using SimpleDomain.StringPrimary;

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

### Domain Events with MediatR

If you are using [MediatR](https://github.com/jbogard/MediatR) to publish events. It may be easier to create an interface that aggregates the interfaces necessary.

```csharp
public interface IEventNotification : INotification, IDomainEvent
{
}
```

Your new, simple interface will now be used.

```csharp
public class CardUpdated : IEventNotification
{
    // properties in here
}
```

## FAQ

### Do I need SimpleDomain if I'm not using Domain Driven Design?

Domain Driven Design (DDD) is like a buffet, you can pick and choose what you want to use. You can still use aspects of SimpleDomain even if your application is not a full DDD implementation.

### What's the difference between an Entity and ValueObject?

An Entity has a unique identifier and equality is based on said identifier.

A ValueObject has no identifier and equality is determined by individual property values.

Dates, Names, Addresses, Time, and Money are all examples of ValueObjects.

### What's the difference between an Entity and AggregateRoot?

An AggregateRoot is typically persisted via a Repository and is a logical barrier that contains other entities and value objects.

All AggregateRoots are entities, but not all entities are AggregateRoots.

An entity is only accessed via the AggregateRoot that contains them. Entities may contain ValueObjects or references to other Entities.
