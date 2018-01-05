# Single Responsibility Principle (SRP)

## Rquirements

* Model a university course.  Courses need to be able to update their room location and description.  Students need to be able to add a course, but their major's department must be the same as the course's department.  For simplicity, assume that university departments and student majors are one to one.

* Model a university instructor.  Instructors need to be able to update their office location.  Do not implement any teaching behavior.

## Before

_Course_ is a bloated object with too many related, but disparate entities (e.g. Courses, Instructors, Students and Rooms).  This makes _Course_ hard to maintain because logic and attributes related to various entities are combined into a single file.  Consequently, any future change could negatively impact any of these entities as it is unclear where, within Course.cs, _Course_ code begins and ends and where _Instructor_ code begins and ends.  It is preferrable to break distinct entities into their own file/object.  By doing so, each entity is dedicated to only one responsibility, which is to manage itself.

## After

All distinct entities have been split into their own individual file ane object.  This improves object encapsulation as only directly relevant attributes and behaviors are present in an object.  Such code separation reduces the chances of accidently modifying code belonging to another entity.  Most importantly, this reduces the mental load needed to reason about a system.  As a result, developer productivity increases as it takes less time to find code that needs to be changed.

Even though the requirements did not explicitly requested for a _Student_ object, one was created so that the student entity can be properly represeneted instead of the entity being tied to another object.  Doing so also reduces the amount of work needed to implement business rules related to students as all relevant data would be available within a _Student_ instance.
