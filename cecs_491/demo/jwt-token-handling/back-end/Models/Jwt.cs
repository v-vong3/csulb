namespace back_end
{
    public class Jwt
    {
        public JwtHeader Header {get; set;} = new JwtHeader();
        public JwtPayload Payload {get; set;} = new JwtPayload();

        public string? Signature {get; set;} = String.Empty;
    }
}