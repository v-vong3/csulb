# Mocking Demo

## Description

Demonstrates the technique of _mocking_ objects during software testing. This technique can be applied to achieve more robust tests through controlling the impact of any/all dependencies of the system under test (SUT).  

Examples will utilize Moq (pronounced "Mock-You" or just "Mock") library to control the behavior of dependencies of the SUT.

This technique can be applied to unit testing, integration testing, performance testings, etc.  

## Instructions

1. Build the project  

    >dotnet build  

2. Select the test to run

Installing NuGet packages manually if packages are not restored properly.

    dotnet add package xunit  
    dotnet add package Moq

## Activity

1. Create a C# interface called IValidateEmail that has a method for checking if an email address input is valid or not
2. Create a concrete implementation of IValidateEmail that searches a ```c List<string>``` to validate an email address input
3. Create a concrete implementation of IValidateEmail that uses a regular expression to validate an email address input  
4. Create another class that requires both implementations as dependencies. The class will need the following methods:
    i. public method ValidateViaList that calls the class from step 2
    ii. public method ValidateViaRegex that calls the class from step 3
    iii. private method ValidateBoth that calls both
5. Use Moq to create success and failure test cases for all three methods while isolating the impact of the implementation of each method  

Explain what you would need to change in your tests if a new concrete implementation of IValidateEmail was required that validates email addresses through a database look up.  

Elaborate on any issues that you encountered while performing this activity.
