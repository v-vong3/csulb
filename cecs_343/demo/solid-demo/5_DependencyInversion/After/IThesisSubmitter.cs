namespace solid_demo.DependencyInversion.After
{
    public interface IThesisSubmitter
    {
        // Implementation will have code to send email or any other type of submission (e.g. web service, ftp upload, etc.)
         void Submit();
    }
}