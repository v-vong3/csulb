# Facade Pattern

## Description

This pattern is used when you want to simplify the mechanism for interacting with specific objects or service endpoints.  Consequently, it reduces the amount of knowledge needed in order to utilize these components, thus, the Facade Pattern is more for the benefit of other developers rather than the creator of the _Facade_ object.

## Example

Imagine you want to integrate with a free third-party security vendor.  The vendor have made available a service that searches the "dark" web for any username or any password that have been published, thus, allowing you to verify that a username or a password is insecure and should be changed immediately.  Although free of charge, the service is rather complex and for your company's need you always want to check if both a username and passwords are insecure.

Since you advocate developing secure systems and you want to ensure that other teams utilize this service as well, you decide to use the Facade Pattern.  Instead of directly using the vendor's service endpoints, you create a more simplified service based on the structure of the vendor's endpoints.  Instead of two endpoints, your service has one single endpoint to check both username and password breaches.  Your service acts as a facade on top of the vendor's service by masking the underlying details of what was needed to perform the _CheckCredentials()_ method.

## Usage

``` csharp

// Instantiate the facade object
var service = new BreachedPasswordService();


// Convert string data into byte[] data
var usernameData = Encoding.Unicode.GetBytes("username"); // .NET strings are Unicode by default
var passwordData = Encoding.Unicode.GetBytes("password");

// Calling entity only needs to know about the facade's single endpoint
var responseData = service.CheckCredentials(usernameData, passwordData);

```

## Advantages

* Reduces [coupling](https://en.wikipedia.org/wiki/Coupling_(computer_programming)) by abstracting out details of complex components
* Promotes code reuse due to reducing knowledge needed to utilize complex functionalities

## Disadvantages

* Adds additional objects to maintain (i.e. the _facade_ object and interface)
* Potential for performance penalty as the facade implemenation may introduces additional network latency, threading restrictions or additional processing time.  As such, in certain scenarios it may behoove developers to directly call the complex component instead of going through a facade layer