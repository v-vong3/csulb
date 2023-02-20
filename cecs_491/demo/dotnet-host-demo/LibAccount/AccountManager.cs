using System.Runtime.InteropServices;

namespace LibAccount
{
    public class AccountManager
    {

        public readonly AuthChecker _authChecker;

        public AccountManager(AuthChecker authChecker) // Security dependency
        {
            _authChecker = authChecker;
        }

        public bool CreateAccount()
        {

            return true; // NOOP

        }

        public bool DeleteAccount()
        {
            var username = Thread.CurrentPrincipal?.Identity?.Name ?? string.Empty;

            if (_authChecker.IsAuthorized(username))
            {
                // Perform operation

                return true;
            }

            // Not authorized, so fail

            return false;
        }

    }
}