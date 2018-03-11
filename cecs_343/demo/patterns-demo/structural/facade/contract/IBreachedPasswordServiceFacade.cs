namespace patterns_demo.structural.facade.contract
{
    /// <summary>
    /// Defines a contract for internal usage of third-party vendor service
    /// </summary>
    public interface IBreachedPasswordServiceFacade
    {
        /// <summary>
        /// Determines if either a username or a password has been published in the "dark" web
        /// </summary>
        /// <param name="usernameData">Byte stream representation of a username</param>
        /// <param name="passwordData">Byte stream representation of a password</param>
        /// <returns>Byte stream containing response from vendor's service</returns>
         byte[] CheckCredentials(byte[] usernameData, byte[] passwordData);
    }
}