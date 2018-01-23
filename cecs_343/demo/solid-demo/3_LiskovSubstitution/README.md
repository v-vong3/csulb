# Liskov's Substitution Principle (LSP)

## Principle

Instances of the parent object should be replaceable with instances of their subtype object without altering the correctness of the system.  Promotes "design by contracts" in which functionality are expanded through composition of behaviors instead of through direct inheritance of objects.

## Rquirements

* Utilize code from OpenClose/After if needed

* There now needs to be a distinction between Faculty (employees that teach) and Staff (employees that perform administrative tasks)

* Staff needs to be able to update their office just like Faculty.

## Before

Created a new class _Staff_.  This class inherits from _Faculty_ since a lot of it's attributes and behavior matches what staff requires.  Staff contains a method _PerformAdminTask()_ which makes them distict from Faculty.

This violates LSP because the subclass (_Staff_) contains behavior that is different from the parent (_Faculty_).  As such, a subsitution of the types will not be compatible since areas where Staff needs to call _PerformAdminTask()_ will not be applicable to Faculty while areas where Faculty needs to call _Teach()_ will not be applicable to Staff.

## After

Instead of solely relying on inheritance, the system now relies on a contract.  A contract is a set of attributes or behaviors that all objects that implement the contract must abide by.  This concept is also called "design by contract".  In .NET and Java, a contract is implemented as the _interface_ construct.  An _interface_ is like a class, but it only defines **public member signatures**.  Review **method signatures** if you need further information.

In this example, _IEmployee_ is an _interface_ that defines the basic commonality between Faculty and Staff.  Both _Faculty_ and _Staff_ implements _IEmployee_.  Since both _Faculty_ and _Staff_ adheres to _IEmployee_, the substitution of their objects will result in no breakage in the system.