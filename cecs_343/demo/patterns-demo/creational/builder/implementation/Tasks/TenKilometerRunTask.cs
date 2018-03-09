namespace patterns_demo.creational.builder.implementation
{
    using patterns_demo.creational.builder.contract;
    public class TenKilometerRunTask : ITask
    {
        public ITask NextTask {get; set;}

        public void Execute()
        {
            // Do 10 Kilometer run
        }
    }
}