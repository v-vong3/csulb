# (CRUD) Repository Pattern

## Usageß

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
