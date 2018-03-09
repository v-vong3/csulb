namespace patterns_demo.creational.builder.implementation
{
    using patterns_demo.creational.builder.contract;
    public class OneHundredLungesTask : ITask
    {
        public ITask NextTask {get; set;}

        public void Execute()
        {
            // Do 100 lunges
        }
    }
}