# Facade Pattern

## Description

This pattern is used when you want to simplify the mechanism for interacting with specific objects or service endpoints.  Consequently, it reduces the amount of knowledge or effort needed in order to utilize a component.

For example, imagine if a component only have methods that accept string parameters that are encoded in Base64.  Base64 encoding is a bit uncommon, thus, working with this component would require more effort than usaual.  To simplify usage, the Facade Pattern can be used to abstract out the Base64 encoding detail by instead creating an object that "sits on top" of the component.  This new object, called the _facade_ object, would expose methods that allow a more common string encoding to be used such as UTF-8.  Internally, the _facade_ object would be responsible for the conversion of UTF-8 to Base64 prior to forwarding the request over to the component.  In this scenario, the user of the _facade_ object no longer needs to know about the Base64 requirement nor the fact there is a component behind the scene.

Typically, the Facade Pattern is more for the benefit of others rather than for the creator of the _facade_ object.  The _facade_ object can be for either internal or external use; by developers or by clients.  The goal is to make it eaiser to use a (complex) component when you are unable to alter existing code or you just want to hide specific details that are unnecessary.

## Example

Imagine you want to integrate with a free third-party security vendor.  The vendor has made available a service that searches the "dark" web for any username or any password that have been published, thus, allowing you to verify that a username or a password is insecure and should be changed immediately.  Although free of charge, the service is rather complex and for your company's need you always want to check if both a username and passwords are insecure.

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