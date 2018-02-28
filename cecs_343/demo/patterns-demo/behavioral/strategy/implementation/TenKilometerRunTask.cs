using patterns_demo.behavioral.strategy.contract;

namespace patterns_demo.behavioral.strategy.implementation
{
    public class TenKilometerRunTask : ITask
    {
        public ITask NextTask {get; set;}

        public void Execute()
        {
            // Do 10 Kilometer run
        }
    }
}