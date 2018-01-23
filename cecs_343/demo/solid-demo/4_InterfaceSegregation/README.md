# Interface Segregation Principle (ISP)

## Principle

It is better to have many, smaller client-specific interfaces instead of one general-purpose interface.  Smaller interfaces allows for more appropriate reusability as it does not lead to enforcing behavior that may not be relevant just so a specific behavior can be inherited.

## Rquirements

* Leverage code found in preceeding modules (1-3) if needed.

* Staff needs to attend meetings along with performing administrative tasks.

* Distinction between graduate students and undergrads since only graduates need to submit a thesis while undergrads do not.

* All students also need to attend meetings for club activities, group projects, etc.

## Before

Both _Staff_ and _Student_ were updated to have a new _AttendMeeting()_ method.  _Student_ aslo was modified to have a new _isUndergrad_ flag and the constructor was updated to require this agrument and _SubmitThesis()_ method.  Finally, _IEmployee_ was updated to have _AttendMeeting()_ in order to not break LSP from the previous module.  Consequenently, _Faculty_ and all of it's subclasses will also now need to implement _AttendMeeting()_ in order to maintain contract parity.

Changes to _Faculty_ and all of it's subclasses were not explicitly required to satisfy the current requirements, therefore, _technically_ it is acceptable.  However, I would argue that an undocumented requirement/system change is more worst than violating an OOD principle because unauthorized changes can lead to legal/regulatory ramifications.  As such, do **NOT** blindly follow guidelines in a vacuum.  Always evaluate the entire domain before implementing a change.

The changes to _IEmployee_ violates the Interface Segregration Prinicple by only having one "giant" interface instead of smaller, more manageable contracts.

## After

_IAttendMeeting_, _IStudent_ and ISubmitThesis interfaces were created.  _IAttendMeeting_ represents the _AttendMeeting() behavior that both Students and Staff members can perform.  As such, both _Staff_ and _Student_ inherits from it in order to gain the _AttendMeeting()_ behavior.  Since only _Staff_ inherits from _IAttendMeeting_, _Faculty_ does not need to be altered and the LSP is maintained when substituting based off of _IEmployee_ behaviors as both _Staff_ and _Faculty_ subclasses still adheres to that contract.

_IStudent_ was created to represent commonality for all students.  _ISubmitThesis_ represents the _SubmitThesis()_ behavior.  In addition, the Student object was removed completely and instead dedicated objects for _Graduate_ and _Undergrad_ were made.  Both objects inherit from _IStudent_, while only Graduate inherit from _ISubmitThesis_.  The separation alleviates the need to have a check if an instance is a graduate prior to submitting a thesis.  Also, it makes for cleaner code by removing the _SubmitThesis()_ method completely from _Undergad_ as this behavior was not applicable to it.