# Dotnet Async Demo

## Description

Example of converting synchronous code to asynchronous code using C#'s async & await language features.

## Directories

* Logging: Class Library project containing both the async and sync examples
* Logging.Tests: Unit tests for Logging project

## Directions

1. Open solution file dotnet-async-demo.sln
2. Build and Nuget restore 
3. Execute unit tests

** Note that the unit test contains a **[TestCleanup]** routine to delete the log file after each unit test execution.  If you plan on reviewing the contents of the log file, then simply place a breakpoint at line **36** within **LoggerTests.cs**, comment out this line of code or disable the test cleanup attribute itself.