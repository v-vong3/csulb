using patterns_demo.structural.facade.contract;

namespace patterns_demo.structural.facade.implementation
{
    /// <summary>
    /// Concrete implementation of Facade
    /// </summary>
    public class BreachedPasswordService : IBreachedPasswordServiceFacade
    {
        // Note 1: The method could have been simplified further by making the 
        // data types of the arguments strings instead of byte arrays and making
        // the return type a boolean instead of a byte array.   
        public byte[] CheckCredentials(byte[] usernameData, byte[] passwordData)
        {
            // Note 2: The method's implementation abstracts out the details
            // of the vendor's actual endpoints 

            // Step 1: Call vendor's username service endpoint

            // Step 2: Call vendor's password service endpoint

            throw new System.NotImplementedException();
        }
    }
}