namespace solid_demo.OpenClose.Before
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
        private InstructorType _type;


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

        public InstructorType Type => _type;

        public void UpdateType(InstructorType newType)
        {
            _type = newType;
        }

        public void Teach(Course course)
        {
            if(Type != InstructorType.Emeritus)
            {
                if(Type == InstructorType.PartTime)
                {
                    // BUSINESS RULE: PartTime - Teach only after 5:00PM
                }
                else
                {
                    // BUSINESS RULE: FullTime - Teach both AM and PM courses
                }
            }
            else
            {
                // BUSINESS RULE: Emeritus - no teaching or only a single guest seminar session
            }
            
        }


    }
}