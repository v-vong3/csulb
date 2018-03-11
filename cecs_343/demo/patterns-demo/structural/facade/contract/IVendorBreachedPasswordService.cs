namespace patterns_demo.structural.facade.contract
{
    /// <summary>
    /// Example of available APIs from a vendor's service.  Typically, provided from the vendor as  
    /// documentation instead of concrete code
    /// </summary>
    public interface IVendorBreachedPasswordService
    {
        /// <summary>
        /// Determines if a password has been published in the "dark" web  
        /// </summary>
        /// <param name="passwordData">Byte stream representing a password</param>
        /// <returns>Byte stream containing response from vendor's service</returns>
        byte[] CheckPassword(byte[] passwordData);

        /// <summary>
        /// Determines if a username has been published in the "dark" web
        /// </summary>
        /// <param name="usernameData">Byte stream representing a username</param>
        /// <returns>Byte stream containing response from vendor's service</returns>
        byte[] CheckUsername(byte[] usernameData);
    }
}