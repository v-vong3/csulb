namespace patterns_demo.creational.builder.implementation
{
    using System.Collections.Generic;
    using patterns_demo.creational.builder.contract;

    public class NormalWorkoutStrategy : IWorkoutStrategy
    {
        private ICollection<ITask> Tasks {get;}
        public int TaskCount {get;}

        // Note 1: Workout strategies now require an argument in the constructor
        public NormalWorkoutStrategy(ICollection<ITask> tasks)
        {
            Tasks = tasks;
            TaskCount = Tasks.Count;
        }

        public void Execute()
        {
            // Note 2: All workout strategies will now use the same mechanism for iterating
            // through each exercise task.  As such, it behooves the developer to make a base
            // workout strategy class that implements Execute() to reduce code redundancy 
            foreach(var task in Tasks)
            {
                task.Execute();
            }
        }
        
    }
}