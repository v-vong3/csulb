# Dotnet Host Demo

## Description

This demo covers the following topics due to the relevance to the .NET and ASP.NET Core bootup process:

1. Visual Studio's Console App template
2. Visual Studio's Web API template
3. .NET's Generic Host with Hosted Service
4. .NET's WebApplication Host (introduced in .NET 6.0)
5. .NET application bootstrapping using the "old" approach
6. .NET application bootstrapping using the "new" Minimum API approach
7. Using .NET's DI Container in Console applications
8. Using .NET's DI Container in Web applications
9. Using .NET's DI Container stand-alone 

Understanding these concepts will lead to properly setting up a .NET application.  

## Directories  

Non-runnable Projects
* LibAccount: An external library for use with DI examples

DI Projects
* DI.Tests: Provides examples of using .NET's DI Container outside of .NET Hosts

Web API Projects
* WebApi-Empty: For exploring ASP.NET Core from scratch 
* WebApi-MinApi: Example of Minimum API setup
* WebApi-Controller: Recommended template to use for creating Web Services

Console Projects
* ConsoleApp-OldApi: For showing the underlying class (Program) and method (Main() method) in non Top Level Statements
* ConsoleApp-MinApi: Example of Top Level Statements still having access to "args"
* ConsoleApp-Bootstrap: Recommended template to use for creating console or background (daemon) apps


## Directions

1. Rebuild the project to ensure all dependencies (NuGet packages and Project deps) are set
2. Navigate to the directory of the console or web api project to run (make sure the .csproj file is present in the directory)
3. Use "dotnet run" .csproj file or use .NET compliant IDE to execute project 