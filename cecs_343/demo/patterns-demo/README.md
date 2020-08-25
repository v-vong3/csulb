# Design Patterns Demo

## About

This project showcases design patterns that addresses common software engineering scenarios.  In order to reduce a pattern's complexity so that the core concepts are more digestable, a few liberties were taken for each pattern presentation.  In addition, the example code utilizes various .NET features, thus, the demos are specific to this techonology.  However, it is important to explicitly state that design patterns are meant to be **_technology agnostic_**, meaning that the core concepts are applicable to other Object-Oriented programming languages (e.g. Java, Python, etc.).

Patterns presented here are mostly based off of the original Gang of Four (GoF) patterns described in _Design Patterns: Elements of Reusable Object-Oriented Software_.  A few patterns are not as they were discovered from researching the public works of innovators of the field such as Martin Fowler, therefore, all credit goes to their respective creators.

## Important

It is worth noting that there is a sort of antithesis to design patterns called the _Anti-Pattern_.  This term is an umbrella category for patterns that seemingly addresses a current software engineering problem, but is later discovered to have been a bad decision as it resulted in maintainability issues or worse.  For example, many believe that the Singleton Pattern is an anti-pattern as it leads to unintended behaviors when scaling to a multi-threaded environment from a single-threaded environment.

## Convention

* **Bolded** patterns are patterns that are addressed
* _Italic_ patterns are patterns that were not described by the GoF
* **_Bolded and italic_** patterns are addressed in the project and were not described by the GoF

## Pattern Categories

* **Creational Patterns** - Patterns that focus on object creation
  * **Abstract Factory**
  * **Factory/Factory Method**
  * Singleton
  * **Builder**
  * Prototype

* **Structural Patterns** - Patterns that focus on the composition of an object
  * **Adapter**
  * Bridge
  * Composite
  * Decorator
  * **Facade**
  * Flyweight
  * Proxy
  * **_Data Transfer Object (DTO)_**

* **Behavioral Patterns** - Patterns that focus on the interaction and delegation of responsibilities between multiple objects
  * Chain of Responsibility
  * **Command**
  * Interpreter
  * Iterator
  * Mediator
  * Memento
  * Observer
  * State
  * **Strategy**
  * Template Method
  * Visitor
  * **_Repository_**

## Directory Structure

* _pattern root_ - Contains class files that are needed by objects in both _contract_ and _implementation_ folders
* contract - Contains any applicable contract or class files that defines a set behavior
* implementation - Contains the concrete implememtation of contracts found in the _contract_ folder and/or any stand-alone class files specific to the demonstration of the pattern