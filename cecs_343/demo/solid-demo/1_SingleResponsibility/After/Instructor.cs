namespace solid_demo.SingleResponsibility.After
{
    public class Instructor
    {
        // Read-only accessors
        public string Department {get;}
        public string FirstName {get;}
        public string LastName {get;}

        // Private members
        private int _employeeId {get;}
        private Room _office;


        public Instructor(string department, string firstName, string lastName)
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
    }
}