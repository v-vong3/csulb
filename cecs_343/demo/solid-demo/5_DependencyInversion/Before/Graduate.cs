namespace solid_demo.DependencyInversion.Before
{
    using System.Net.Mail; // Importing namespace/library for MailMessage and Smtp (email server)


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
        private string _email; // Student's email address
        private string _thesisFilePath; // Stores the file location of the thesis


        public Graduate(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            _campusId = GenerateUniqueCampusId();
            _isUndergrad = false;  // Setting value explicitly since instances of this object are graduates
            _email = email;
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
            MailMessage message = new MailMessage();
            message.From = new MailAddress(_email); // Student's email
            // BUSINESS RULE: Reciepient 
            message.To.Add(new MailAddress("thesis@campus.school.edu")); // Reciepient

            // BUSINESS RULE: Format of Subject line
            // Use of C# 6's string template literals
            message.Subject = $"[{FirstName} {LastName}] Thesis";

            Attachment thesis = new Attachment(_thesisFilePath);
            message.Attachments.Add(thesis);

            // BUSINESS RULE: Email host and port
            // Research .NET Using constructs for properly desposing of memory intensive objects   
            SmtpClient client = new SmtpClient("Email_Server_Host", 25);

            client.Send(message); 
        }

        public void UpdateThesisFilePath(string newThesisFilePath)
        {
            _thesisFilePath = newThesisFilePath;
        }

    }
}