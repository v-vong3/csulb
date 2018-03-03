# Data Transfer Object (DTO) Pattern

## Description

This pattern is more of a design choice rather than a full-fledged design pattern.  DTOs are simple models (custom class objects) for moving data from one abstraction layer to another abstraction layer.  The purpose of DTOs is to make sure that the abstraction layer boundary is respected by

    * Not leaking (sensitive) information from one boundary to another
    * Explicitly requiring a defined structure needed for communication

By only communicating between boundaries as DTOs, you are restricting the data that another boundary has access to and you are explicitly enforcing what data you need to send to that boundary in order for it to complete the scenario.

## Example

Imagine you are tasked with displaying an existing user's profile on a profile screen.  The application mainly consists of the UI component, business component and data store component.  The profile UI needs to show the username, role, date of birth as MM/DD/YY and full name.

The data store stores the user's profile as the following field name and data type:

    * Username: string
    * Role: string
    * FirstName: string
    * LastName: string
    * DOB: DateTime
    * UserId: int
    * SSN: string

Finally, there is a parallel project being done to allow users to add a middle name to their profile.

Since you are a developer that values security and privacy you decide to use the DTO pattern. You accurrately deduced that both the UserId and SSN are sensitive information that should not be exposed to the UI boundary.  Therefore, you craft a DTO is purposely missing these two fields to ensure that the data does not get passed on.  Additionally, you simplified the data type for date of birth since you only needed a string literal in the UI.  Finally, you create a new property called FullName instead of passing FirstName and LastName individually.  This was to account for the potential for needing to add MiddleName down the road.  By just have one FullName property you don't have to alter your DTO again when MiddleName is added.

## Usage

``` csharp
// Model for interacting with business component
var profile = new UserProfile()
{
    Username = "",
    Role = "user",
    FirstName = "John",
    LastName = "Appleseed",
    DOB = new DateTime(1999, 9, 9),
    UserId = 1,
    SSN = "111-11-1111"
};

// Model specifically designed for only interacting with UI
var profileForUI = new UserProfileDto()
{
    Username = profile.Username,
    Role = profile.Role,
    DOB = profile.DOB.ToString("MM/DD/YY"),
    FullName = "{profile.FirstName} {profile.LastName}",
};

```

## Advantages

* Limits potential for accidental data leakage across application boundaries
* Can reduce complexity on the reciepient end, especially UI layer
* Decouples domain/business/data store object from the UI layer as each UI screen can have its own DTO thereby alleviating the need to alter all UI screen when a domain object is altered

## Disadvantages

* Increases the size of solution by requiring the crafting of a dedicated object for each DTO scenario
* Additional management all DTO
* Over engineering for scenarios where only a couple of parameters will ever be need to be transported

## Zero-Sum

* Reduce the need to directly modify method signatures, but instead is offloaded to the DTO itself