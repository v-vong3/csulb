namespace patterns_demo.behavioral.strategy.implementation
{
    using System.Collections.Generic;
    using patterns_demo.behavioral.strategy.contract;

    public class NormalWorkoutStrategy : IWorkoutStrategy
    {
        private ICollection<ITask> Tasks {get;}
        public int TaskCount {get;}

        public NormalWorkoutStrategy()
        {
            // Example of using a collection to store exercise tasks
            Tasks.Add(new OneHundredPushUpsTask());
            Tasks.Add(new OneHundredSitUpsTask());
            Tasks.Add(new OneHundredSquatsTask());
            Tasks.Add(new TenKilometerRunTask());

            // Don't forget to not use any AC & to eat healthy every day

            TaskCount = Tasks.Count;
        }

        public void Execute()
        {
            foreach(var task in Tasks)
            {
                task.Execute();
            }
        }
        
    }
}