namespace solid_demo.LiskovSubstitution.After
{
    public abstract class Faculty : IEmployee
    {
        // Read-only accessors
        // IEmployee's property requirement
        public string FirstName {get;}
        public string LastName {get;}
        public string Department {get;}
        
        // Marked as "protected" so subclasses has access to them
        protected Room _office;
        protected Course _course;
        

        // Faculty contructor now requires a Course to instantiate 
        public Faculty(string department, string firstName, string lastName, Course course)
        {
            FirstName = firstName;
            LastName = lastName;
            Department = department;

            _office = null;
            _course = course;
        }

        // IEmployee's Office property requirement
        public Room Office => _office;

        // IEmployee's UpdateOffice() requirement
        public void UpdateOffice(Room newOffice)
        {
            _office = newOffice;
        }

        // Even though DoWork() is marked as abstract, it still satisfies IEmployee's DoWork() requirement 
        public abstract void DoWork();

    }
}