namespace Company.BankApp.Web.Models
{
    // Lecture: It is not best practice to define models within
    // the ASP.NET Core web project.  It is better to define models 
    // in their own library project so that you can reuse them for
    // other projects.
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public string SuperCoolText { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
