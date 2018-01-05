# SOLID Prinicples Demo

## About

This project provides examples showcasing the application of the **SOLID** principles.  The project is for educational purposes only and is meant to help the comprehension of **Object-Oriented Design and Analysis (OODA)** concepts.  The main auidence are upper division computer science students, but programming enthusiasts can leverage this project as well, however, it may require more tangental research if the audience is not familiar with basic programming concepts.

The examples are College-themed to be more relatable to the main audience and assumes that the audience is familar with Java/C#, basic data structures and introductory level programming concepts such as a "Constructor", inheritance and object instantiation.

## Directory Structure

* Each principle is broken up into separate folders named after the principle.  Numbers in the folder names are for identifying the **recommended order** that the audience should review the demo in.

* Each principle directory contains a _Before_ and an _After_ subfolder.  The _Before_ subfolder contains code in which the principle has **NOT** been applied, _but_ has been updated to reflect requirements.  The _After_ subfolder contains code in which the principle **has** been applied _and_ requirements are satisfied.

* Each principle is meant to be self-containing and isolated.  As such, there are duplicate code files from one principle directory to another, but the namespaces of the duplicate files have been updated to match the proper directory.  This was done on purpose to reduce the need to navigate across multiple folder hierarchies and reduce file confusion.  It is **highly** recommened that this practice should **NOT** be followed other than in teaching scenarios.

* Each principle directory contains a README.md file detailing business requirements, _Before_ consequences and _Afer_ consequences.

## README Conventions

* Italic text is used when referring to a specific object, methood, etc.

* The entire filename with extension is used when referring to a specific file

## Important

* This code is **NOT** production-ready.

* This demo was intended to be a presentation.  As such, additional context was added during the presentation and thus some parts may be more coherent than others.

* Basic data structures and what-not were used **purposefuly** to reduce friction-points to learning the concepts.  Therefore, language-specific optimizations, such as automatic setters were not used.

* XML-comments were not used to reduce "noise" while reading the code so that the audience can just focus on comprehending the concepts.

* Normal code comments were included to help improve comprehension of the code for those that are new to .NET/C#.

* This project was updated to target .NET Standard 2.0 as of 1/1/2018.