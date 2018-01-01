namespace solid_demo.SingleResponsibility.Before
{
    public class Course
    {
        // Public accessors
        public string CourseDepartment { get; }
        public string CourseName { get; }
        public bool IsNightClass { get; }

        // Private members
        private string[] _students { get; }
        private int _studentIndex;

        private string _instructorName;
        private string _instructorOfficeBuilding;
        private int _instructorOfficeFloor;
        private int _instructorOfficeNumber;

        public string _courseBuilding;
        public int _courseFloor;
        public int _courseRoomNumber;
        public string _courseDescription;

        /// <summary>
        /// Constructor
        /// </summary>
        public Course(string courseDepartment, string courseName, string courseDescription, bool isNightClass) 
        {
            CourseDepartment = courseDepartment;
            CourseName = courseName;
            IsNightClass = isNightClass;

            _courseDescription = courseDescription;
            _students = new string[30];  // Initialize array to maximum course size
            _studentIndex = 0;
        }

        // This is an example of a read-only public property
        public string InstructorName 
        {
            get
            {
                return _instructorName;
            }
        }

        // This is an example of a member body expression that behaves exactly like a read-only property.  
        // From now on, this syntax will be used for "one-liners" so that the code-base is more terse.
        public string InstructorOfficeBuilding => _instructorOfficeBuilding;
        public int InstructorOfficeFloor => _instructorOfficeFloor;
        public int InstructorOfficeNumber => _instructorOfficeNumber;

        public void SetInstructor(string name, string building, int floor, int room)
        {
            _instructorName = name;
            _instructorOfficeBuilding = building;
            _instructorOfficeFloor = floor;
            _instructorOfficeNumber = room;
        }

        public string CourseBuilding => _courseBuilding;
        public int CourseFloor => _courseFloor;
        public int CourseRoomNumber => _courseRoomNumber;

        public void SetCourseRoom(string building, int floor, int room)
        {
            _courseBuilding = building;
            _courseFloor = floor;
            _courseRoomNumber = room;
        }

        public bool AddStudent(string name, string studentMajor)
        {
            if(_studentIndex <= _students.Length - 1) 
            {
                // BUSINESS RULE: Only students whose major is the same department of course can enroll
                if(studentMajor == CourseDepartment) 
                {
                    _students[_studentIndex] = name;
                    _studentIndex++;

                    return true;
                }
            }
            
            return false;
        }

        public string courseDescription => _courseDescription;
        public void UpdateDescription(string newDescription)
        {
            _courseDescription = newDescription;
        }
        

    }
}
