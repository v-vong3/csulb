# Strategy Pattern

## Usage

``` csharp
var strategy = new NormalWorkoutStrategy();

strategy.Execute();
```

## Advantages

* Encapsulates a specific workflow/algorithm into a dedicated object
  * Easier to swap out intricate flows by simply changing a single line (i.e. changing which strategy is instantiated)
  * Easier to test different flows by simply changing a single line
* Departmentalizes large code bases into smaller manageable chunks

## Disadvantages

* The strategy is typically responsible for understanding how to construct each and every task that it utilizes unless this concern is offloaded to another entity
* Every task in a strategy is typically in a set order, therefore, rearrangement of any task can be detrimental to the overall strategy unless all tasks are designed to be order agnostic
* All tasks must be aware of the error handling mechanism or else the strategy must decide to handle errors as an aggregate or break out as soon as the first error is encountered
* Layered branching strategies (i.e. tasks with multiple outcomes) can be very complex to configure and debug and possibly recursive