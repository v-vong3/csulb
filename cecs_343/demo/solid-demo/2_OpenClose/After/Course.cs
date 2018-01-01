namespace solid_demo.OpenClose.After
{
    using System;  // Importing namespace/library needed for ArgumentException object

    public class Course
    {
        // Read-only accessors
        public string Department {get;}
        public string Name {get;}

        // Private members
        private string _description;
        private Room _room;
        private Student[] _enrolled;
        private Student[] _waitlisted;
        private int _enrolledIndex;
        private int _waitlistedIndex;


        public Course(string department, string name, string description)
        {
            Department = department;
            Name = name;

            _description = description;
            _enrolled = new Student[30]; // Initialize to course maximum 
            _waitlisted = new Student[15]; // Initialize to maximum waitlisted

            _enrolledIndex = 0;
            _waitlistedIndex = 0;
        }

        public Room Room => _room;

        public void SetRoom(Room room)
        {
            _room = room;
        }

        public bool AddStudent(Student student)
        {
            // BUSINESS RULE: Only students whose major is the same department of course can enroll
            // Can substitue "this.Department" with just "Department", but using the former to improve clarity
            if(student.Major != this.Department)  
            {
                // Throwing an argument instead of returning false to make outcome distinct 
                // as to why AddStudent was not successful
                throw new ArgumentException("Student major does not match");
            }

            if(_enrolledIndex < _enrolled.Length)
            {
                _enrolled[_enrolledIndex] = student;
                _enrolledIndex++;

                return true;
            }
            else if (_waitlistedIndex < _waitlisted.Length)
            {
                _enrolled[_enrolledIndex] = student;
                _enrolledIndex++;

                return true;
            }

            return false; // Exceeds both enrolled and waitlisted limits
        }

        public string Description => _description;
        public void UpdateDescription(string newDescription)
        {
            _description = newDescription;
        }

    }
}