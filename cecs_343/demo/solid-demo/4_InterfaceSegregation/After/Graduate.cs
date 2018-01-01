namespace solid_demo.InterfaceSegregation.After
{
    public class Graduate : IStudent, ISubmitThesis
    {
        // Read-only accessors
        // IStudent interface
        public string FirstName {get;}
        public string LastName {get;}

        // Private members
        private int _campusId {get;}
        private string _major; 
        private bool _isUndergrad;


        public Graduate(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            _campusId = GenerateUniqueCampusId();
            _isUndergrad = false;  // Setting value explicitly since instances of this object are graduates
        }

        private int GenerateUniqueCampusId()
        {
            // Assume code generates a unique campus ID
            // Could be as simple as the number of epoch since Jan 1, 0001
            return 0;
        }

        // IStudent interface
        public string Major => _major;

        // IStudent interface
        public void UpdateMajor(string newMajor)
        {
            _major = newMajor;
        }


        // IAttendMeeting interface
        public void AttendMeeting(Room meetingRoom)
        {
            // Code to attend meeting
        }

        // IStudent interface
        public bool IsUndergrad => _isUndergrad;

        public void SubmitThesis()
        {
            // Undergrad check is not needed before submission since this instance represent a graduate student only

            // Code to submit thesis
        }
    }
}