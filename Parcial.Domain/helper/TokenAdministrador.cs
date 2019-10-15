namespace Parcial.Domain.helper
{
    public class TokenAdministrador
    {
        public string SecretKey {get; set;}
        public string AccessExpiration {get; set;}
        public string RefreshExpiration {get; set;}
    }
}