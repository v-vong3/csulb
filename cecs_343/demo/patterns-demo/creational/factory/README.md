# Factory Pattern

## Description

This pattern is used when you do NOT want to repeat instantiation logic everywhere in your code base and you want to offload the responsibility of knowing how to create dependencies.  The Factory pattern consolidates all code needed to create a *new *instance of an object, therefore, the _factory_ object is the sole entity that should be used when a new instance is needed.  Consequently, you no longer need to use the _new_ keyword when creating an instance.  Ideally, you only want to use the Factory pattern for objects that have complex or lengthy instantiation logic as the pattern would reduce code redundancy greatly.

NOTE:
The Factory pattern (sometimes called Simple Factory) and Factory Method pattern essentially the same pattern with one key difference: The Factory pattern is implemented as a dedicated object while the Factory Method pattern is implemented as an abstract method that is extended through [Method Overriding](https://en.wikipedia.org/wiki/Method_overriding).  Both approaches are used for alleviating the need for using the _new_ keyword and all the benefits that comes with it.

## Example

Image you have to build an application whose data store is in flux.  You do not know if the data store will be Sql-based, NoSQL or file-based.  Your manager has stated that the default will be a Sql-based system.

Since you strive for extensibility, you decided to implement the Factory pattern for the data access object ([see Repository Pattern for DAO](../../behavioral/repository/README.md)).  The Factory pattern will help you resolve the uncertainty of the data store by allowing you to easily swap data store implemenation through a minor code change instead of a rewrite of the entire application.  In addition, you extend your system to be able to handle current scenarios as well as any potential future scenario as you can simply implement a new data store class and register that class with the data store factory.

## Usage

``` csharp

// Instantiate the factory object
// If implemented as a static object, I wouldn't need to use the new keyword here
var dataStoreFactory = new DataStoreFactory();

// Instantiate a SQL-based data store
var sqlDataStore = dataStoreFactory.Create(DataStoreTypes.Default);

// Instantiate a NoSQL-based data store
var noSqlDataStore = dataStoreFactory.Create(DataStoreTypes.NoSql);

// Instantiate a File-based data store
var noSqlDataStore = dataStoreFactory.Create(DataStoreTypes.File);

```

## Advantages

* Improves maintainability of code base
  * Easier to implement object instantiation code changes on a global scale
  * Easier to implement global swapping of object instances (i.e. swapping one object for another)
* Reduces existance of redundant code in the form of repeated instantiation logic

## Disadvantages

* Adds an additional object that needs to be maintained (i.e. the _factory_ object)
* Requires (potentially convoluted) logic to pass arguments into the right object's constructor
* Can lead to gigantic _switch_ or _if-else_ code blocks if you are not using some sort of dynamic code inspection in order to select the object to create ([see .NET Reflection](https://docs.microsoft.com/en-us/dotnet/framework/reflection-and-codedom/reflection))

## Zero-Sum

* Promotes normalization of constructors for all objects the factory is responsible for creating
  * Makes instantiation of objects easier
  * Prevents customization of the instantiation of an object (i.e. using different parametered constructors)