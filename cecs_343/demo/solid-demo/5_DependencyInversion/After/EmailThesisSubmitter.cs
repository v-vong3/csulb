namespace solid_demo.DependencyInversion.After
{
    using System.Net.Mail; // Importing namespace/library for MailMessage and Smtp (email server)

    public class EmailThesisSubmitter : IThesisSubmitter
    {
        private string To {get;}
        private string From {get;}
        private string Subject {get;}

        private string Host {get;}

        private int Port {get;}

        private string DocumentFilePath {get;}


        public EmailThesisSubmitter(string from, string firstName, string lastName, string documentFilePath)
        {
            // BUSINESS RULE: All attributes here
            From = from;
            Subject = $"[{firstName} {lastName}] Thesis";
            Host = "Email_Server_Host";
            Port = 25;
            To = "thesis@campus.school.edu";
            DocumentFilePath = documentFilePath;
        }

        public void Submit()
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(From); // Student's email
            // BUSINESS RULE: Reciepient 
            message.To.Add(new MailAddress(To)); // Reciepient

            // BUSINESS RULE: Format of Subject line
            // Use of C# 6's string template literals
            message.Subject = Subject;

            Attachment thesis = new Attachment(DocumentFilePath);
            message.Attachments.Add(thesis);

            // BUSINESS RULE: Email host and port
            // Research .NET Using constructs for properly desposing of memory intensive objects   
            SmtpClient client = new SmtpClient(Host, Port);

            client.Send(message);
        }    
    }
}