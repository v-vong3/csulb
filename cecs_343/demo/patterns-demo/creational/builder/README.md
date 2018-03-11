# Builder Pattern

## Description

This pattern is used when you want to have more control in how an object is created either during the instantiation process or what specific internal values are set.  The Builder Pattern allows you to dynamically create complex objects during run-time as you have control of how an object should be created.  This means that an object with various settings can use a builder object to create specific instances with little difficulty.

## Example

NOTE:
The example and solution is almost exactly the same from the Strategy Pattern, except for the introduction of the Builder components and a few modifications to the existing workout strategies. It is recommended to review the Strategy Pattern demo first to fully understand this example.

Imagine you are tasked with building specific workout plans for different individuals.  You need to be able to mix and match different exercise activities into a set routine according to the needs of the individual.  For example, if one person wants to build upper body strength, then you would need to create a routine that focuses on push ups, pull ups and bicep curls.  If a person wants to be build up endurance, then you would need to create a routine that focuses on running, burpies and push ups.  From these two scenarios, you can see that you will need to reuse certain exercise activies.

Since you detest having redundant code in your application, you decide to follow the Strategy Pattern in order to promote code reuse.  Consequently, individual exercise activities are modeled as executable tasks while the workout routine as a whole is modeled as an executable workout strategy.  The workout strategy would represent an _ordered_ collection of exercise tasks.  When a workout strategy is executed it iterate through the ordered collection of tasks and execute then one by one until the last task has been executed.

In addition, since you realized that you don't want your workout strategies to be responsible for the creation of the individual exercise task, yout decide to also implement the Builder Pattern as a way to construct your workout strategies.  As a result, you are offloading the responsibility of creating the exercise task and you concretely define a mechanism for creating workout strategies.  Finally, by using the Builder Pattern, you can now dynamically create workout strategies through code at run-time instead of only during design-time.

## Usage

``` csharp

// Instantiate builder object
var builder = new WorkoutStrategyBuilder();

// As a caller entity, I don't need to know that the tasks are being stored as a List<>
// The AddTask() method absolves me from needing to know that implementation detail
builder
    .AddTask(new OneHundredSquatsTask())
    .AddTask(new OneHundredLungesTask())
    .AddTask(new FiftyLegExtensionsTask())
    .SetWorkoutType(WorkoutStrategyEnum.LegDay);

var legDayWorkoutStrategy = builder.Build();


builder
    .ClearTasks() // Reset all tasks
    .SetWorkoutType(WorkoutStrategyEnum.Normal) // Required since it was set to LegDay above
    .AddTask(new OneHundredPushUpsTask());
    .AddTask(new OneHundredSquatsTask());
    .AddTask(new TenKilometerRunTask());
    .AddTask(new OneHundredSitUpsTask());

var normalWorkoutStrategy = builder.Build();

```

## Advantages

* Dynamically configure objects for creation (Solves one of the Factory Pattern's disadvantage)
* Allows you manipulate every step of the creation process

## Disadvantages

* Adds additional objects to maintain (i.e. the Builder object and interface)
* Unable to enforce, during compile-time, that all required members are set other than by throwing an exception during the creation step (i.e. the _Build()_ method)
