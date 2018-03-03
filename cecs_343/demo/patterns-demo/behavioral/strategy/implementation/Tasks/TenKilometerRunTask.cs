namespace patterns_demo.behavioral.strategy.implementation
{
    using patterns_demo.behavioral.strategy.contract;
    public class TenKilometerRunTask : ITask
    {
        public ITask NextTask {get; set;}

        public void Execute()
        {
            // Do 10 Kilometer run
        }
    }
}