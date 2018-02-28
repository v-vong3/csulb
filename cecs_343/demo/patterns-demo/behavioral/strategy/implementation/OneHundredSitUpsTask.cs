using patterns_demo.behavioral.strategy.contract;

namespace patterns_demo.behavioral.strategy.implementation
{
    public class OneHundredSitUpsTask : ITask
    {
        public ITask NextTask {get; set;}

        public void Execute()
        {
            // Do 100 sit-ups
        }
    }
}