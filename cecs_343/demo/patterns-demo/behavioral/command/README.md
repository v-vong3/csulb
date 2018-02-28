# Command Pattern

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

* Does not account for exception handling.  All implementations must align with an exception handling strategy or else unpredictable results can occur
* Reliant on the creation of the command to be properly configured prior to invocation of command

## See Also

* The [Strategy Pattern](../strategy/README.md) provides another example of how to leverage the *Command* pattern