namespace patterns_demo.behavioral.strategy.implementation
{
    using System.Collections.Generic;
    using patterns_demo.behavioral.strategy.contract;

    public class NormalWorkoutStrategy : ICommand
    {
        private ICollection<ITask> Tasks {get;}

        public NormalWorkoutStrategy()
        {
            // Example of using 
            Tasks.Add(new OneHundredPushUpsTask());
            Tasks.Add(new OneHundredSitUpsTask());
            Tasks.Add(new OneHundredSquatsTask());
            Tasks.Add(new TenKilometerRunTask());

            // Don't forget to not use any AC & to eat healthy every day
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