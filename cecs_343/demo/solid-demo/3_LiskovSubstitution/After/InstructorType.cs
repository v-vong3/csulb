namespace solid_demo.LiskovSubstitution.After
{
    public enum InstructorType
    {
        // By default, enum start at 0 and increment by 1 so explicit assignments are not necessary
        // Though it is a good practice to always set the first enum value
        PartTime = 0,
        FullTime = 1,
        Emeritus = 2
    }
}