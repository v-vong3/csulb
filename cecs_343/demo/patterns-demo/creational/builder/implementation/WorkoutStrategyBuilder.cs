using System.Collections.Generic;
using patterns_demo.creational.builder.contract;

namespace patterns_demo.creational.builder.implementation
{
    /// <summary>
    /// Generic builder for all strategies
    /// </summary>
    public class WorkoutStrategyBuilder : IWorkoutStrategyBuilder
    {
        // Explicitly sets default to Normal workout even though Enumerations
        // defaults to the 0 slot anyways
        private WorkoutStrategyEnum WorkoutType {get; set;} = WorkoutStrategyEnum.Normal;
        private ICollection<ITask> Tasks {get;}

        // Note 1: You could just create a builder class for a specific strategy
        // instead of a generic builder for all strategies, but since there isn't 
        // much differences in the creation and setup logic between strategies, 
        // a generic builder is the better route.
        public WorkoutStrategyBuilder()
        {
            Tasks = new List<ITask>();
        }

        public IWorkoutStrategyBuilder AddTask(ITask task)
        {
            Tasks.Add(task);

            return this;
        }

        public IWorkoutStrategyBuilder ClearTasks()
        {
            Tasks.Clear();

            return this;
        }

        public IWorkoutStrategyBuilder SetWorkoutType(WorkoutStrategyEnum workoutType)
        {
            WorkoutType = workoutType;

            return this;
        }

        public IWorkoutStrategy Build()
        {
            switch(WorkoutType)
            {
                case WorkoutStrategyEnum.LegDay:
                    return new LegDayWorkoutStrategy(Tasks);

                case WorkoutStrategyEnum.Normal:
                default:
                    return new NormalWorkoutStrategy(Tasks);
            }
            
        }

        
    }
}