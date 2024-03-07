using System.Security.Claims;

namespace back_end
{

    public class JwtPayload
    {
        public string Iss {get; set;} = string.Empty;
        public string Sub {get; set;} = string.Empty;
        public string Aud {get; set;} = string.Empty;
        public long Exp {get; set;}
        public long Iat {get; set;}


        public long? Nbf {get; set;}

        public string? Scope {get; set;} = String.Empty;

        public ICollection<Claim> Permissions {get; set;} = Array.Empty<Claim>();

    }
}