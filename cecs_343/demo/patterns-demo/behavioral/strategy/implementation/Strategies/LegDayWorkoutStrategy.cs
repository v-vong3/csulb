namespace patterns_demo.behavioral.strategy.implementation
{
    using System.Collections.Generic;
    using patterns_demo.behavioral.strategy.contract;

    public class LegDayWorkoutStrategy : IWorkoutStrategy
    {
        private ITask InitialTask {get;}
        public int TaskCount {get;}

        public LegDayWorkoutStrategy()
        {
            // Example of using NextTask to link to another task just like a linked-list
            InitialTask = new OneHundredSquatsTask();
            InitialTask.NextTask = new OneHundredLungesTask()
            {
                NextTask = new FiftyLegExtensionsTask()
            };

            TaskCount = 3;
        }

        public void Execute()
        {
            var currentTask = InitialTask;

            while(currentTask.NextTask != null)
            {
                currentTask.Execute(); // Perform the action

                currentTask = currentTask.NextTask; // Move to next step
            }
        }
        
    }
}