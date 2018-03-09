namespace patterns_demo.creational.builder.implementation
{
    using patterns_demo.creational.builder.contract;
    public class FiftyLegExtensionsTask : ITask
    {
        public ITask NextTask {get; set;}

        public void Execute()
        {
            // Do 50 leg extensions
        }
    }
}