# (CRUD) Repository Pattern

## Description

This pattern is used when you want your appliction to be agnostic to the data store component.  By doing so, you are creating an abstraction layer in between the data store and the rest of your application.  This layer is commonly referred to as the data access layer (DAL) as it is responsible for handling communication to and from the data store to the rest of your system and vice versa.

                          |                   |
        Other App Layers  | Data Access Layer |  Data Store Layer
                          |                   |

Objects belonging to the DAL category are considered data access objects (DAO).  The (CRUD) repository is a specific DAO that only has Create, Read, Update and Delete capabilities.

    * Add a new record in the data store (Create)
    * Fetch record(s) from the data store (Read)
    * Modify existing record(s) in the data store (Update)
    * Remove existing records from the data store (Delete)

Often times repositories are interpretted, by default, as CRUD repositories, while other times the term _Repository_ is interpretted as a DAO that provides a mechanism for getting exactly what you need from the data store, which infer that repositories goes beyond CRUD operations.  Consequently, the term _Repository_ can be misleading in certain circles within the software industry.  To avoid confusion, tt is recommended that you clarify which interpretation of the term is referring to when discussing repositories.

## Example

Image you are tasked with developing a data-centric application.  The application has to deal with data sources from relational database management systems (RDBMS), but the new CIO is mulling over migrating to a document-based management system (NoSQL).  The CIO won't make this discussion until 6-months from now.  Consequently, you may have to switch technology for your new task down the road.

Since you are a lazy developer and you detest the idea of having to rework your entire application to accomodate an arbitrary decision, you decide to base your application's data access needs off of the (CRUD) Repository pattern.  If the NoSQL decision does go through, your application would be mostly insulated against it.  The only portion of your application that would be affect would be the implementation portion of your repository.  As such, you can simply create a new NoSQL repository object and replace any SQL-based repository instances with the new NoSQL repository instances.

## Usage

``` csharp

// Instantiating the repository
var userRepo = new UserCrudRepository();

// *************** CREATE SCENARIO ********************
// Instantiating a new user
var newUser = new User()
{
    FirstName = "John",
    LastName = "Smith",
    Username = "j.smith",
    Password = "hack_proof"
};
var createResult = userRepo.Add(user); // If createResult is true, the operation was a success

// *************** READ SCENARIO *********************
var existingUser = userRepo.Get(123);
var allUsers = userRepo.GetAll();
var allUsersNamedJohn = userRepo.GetAll(u => u.FirstName == "John");

// *************** UPDATE SCENARIO ********************
// Updating the last name of user
existingUser.LastName = "Appleseed";
var updateResult = userRepo.Update(existingUser); // If updateResult is true, the operation was a success

// *************** DELETE SCENARIO ********************
var deleteResult = userRepo.Delete(existingUser); // If deleteResult is true, the operation was a success
var deleteResult = userRepo.Delete(456); // If deleteResult is true, the operation was a success

```

## Advantages

* Decouples the implementation of the data store from the rest of the system.  The rest of the system becomes agnostic to the exact data store that is being used.
* Repository knowledge is translatable to other implementations (i.e. Usage of _CatCrudRepository_ would be the same as _UserCrudRepository_)
* Narrow APIs makes unit testing easier as all implemented repositories behaves the same

## Disadvantages

* Unable to facilitate complex (analysis) queries involving other domain models
* Depending on implementation & technology limitations, Read queries may need to be loaded into memory first before additional filtering can take place
* Not all domain models need the entire CRUD functionality set (i.e. Audit logs will rarely ever need Update or Delete).  These scenarios means there will be many domain models that will either have unimplemented functionalities or implemented functionalities that are never used
