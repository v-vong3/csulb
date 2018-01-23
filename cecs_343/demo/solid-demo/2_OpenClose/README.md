# Open/Close Principle (OCP)

## Principle

Objects should be closed to change, but open to extensibility.  The objects should be structured in a way where existing objects should not need to be changed in order to address requirement change.  However, when new requirements invalidates old requirements, then this principle is no longer applicable to the existing objects.

## Requirements

* Use Code found in SingleResponsibility/After as a starting point

* Alter the instructor object to account for part-time, full-time and emeritus.  In the future, there may be additional classification such as fellow, researcher and teacher-aide.

* Implement a _teach_ behavior for instructors in which the classification affects how the instructor teaches.  Part-time instructors can only teach at night (after 5:00PM).  Full-time instructors can teach all day.  Emeritus instructors are typically only guest lectures so they teach limited sessions or do not teach at all.  For simplicity, instructors can only teach one course.

## Before

The _InstructorType_ enumeration object was created to represent the various classifications.  This allows for easily identifying the classifciation of an instructor.  In addition, a new _Teach()_ method was implemented using _if-else_ statements (can also be _switch_ statements) to control what teach implementation to execute based on instructor classification.

The preceeding implementaiton violates the Open/Close principle because it requires the direct change to existing code when trying to expand functionality to the instructor object.  In addition, when a new instructor type is introduced, such as "Researcher", the _Teach()_ method must be altered again to accommodate for the new requirement.  Implementing other instructor types will result in a giant chain of conditional statements in the _Teach()_ method.

## After

A new _Faculty_ abstract base class was created so that extensions can be made through inheritance instead of directly on the existing base object.  Thus, the base class (core attributes/behaviors) are closed to modifications, but the subclasses (additional attributes/behavior) are open to extensions.  Now, the _Teach()_ method can be extended in the subclasses to accomodate all other faculty classification without affecting the rest of the system.  In this example, only the PartTimeFaculty subclass is created to show what the subclass will look like.  The other implemenations of the instructor types will be similiar.  Finally, since this examples relies on inheritance, the private members of _Instructor_ was converted to _protected_ in _Faculty_ so that the subclasses will have access to those members.