namespace solid_demo.OpenClose.After
{
    public class Student
    {
        public string FirstName {get;}
        public string LastName {get;}

        private int _campusId {get;}
        private string _major; 

        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            _campusId = GenerateUniqueCampusId();
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

    }
}