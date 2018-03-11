# Strategy Pattern

## Description

This pattern is used when you want to encapsulate flows or algorithms as objects.  The concept of this pattern is similar to the Command Pattern.  The goal is to have an object that represents a specific, ordered workload that can be run on demand.

Often times you encounter situations where you need to reuse certain parts of a workflow or algorithm in a new scenario.  Most developers will copy & paste the code into a new area of the code base and then modify what's needed in the copy.  By doing so, you are breaking the Don't Repeat Yourself (DRY) principle by introducing (mostly) redundant code.  Additionally, if a new global change were to take place, you would now be responsible for updating two areas of your application instead of just one.  The Strategy Pattern seeks to alleviate this by forcing developers to compartmentalize code into smaller, finite chunks so that they can be strung together and reused as different workloads.

## Example

Imagine you are tasked with building specific workout plans for different individuals.  You need to be able to mix and match different exercise activities into a set routine according to the needs of the individual.  For example, if one person wants to build upper body strength, then you would need to create a routine that focuses on push ups, pull ups and bicep curls.  If a person wants to be build up endurance, then you would need to create a routine that focuses on running, burpies and push ups.  From these two scenarios, you can see that you will need to reuse certain exercise activies.

Since you detest having redundant code in your application, you decide to follow the Strategy Pattern in order to promote code reuse.  Consequently, individual exercise activities are modeled as executable tasks while the workout routine as a whole is modeled as an executable workout strategy.  The workout strategy would represent an _ordered_ collection of exercise tasks.  When a workout strategy is executed it iterate through the ordered collection of tasks and execute then one by one until the last task has been executed.

## Usage

``` csharp

// Instantiate a leg day workout
var strategy = new LegDayWorkoutStrategy();
strategy.Execute(); // Perform the workout

// Instantiate a normal day workout
strategy = new NormalWorkoutStrategy();
strategy.Execute();

```

Notice how concise and clear the usage code is.  Image how bloated the code would be if the Strategy Pattern was not used and how much knowledge calling entity would need to know about all of the individual exercise task.

## Advantages

* Encapsulates a specific workflow/algorithm into a dedicated object
  * Easier to swap out intricate flows by simply changing a single line (i.e. changing which strategy is instantiated)
  * Easier to test different flows by simply changing a single line
* Departmentalizes large code bases into smaller manageable chunks

## Disadvantages

* Adds an additional object to maintain (i.e. the Strategy object and interface)
* The strategy is typically responsible for understanding how to construct each and every task that it utilizes unless this concern is offloaded to another entity
* Every task in a strategy is typically in a set order, therefore, rearrangement of any task can be detrimental to the overall strategy unless all tasks are designed to be order agnostic
* All tasks must be aware of the error handling mechanism or else the strategy must decide to handle errors as an aggregate or break out as soon as the first error is encountered
* Layered branching strategies (i.e. tasks with multiple outcomes) can be very complex to configure and debug and possibly recursive