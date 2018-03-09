namespace patterns_demo.creational.builder.contract
{
    /// <summary>
    /// Defines contract for implementing the Builder Pattern for workout strategies
    /// </summary>
    public interface IWorkoutStrategyBuilder
    {
        // Note 1: It is important to realize that you can define a Builder object
        // however you so desire, such as adding a RemoveTask() method and so forth.
        // The most important behavior is the Build() method as it returns the 
        // workout strategy which this pattern is meant to achieve.

        // Note 2: Both AddTask() and ClearTasks() returns IWorkoutStrategyBuilder
        // This allows for the Builder API to be used in a fluent manner

        /// <summary>
        /// Add a new exercise task to the end of the workout routine
        /// </summary>
        /// <param name="task">ITask instance</param>
        IWorkoutStrategyBuilder AddTask(ITask task);

        /// <summary>
        /// Clears the workout routine
        /// </summary>
        IWorkoutStrategyBuilder ClearTasks();

        /// <summary>
        /// Determines what workout strategy instance to create
        /// </summary>
        /// <param name="workoutType">Enumeration of workout strategy</param>
        /// <returns>IWorkoutStrategy instance</returns>
         IWorkoutStrategyBuilder SetWorkoutType(WorkoutStrategyEnum workoutType);

        /// <summary>
        /// Create the workout strategy instance
        /// </summary>
        /// <returns>IWorkoutStrategy instance</returns>
         IWorkoutStrategy Build();

        
    }
}