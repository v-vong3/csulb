namespace patterns_demo.behavioral.strategy.implementation
{
    using System.Collections.Generic;
    using patterns_demo.behavioral.strategy.contract;

    public class LegDayWorkoutStrategy : ICommand
    {
        private ITask InitialTask {get;}

        public LegDayWorkoutStrategy()
        {
            // Example of using NextTask to link to another task
            InitialTask = new OneHundredSquatsTask();
            InitialTask.NextTask = new OneHundredLungesTask()
            {
                NextTask = new FiftyLegExtensionsTask()
            };
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