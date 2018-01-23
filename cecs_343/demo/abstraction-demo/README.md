# Abstraction Demo

## About

This project provides a few guidelines for designing abstractions.  The focus will be more on the concept of abstractions rather than the actual implementation code.  This demo is similar to the **_solid-demo_** in terms of techniques used, but the goal is more to showcase how identifying and separating components will result in a cleaner and more extensible product.  It is recommended that you should view **_solid-demo_** first if you are new to .NET/C# as there are more syntax explanations covered in that demo.

## Requirements

* Design a system that formats names as [FirstName, LastName] (e.g. [Jobs, Steve], [Gates, Bill], etc.) instead of [FirstName LastName] (e.g. Steve Jobs, Bill Gates, etc.).

* All names comes from either a Comma-Separated Value (CSV) file or RESTful JSON web service. Assume that the data will only consist of incorrectly formatted names with the first and last name separated by a space.  For the CSV file, all records will be separated by a new line.  For the web service, all records will be separated as a record in an array.

  * CSV Sample Data

        Steve,Jobs  
        Bill,Gates  
        Elon,Musk  

  * Web Service Sample Data

        ["Steve Jobs", "Bill Gates", "Elon Musk"]

* All formatted names must be saved to either a relatonal database table or as a text file (.txt).

## Directory Stucture

### Before

**NOTE:** Implemantation flows shown here were actual approaches that I have seen in the wild.

A typical approach that I have seen is to create an object that is responsible for retrieving names from various sources, formatting the name and, finally, sending the formatted names to various destinations.  In this case, _NameProcessor_ is that object.

This approach satisfies the requirements, but it inherently has a major flaw.  _NameProcessor_ is too coupled to it's implementation.  The data sources needs to specifically be either a CSV file or a RESTful JSON web service.  The destination needs to specifically be either a table or a text file.  This makes the _design_ of the system "frozen" and any change that occurs will be a very involved process to implement.  In addition, there isn't a clear order for how the methods within _NameProcessor_ should be called; that decision is left to the user of the object to decide on, which can lead to improper use of the methods.

### After

First of all, the previous code base did not clearly identify the abstractions of the system, but instead focused on the implementations.  The system abstractions are inputs (csv & web service), processing (name format) and outputs (database & text file).  With this in mind we get a clearer picture of how the system flows and how it should be grouped.

The improvements that were made based on knowning the abstractions are:

* Added additional folders to organize the different abstractions of the system.  The code base now physically identifies the abstractions of the system.  All relevant code files are grouped together making code navigation easier.

* _NameProcessor_ is no longer tied to implementation details since it now relies on contracts (e.g. IDataSource, IFormat, IDestination).  The contracts were derived from the logical abstractions.

* _NameProcessor_ is more extensible as it can now be used with a myriad of data sources, formatting and destinations.  All that needs to happen is to provide the constructor with different parameter values.

Additional improvements can be made to make the system more robust such as making generic data sources and destination objects, however, the main point was to demonstrate how clean the code is when abstractions are identified and implemented properly.