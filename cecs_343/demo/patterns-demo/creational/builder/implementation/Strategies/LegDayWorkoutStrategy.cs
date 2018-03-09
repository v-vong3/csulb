namespace patterns_demo.creational.builder.implementation
{
    using System.Collections.Generic;
    using patterns_demo.creational.builder.contract;

    public class LegDayWorkoutStrategy : IWorkoutStrategy
    {
        // Note 1: Unlike the Strategy Pattern, this strategy now utilize a list of ITasks
        // instead of an ITask object.  This is becuase the WorkoutBuilder has standardized
        // how workout strategies should be instantiated
        private ICollection<ITask> Tasks {get;}
        public int TaskCount {get;}

        // Note 2: Workout strategies now require an argument in the constructor
        public LegDayWorkoutStrategy(ICollection<ITask> tasks)
        {
            Tasks = tasks;
            TaskCount = Tasks.Count;
        }

        public void Execute()
        {
            // Note 3: All workout strategies will now use the same mechanism for iterating
            // through each exercise task.  As such, it behooves the developer to make a base
            // workout strategy class that implements Execute() to reduce code redundancy 
            foreach(var task in Tasks)
            {
                task.Execute();
            }
        }
        
    }
}