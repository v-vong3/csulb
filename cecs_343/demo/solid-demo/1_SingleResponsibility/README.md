# Single Responsibility Principle (SRP)

## Rquirements

* Model a university course.  Courses need to be able to update their room location and description.  Students need to be able to add a course, but their major's department must be the same as the course's department.  For simplicity, assume that university departments and student majors are one to one.

* Model a university instructor.  Instructors need to be able to update their office location.  Do not implement a Teach behavior.

## Before

Course.cs is bloated with too many related, but disparate entities (Courses, Instructors, Students & Rooms).  This makes the Course.cs hard to maintain because logic and attributes related to various entities are inside one file causing any change to any of the entities to possibly impact the system since everything is in one file.  It is preferrable to break these entities into their own file/object.  By doing so, each entity is dedicated to only one responsibility, whih is to manage itself.

## After

Even though the requirements did not explicitly state for a Student model, one was created so that the entity can be properly represeneted.  If addition rules regarding _Course.AddStudent()_ are introduced, having a dedicated Student model will make implementing the change easier.
Furhtermore, all other entities have been split into their own individual file and object.  This improves object encapsulation as only directly related attributes and behaviors are present in the object.  In addition, any change to a single entity is less likely to impact the rest of the system due to the code separation.  Finally, and most importantly, comprehension of the system is improved as it is more clear which file is responsible for which entity.  Therefore, improving the speed it takes to reasonable an object and finding where code changes need to be made.