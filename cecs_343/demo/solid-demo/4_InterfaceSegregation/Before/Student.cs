namespace solid_demo.InterfaceSegregation.Before
{
    using System; // Importing namespace/library for Exception()

    public class Student
    {
        public string FirstName {get;}
        public string LastName {get;}

        private int _campusId {get;}
        private string _major; 

        private bool _isUndergrad;


        // Requires a new argument so that you know if the student is a graduate or not
        public Student(string firstName, string lastName, bool isUndergrad)
        {
            FirstName = firstName;
            LastName = lastName;
            _campusId = GenerateUniqueCampusId();
            _isUndergrad = isUndergrad;
        }

        private int GenerateUniqueCampusId()
        {
            // Assume code generates a unique campus ID
            // Could be as simple as the number of epoch since Jan 1, 0001
            return 0;
        }

        public string Major => _major;

        public void UpdateMajor(string newMajor)
        {
            _major = newMajor;
        }

        public void AttendMeeting(Room meetingRoom)
        {
            // Code to attend meeting
        }

        public bool IsUndergrad => _isUndergrad;

        public void SubmitThesis()
        {
            // Check is required since you don't know at runtime if this instance is a grad or undergrad
            if(IsUndergrad)
            {
                throw new Exception("Student is not a graduate, thus, cannot submit a thesis.");
            }

            // Code to submit thesis
        }

    }
}