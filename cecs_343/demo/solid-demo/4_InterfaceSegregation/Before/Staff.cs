namespace solid_demo.InterfaceSegregation.Before
{
    // Staff could have been marked "abstract" just like Faculty, but wanted to show that interface inheritance
    // is not restricted to a base class
    public class Staff : IEmployee
    {
        public string FirstName {get;}
        public string LastName {get;}
        public string Department {get;}
        
        protected Room _office;
        

        // Note that Staff does not require a Course argument in the constructor like Faculty does
        // An Employee abstract base class could have been utilized as well to house the commonalities
        // instead of inheriting the IEmployee interface directly
        public Staff(string department, string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Department = department;

            _office = null;

            // To improve Open/Close aspect of this class, you can pass in a delegate to the constructor
            // The delegate would represent the specific administrative task that needs to be performed
            // This way it is not needed to have subclasses of Staff if new tasks are needed.
            // Delegates are outside of the scope of this demo.
        }


        // IEmployee's Office property requirement
        public Room Office => _office;

        // IEmployee's UpdateOffice() requirement
        public void UpdateOffice(Room newOffice)
        {
            _office = newOffice;
        }

        // IEmployee's DoWork() requirement
        public void DoWork()
        {
            // Code to perform administrative task

            // Call a delegate here if passed into constructor
        }

        public void AttendMeeting(Room meetingRoom)
        {
            // Code to attend meeting
        }

    }
}