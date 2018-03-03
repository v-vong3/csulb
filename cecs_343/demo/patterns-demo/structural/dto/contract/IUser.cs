namespace patterns_demo.structural.dto.contract
{
    /// <summary>
    /// Minimum information needed for any User Profile
    /// </summary>
    public interface IUserProfile
    {
         string Username {get;}
         string Role {get;}
    }
}