# Command Pattern

## Description

This pattern is used when you want to establish a common approach for representng/invoking requests or operations.  By doing so, you _reduce_ the need to create new handlers for each and every request/operation.  Since all request/operations are in a uniform structure, a generic handler can be used for satisfying most scenarios.  For scenarios where you need a more grandular control flow, the uniform structure provides a mechanism for adding a custom handler for the request/operation.

## Example

Imagine you are tasked with developing a validation component.  Like any good developer, you want to make this component as extensible as possible and thus be able to handle different scenarios.  The required scenario was age validation (i.e. validate if a person is a legal adult in the U.S.).  However, you also realized that parking validation (i.e. validate if a user's alloted free parking time has expired) is another scenario that would need to be addressed.

In order to support these disparate scenarios, you use the Command Pattern to encapsulate the operation of _validation_ since the commonality of both scenarios is to validate something.  By turning the _validation_ operation into an object, the calling entity no longer needs to know about the implementaion details of actual validation that is taking place.  Instead, the calling entity only needs to know that the object contains a _validation_ method.

## Usage

``` csharp

// *************** AGE SCENARIO ********************
var minorPerson = new Person()
{
    FirstName = "John",
    LastName = "Smith",
    Age = 15
};
var adultPerson = new Person()
{
    FirstName = "Jane",
    LastName = "Smith",
    Age = 25
}

// Instantiating a concrete IValidator
IValidator validator = new AgeValidator();

var falseResult = validator.Validate(minorPerson);
var trueResult = validator.Validate(adultPerson);

// *************** TICKET SCENARIO ********************
var ticket = new ParkingTicket(15.50);

// Instantiating a concrete IValidator
validator = new ParkingValidator(); // Reuse of variable possible due to shared interface

var ticketResult = validator.Validate(ticket);

```

## Advantages

* Improves the maintainability of a system by isolating business logic (i.e. easier to change and test code)
* Improves the extensibility of a system by establishing a mechanism for adding new capabilities without needing to change existing functionality

## Disadvantages

* Adds additional objects to maintain (i.e. the concrete _Command_ objects and interface)
* Does not account for exception handling.  All implementations must align with an exception handling strategy or else unpredictable results can occur
* Reliant on the creation of the command to be properly configured prior to invocation of command

## See Also

* The [Strategy Pattern](../strategy/README.md) provides another example of how to leverage the *Command* pattern