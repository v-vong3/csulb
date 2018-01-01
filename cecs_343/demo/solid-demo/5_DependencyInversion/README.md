# Dependency Inversion Principle (DIP)

## Rquirements

* Leverage code in previous modules if needed

* Graduates need to submit their thesis by email to thesis@campus.school.edu with Subject "[FirstName LastName] Thesis" including square brackets.

* Email server host is "Email_Server_Host" on port 25

## Before

_Graduate_ was modified to require an email argument for the constructor.  In addition, _UpdateThesisFilePath()_ method was added and corresponding _thesisFilePath_ in order to store/update the thesis' file location.  Finally, the _SubmitThesis()_ was updated to explicitly contain .NET code to send an email according to the requirements.

THis breaks the Dependency Inversion Principle because now the code is dependent on the thesis submission to be an email.  This is compounded by the fact that both _email_ and _thesisFilePath_ are added as members to _Graduate_.  By doing so, email submission becomes more coupled to the object.  Also, the thesis submission is reliant on specifically .NET's implementaiton of sending an email instead of an abstraction.  Therefore, the high level module (_Graduate) is too aware of the implementation details of the thesis submission (.NET's _SmtpClient_)

## After

A new interface, _IThesisSubmitter_ was created to represent the behavior of submitting a thesis.  This interfaces will act as an abstraction to submitting a thesis.  As such, any class that implements this interface will be the only entity that should be aware of the implementation details that was used to submit the thesis.  By doing so, the object that needs to submit the thesis is decoupled from the actual implementation of the submission.  Furthermore, _EmailThesisSubmitter_ was created to represent the implementation details of submitting a thesis by email.  The business rules specific to email submissions are housed within it instead of the _Graduate_ object allowing for more maintainable changes to rules.  In addition, the responsibility of collecting all of the information needed for _EmailThesisSubmitter_ is offloaded to another entity instead of making it the responsibility of _Graduate_.  This ensures that _Graduate_ is only responsible for student attributes instead of also being responsible for email attributes.

Finally, _Graduate_ was modified to require an object that adheres to _IThesisSubmitter_ for the constructor.  This allows extensibility in _Graduate_ as now it is not tied to a specific submission implementaion and is in fact agnostic to the submission implementation.  Therefore, _Graduate_ is not reliant on the low level implmentation details of the submission.