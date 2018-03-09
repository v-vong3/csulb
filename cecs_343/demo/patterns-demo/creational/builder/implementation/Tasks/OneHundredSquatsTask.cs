namespace patterns_demo.creational.builder.implementation
{
    using patterns_demo.creational.builder.contract;
    public class OneHundredSquatsTask : ITask
    {
        public ITask NextTask {get; set;}

        public void Execute()
        {
            // Do 100 squats
        }
    }
}