namespace patterns_demo.behavioral.strategy.implementation
{
    using patterns_demo.behavioral.strategy.contract;
    public class FiftyLegExtensionsTask : ITask
    {
        public ITask NextTask {get; set;}

        public void Execute()
        {
            // Do 50 leg extensions
        }
    }
}