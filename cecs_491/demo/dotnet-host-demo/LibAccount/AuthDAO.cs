namespace LibAccount
{
    public class AuthDAO
    {
        public static int _instanceCounter;


        public AuthDAO() // No Dependencies
        {
            InstanceId = DateTime.Now.Millisecond.ToString();
        }


        public string GetUserRole(string username)
        {
            return "AppUser";
        }


        #region Factory Method Pattern for Service Lifecycle testing

        // ONLY for demo purpose, NOT a thread-safe implementation of factory method
        public static AuthDAO CreateInstance()
        {
            // NOT a thread-safe implementation of updating
            _instanceCounter++;

            return new AuthDAO();
        }

        #endregion


        #region For Scoped Lifecycle testing

        public string InstanceId { get; set; }

        #endregion
    }
}