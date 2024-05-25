using Fiap.TechChallenge.Fase1.Dominio;
using Fiap.TechChallenge.Fase1.Infraestructure.DTO.Usuario;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Fiap.TechChallenge.Fase1.Aplicacao
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> ObterToken(AutenticarUsuarioDTO usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var chaveCriptografia = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretJWT")!);

            var tokenPropriedades = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new(ClaimTypes.Name, usuario.Email),
                }),
                Expires = DateTime.UtcNow.AddHours(8),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(chaveCriptografia),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenPropriedades);


            return tokenHandler.WriteToken(token);
        }
    }
}
