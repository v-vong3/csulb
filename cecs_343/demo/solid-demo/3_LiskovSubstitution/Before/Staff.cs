namespace solid_demo.LiskovSubstitution.Before
{
    using System; // Importing namespace/library needed for NotImplementedException()
    public class Staff : Faculty
    {
        public Staff(string department, string firstName, string lastName) : base(department, firstName, lastName)
        {
            // Code to further initialize Staff 
        }

        public override void Teach(Course course)
        {
            throw new NotImplementedException("Staff does not teach");

            // I have seen developers make a call to PerformAdminTask() in here or duplicate code from PerformAdminTask() in here
            // instead of throwing an exception to justify the inheritance. 
            // This kind of practice should NOT be done by all means.
        }

        public void PerformAdminTask()
        {
            // Code to perform administrative task here per instance 
        }

    }
}