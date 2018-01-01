namespace solid_demo.OpenClose.After
{
    public class PartTimeFaculty : Faculty
    {
        // A call to the base class's constructor is executed first by using ": base(...)"
        // The base constructor is passed all parameters as well
        public PartTimeFaculty(string department, string firstName, string lastName) : base(department, firstName, lastName)
        {
            // Additional code to initialize PartTimeFaculty can be added here 
        }

        // Implementing the abstract method Teach in base class 
        public override void Teach(Course course)
        {
            // BUSINESS RULE: PartTime - Teach only after 5:00PM
            // Code to teach as part time faculty here
        }

    }
}