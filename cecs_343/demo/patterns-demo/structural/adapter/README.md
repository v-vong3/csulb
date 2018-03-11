# Adapter Pattern

## Description

This pattern is used when you need to get existing, but incompatible components to interact with each other.  The Adapter Pattern consist of creating an _adapter_ object that is responsible for facilitating the interoperability between the two incompatible components.  The _adapter_ object is also referred to as a _wrapper_ or _wrapper_ object.

Note:  The Bridge Pattern is similar to the Adapter Pattern in structure.  The only difference is that the Bridge Pattern achieves it's goal by conforming implementations to a set interface.  As such, the Bridge Pattern is used when you are *able* to modify the interface of existing objects, while the Adapter Pattern is more suited to scenarios where you are *unable* to modify existing code.

## Example

Imagine you are tasked with migrating data from one source to another.  Lucky for you, two existing services were already developed by your predecessor: the FetchService retrieves data from a data source and the SubmitService sends data to a data source.  Unfortunately, both services are incompatible with each other since each service has methods that are reliant on disparate data types.  You are unable to modify these services due to other teams relying on the existing code base.  If you were to modify them in anyway, other teams' systems would break resulting in lots of angry emails.

Since you don't want to break existing systems, you decide to implement the Adapter Pattern in order to get both services to be able to interact with each other.  You create a _DataAdapter_ object that is responsible for converting data from the FetchService to a format that is compatible with the SubmitService.  Consequently, you are able to utilize both services without needing to update either's code base.

## Usage

``` csharp

// Instantiate adapter object
var dataAdapter = new DataAdapter();

// Instantiate both services
var fetchService = new FetchService();
var submitService = new SubmitService();

// Retrieve data from a data source
var fetchedData = fetchService.Fetch(123);

// Use adapter to convert data
var convertedData = dataAdapter.ConvertData(fetchedData);

// Submit data from a data source
submitService.Submit(convertedData);

```

## Advantages

* Allows incompatible objects to interact with each other
* Negates the need to change existing code, thus prevents potential for introducing breaking changes

## Disadvantages

* Adds additional objects to maintain (i.e. the _adapter_ object)
* Potential for performance penalty as the adapter implemenation may introduce additional network latency, threading restrictions and/or additional processing time.  This is typically unavoidable to achieve interoperability of incompatible components