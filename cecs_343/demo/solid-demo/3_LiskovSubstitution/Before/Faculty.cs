namespace solid_demo.LiskovSubstitution.Before
{
    // An "abstract" class is declared since an instance of Faculty should not be possible
    // Only instances of the subclass can be made
    public abstract class Faculty
    {
        // Read-only accessors
        public string Department {get;}
        public string FirstName {get;}
        public string LastName {get;}

        // Marked as "protected" so subclasses has access to them
        protected int _employeeId {get;}
        protected Room _office;


        public Faculty(string department, string firstName, string lastName)
        {
            Department = department;
            FirstName = firstName;
            LastName = lastName;
            _employeeId = GenerateUniqueEmployeeId();
        }

        private int GenerateUniqueEmployeeId()
        {
            // Assume that code generates a unique employee ID
            // Could be as simple as the number of epoch since Jan 1, 0001
            return 0;
        }

        public Room Office => _office;

        public void UpdateOffice(Room newOffice)
        {
            _office = newOffice;
        }

        // Teach is marked as "abstract" so that subclasses must implement this method
        public abstract void Teach(Course course);

    }
}