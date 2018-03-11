# Design Patterns Demo

## About

This project showcases common design patterns.  Liberties were taken for each example in order to scaled down a pattern or alter it slightly in order to improve comprehension of the concept.  In addition, modifications were made so that the code is aligned within the .NET stack.  All patterns based off of the original Gang of Four (GoF) patterns described in _Design Patterns: Elements of Reusable Object-Oriented Software_.

## Convention

* Bolded patterns are patterns that are addressed
* Italic patterns are patterns that were not described by the GoF
* Bolded and italic patterns are addressed in the project and were not described by the GoF

## Pattern Categories

* Creational Patterns - Patterns that focus on object creation
  * **Abstract Factory**
  * **Factory/Factory Method**
  * Singleton
  * **Builder**
  * Prototype

* Structural Patterns - Patterns that focus on the composition of an object
  * **Adapter**
  * Bridge
  * Composite
  * Decorator
  * **Facade**
  * Flyweight
  * Proxy
  * **_Data Transfer Object (DTO)_**

* Behavioral Patterns - Patterns that focus on the interaction and delegation of responsibilities between multiple objects
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

* contract - Folder to contain any applicable .NET interface files
* implementation - Folder to contain the concrete implememtation of .NET interfaces or stand-alone class files