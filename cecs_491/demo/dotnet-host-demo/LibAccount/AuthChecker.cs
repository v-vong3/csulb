namespace LibAccount
{
    public class AuthChecker
    {

        public readonly AuthDAO _authDAO;

        public AuthChecker(AuthDAO authDAO) // Data access object dependency
        {
            _authDAO = authDAO;
        }

        public bool IsAuthorized(string username)
        {
            var currentRole = _authDAO.GetUserRole(username);

            if (currentRole == "AppUser")
            {
                return true;
            }

            return false;
        }
    }
}