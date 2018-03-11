# Abstract Factory Pattern

## Description

This pattern is used when you want to encapsulate the creation of _strongly related_ objects (also known as a _product_) that can be grouped underneath a single category (also known as a _family_).  Buttons, TextArea and Scrollbars are all UI-centric products, thus, they belong in the _UI family_ and can be encapsulated in a UI _abstract factory_.  The _abstract factory_ object acts as an entry point for when you need to create a family of objects.  _Abstract_ factories are simliar to _factory_ objects in that they create instances, however, _abstract_ factories are responsible for creating more than just one object.  You can consider _abstract_ factories as classes that are responsible for creating the building blocks of a more complex entity.

## Example

Imagine you have to design how to build different types of computers.  Currently you are responsible for building laptops and smartphones.  These types of computers have vastly different internals such as CPUs and RAM.

Since you do not want to mistakenly build computers with incompatible components, you decide to use the Abstract Factory Pattern.  By doing so, you ensure that each computer type is only built with components that are compatible to that type of computer.  For example, laptops can have either have Intel or AMD CPUs, but smartphones typically can only handle ARM CPUs.  You create two abstract factories: the _LaptopFactory_ for creating all components that are compatible for laptops and the _SmartPhoneFactory_ for creating all components that are compatible for smartphones.

## Usage

``` csharp

// *********************  Laptop Scenario  ***********************
var factory = new LaptopFactory();

var laptopCPU = factory.CreateCPU();
var laptopRAM = factory.CreateRAM();

// *********************  Smartphone Scenario  ***********************
factory = new SmartphoneFactory();

var phoneCPU = factory.CreateCPU();
var phoneRAM = factory.CreateRAM();

```

## Advantages

* Improves maintainability by being able to replace an entire family of products by just replacing the implemented abstract factory instance
* Promotes product consistency by not allowing the creation of a product that belongs to another family

## Disadvantages

* Adds additional objects to maintain (i.e. the concrete _abstract_ factories and interface)
* Difficult to extend abstract factories to create new products since you would need to update all concrete implementations of the abstract factory in order to do so