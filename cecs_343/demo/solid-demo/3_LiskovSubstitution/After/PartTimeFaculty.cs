namespace solid_demo.LiskovSubstitution.After
{
    public class PartTimeFaculty : Faculty
    {
        public PartTimeFaculty(string department, string firstName, string lastName, Course course)
            : base(department, firstName, lastName, course)
        {
            
        }

        // Implement DoWork() to satisfy inheritance chain and IEmployee contract
        // All other IEmployee requirements were defined in base class
        public override void DoWork()
        {
            // BUSINESS RULE: PartTime - Teach only after 5:00PM
            // Code to teach as part time faculty here
        }

    }
}